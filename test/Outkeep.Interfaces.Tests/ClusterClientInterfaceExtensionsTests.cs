﻿using Moq;
using Orleans;
using System;
using Xunit;

namespace Outkeep.Interfaces.Tests
{
    public class ClusterClientInterfaceExtensionsTests
    {
        [Fact]
        public void GetCacheGrainReturnsCacheGrain()
        {
            var grain = Mock.Of<ICacheGrain>();
            var key = Guid.NewGuid().ToString();
            var client = Mock.Of<IClusterClient>(x => x.GetGrain<ICacheGrain>(key, null) == grain);

            var result = client.GetCacheGrain(key);

            Assert.Same(grain, result);
        }

        [Fact]
        public void GetCacheGrainThrowsOnNullClient()
        {
            IClusterClient client = null;

            Assert.Throws<ArgumentNullException>(nameof(client), () => client.GetCacheGrain("SomeKey"));
        }

        [Fact]
        public void GetEchoGrainReturnsEchoGrain()
        {
            var grain = Mock.Of<IEchoGrain>();
            var client = Mock.Of<IClusterClient>(x => x.GetGrain<IEchoGrain>(Guid.Empty, null) == grain);

            var result = client.GetEchoGrain();

            Assert.Same(grain, result);
        }

        [Fact]
        public void GetEchoGrainThrowsOnNullClient()
        {
            IClusterClient client = null;

            Assert.Throws<ArgumentNullException>(nameof(client), () => client.GetEchoGrain());
        }
    }
}