﻿using Microsoft.AspNetCore.Mvc;
using Orleans;
using Orleans.Runtime;
using Outkeep.Api.Http.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Outkeep.Api.Http.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/echo")]
    public class EchoV1Controller : ControllerBase
    {
        private readonly IGrainFactory factory;

        public EchoV1Controller(IGrainFactory factory)
        {
            this.factory = factory;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "Echo")]
        public async Task<ActionResult<EchoResponse>> GetAsync([FromQuery] EchoRequest model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var reply = await factory
                .GetEchoGrain()
                .EchoAsync(model.Message)
                .ConfigureAwait(false);

            return Ok(new EchoResponse
            {
                ActivityId = RequestContext.ActivityId,
                Message = reply,
                Version = "1"
            });
        }
    }

    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/echo")]
    public class EchoV2Controller : ControllerBase
    {
        private readonly IGrainFactory factory;

        public EchoV2Controller(IGrainFactory factory)
        {
            this.factory = factory;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "Echo")]
        public async Task<ActionResult<EchoResponse>> GetAsync([FromQuery] EchoRequest model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var reply = await factory
                .GetEchoGrain()
                .EchoAsync(model.Message)
                .ConfigureAwait(false);

            return Ok(new EchoResponse
            {
                ActivityId = RequestContext.ActivityId,
                Message = reply,
                Version = "2"
            });
        }
    }
}