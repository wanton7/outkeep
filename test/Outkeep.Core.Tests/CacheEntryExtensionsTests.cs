﻿using Moq;
using Outkeep.Core.Caching;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Outkeep.Core.Tests
{
    public class CacheEntryExtensionsTests
    {
        [Fact]
        public void SetAbsoluteExpiration()
        {
            // arrange
            var entry = Mock.Of<ICacheEntry>();
            var absoluteExpiration = DateTimeOffset.UtcNow;

            // act
            var result = entry.SetAbsoluteExpiration(absoluteExpiration);

            // assert
            Mock.Get(entry).VerifySet(x => x.AbsoluteExpiration = absoluteExpiration);
            Assert.Same(entry, result);
        }

        [Fact]
        public void SetSlidingExpiration()
        {
            // arrange
            var entry = Mock.Of<ICacheEntry>();
            var slidingExpiration = TimeSpan.FromMinutes(1);

            // act
            var result = entry.SetSlidingExpiration(slidingExpiration);

            // assert
            Mock.Get(entry).VerifySet(x => x.SlidingExpiration = slidingExpiration);
            Assert.Same(entry, result);
        }

        [Fact]
        public void SetPriority()
        {
            // arrange
            var entry = Mock.Of<ICacheEntry>();
            var priority = CachePriority.Normal;

            // act
            var result = entry.SetPriority(priority);

            // assert
            Mock.Get(entry).VerifySet(x => x.Priority = priority);
            Assert.Same(entry, result);
        }

        [Fact]
        public async Task ContinueWithOnEvicted()
        {
            // arrange
            var entry = Mock.Of<ICacheEntry>();
            var result = Task.FromResult(new CacheEvictionArgs(entry, EvictionCause.Replaced));
            Mock.Get(entry).SetupGet(x => x.Evicted).Returns(result);

            // act
            var completed = false;
            entry.ContinueWithOnEvicted(t => completed = true, CancellationToken.None);

            // assert
            await Task.Delay(100).ConfigureAwait(false);
            Assert.True(completed);
        }

        [Fact]
        public async Task ContinueWithOnEvictedWithState()
        {
            // arrange
            var entry = Mock.Of<ICacheEntry>();
            var result = Task.FromResult(new CacheEvictionArgs(entry, EvictionCause.Replaced));
            Mock.Get(entry).SetupGet(x => x.Evicted).Returns(result);

            // act
            var completed = false;
            var input = new object();
            object? output = null;
            entry.ContinueWithOnEvicted((t, s) => { completed = true; output = s; }, input, CancellationToken.None);

            // assert
            await Task.Delay(100).ConfigureAwait(false);
            Assert.True(completed);
            Assert.Same(input, output);
        }
    }
}