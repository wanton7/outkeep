﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Orleans;
using Orleans.Concurrency;
using Outkeep.Api.Http.Controllers.V1;
using Outkeep.Caching;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Outkeep.Api.Http.Tests
{
    public class CacheControllerV1Tests
    {
        [Fact]
        public async Task GettingNonExistingKeyReturnsNoContent()
        {
            var key = Guid.NewGuid().ToString();
            var factory = Mock.Of<IGrainFactory>(x => x.GetGrain<ICacheGrain>(key, null).GetAsync() == new ValueTask<CachePulse>(CachePulse.None));
            var controller = new CacheController(factory);

            var result = await controller.GetAsync(key).ConfigureAwait(false);

            Mock.Get(factory).VerifyAll();
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public async Task GettingExistingKeyReturnsOk()
        {
            // arrange
            var key = Guid.NewGuid().ToString();
            byte[]? value = Guid.NewGuid().ToByteArray();
            var factory = Mock.Of<IGrainFactory>(x => x.GetGrain<ICacheGrain>(key, null).GetAsync() == new ValueTask<CachePulse>(new CachePulse(Guid.NewGuid(), value)));
            var controller = new CacheController(factory);

            // act
            var result = await controller.GetAsync(key).ConfigureAwait(false);

            // assert
            Mock.Get(factory).VerifyAll();
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var content = Assert.IsType<byte[]>(ok.Value);
            Assert.Same(value, content);
        }

        [Fact]
        public async Task SetsKeyContent()
        {
            var key = Guid.NewGuid().ToString();
            var value = Guid.NewGuid().ToByteArray();
            var absoluteExpiration = DateTimeOffset.UtcNow.AddHours(1);
            var slidingExpiration = TimeSpan.FromMinutes(1);
            var factory = Mock.Of<IGrainFactory>(x => x.GetGrain<ICacheGrain>(key, null).SetAsync(It.Is<Immutable<byte[]?>>(v => v.Value.SequenceEqual(value)), absoluteExpiration, slidingExpiration) == Task.CompletedTask);
            var controller = new CacheController(factory);

            var file = Mock.Of<IFormFile>(x => x.OpenReadStream() == new MemoryStream(value) && x.Length == value.Length);
            var result = await controller.SetAsync(key, absoluteExpiration, slidingExpiration, file).ConfigureAwait(false);

            Mock.Get(factory).VerifyAll();
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task RemovesKey()
        {
            var key = Guid.NewGuid().ToString();
            var factory = Mock.Of<IGrainFactory>(x => x.GetGrain<ICacheGrain>(key, null).RemoveAsync() == Task.CompletedTask);
            var controller = new CacheController(factory);

            var result = await controller.RemoveAsync(key).ConfigureAwait(false);

            Mock.Get(factory).VerifyAll();
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task RefreshesKey()
        {
            var key = Guid.NewGuid().ToString();
            var factory = Mock.Of<IGrainFactory>(x => x.GetGrain<ICacheGrain>(key, null).RefreshAsync() == Task.CompletedTask);
            var controller = new CacheController(factory);

            var result = await controller.RefreshAsync(key).ConfigureAwait(false);

            Mock.Get(factory).VerifyAll();
            Assert.IsType<OkResult>(result);
        }
    }
}