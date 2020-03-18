﻿using Orleans;
using Outkeep.Caching.Memory.Expressions;
using Outkeep.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Outkeep.Caching.Memory
{
    internal class RegistryQueryProvider : IQueryProvider
    {
        private readonly IGrainFactory _factory;
        private readonly MemoryCacheRegistry _registry;

        public RegistryQueryProvider(IGrainFactory factory, MemoryCacheRegistry registry)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var type = TypeUtility.GetElementType(expression.Type);

            return (IQueryable)Activator.CreateInstance(typeof(RegistryQuery<>).MakeGenericType(type), this, expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>()
        {
            return new RegistryQuery<TElement>(this);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new RegistryQuery<TElement>(this, expression);
        }

        public object Execute(Expression expression)
        {
            using var translator = new RegistryQueryTranslator();

            // build the grain query from the expression tree
            var query = translator.Translate(expression);

            // return the async query enumerator
            // the enumerator itself will execute the grain query upon enumeration
            return new RegistryQueryEnumerator(_factory, query, _registry);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            // return the async query enumerator
            if (typeof(IAsyncEnumerator<ICacheRegistryEntry>).IsAssignableFrom(typeof(TResult)))
            {
                return (TResult)Execute(expression);
            }

            // special check for sync enumerations to let users know they should use async
            if (typeof(TResult) == typeof(IEnumerator<RegistryEntry>))
            {
                throw new NotSupportedException(Resources.Exception_SynchronousEnumerationsAreNotSupportedUseAsynchronousEnumerationsInstead);
            }

            // nothing else is supported
            throw new NotSupportedException(Resources.Exception_TheResultType_X_IsNotSupportedByThisProvider.Format(typeof(TResult).FullName));
        }

        private sealed class RegistryQueryEnumerator : IAsyncEnumerator<RegistryEntry>
        {
            private readonly IGrainFactory _factory;
            private readonly GrainQueryExpression _query;
            private readonly MemoryCacheRegistry _registry;

            public RegistryQueryEnumerator(IGrainFactory factory, GrainQueryExpression query, MemoryCacheRegistry registry)
            {
                _factory = factory ?? throw new ArgumentNullException(nameof(factory));
                _query = query ?? throw new ArgumentNullException(nameof(query));
                _registry = registry ?? throw new ArgumentNullException(nameof(registry));
            }

            private bool _initialized = false;
            private ImmutableList<RegistryEntity>.Enumerator _enumerator;

            private RegistryEntry? _current = null;

            public RegistryEntry Current => _current ?? throw new InvalidOperationException();

            public ValueTask<bool> MoveNextAsync()
            {
                throw new NotImplementedException();
            }

            public ValueTask DisposeAsync() => new ValueTask();
        }
    }
}