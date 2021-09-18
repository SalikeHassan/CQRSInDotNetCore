using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MS.CQRS.Demo.Infrastructure.Query;
using static Microsoft.AspNetCore.Http.StatusCodes;
using MS.CQRS.Demo.Domain;
using MS.CQRS.Demo.Contract.Dtos.Request;
using MS.CQRS.Demo.Contract.Dtos.Response;
using MS.CQRS.Demo.Service.Command;
using AutoMapper;

namespace MS.CQRS.Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator mediator;

        public CandidateController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Candidate), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var response = await this.mediator.Send(new GetCandidateByIdQuery() { Id = id });

            if (response == null)
            {
                return this.NoContent();
            }

            return this.Ok(response);
        }

        [HttpGet("GetCandidateContacts")]
        [ProducesResponseType(typeof(IEnumerable<CandidateContact>), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<IActionResult> GetCandidateContacts([FromQuery] int candidateId)
        {
            var response = await this.mediator.Send(new GetCandidateContactsByIdQuery() { CandidateId = candidateId });

            if (response == null)
            {
                return this.NoContent();
            }

            return this.Ok(response);
        }

        [HttpGet("GetCandidateFullDetails")]
        [ProducesResponseType(typeof(CandidateDetailsResponse), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<IActionResult> GetCandidateFullDetails([FromQuery] int candidateId)
        {
            var response = await this.mediator.Send(new GetCandidateFullDetailsIdQuery() { CandidateId = candidateId });

            if (response == null)
            {
                return this.NoContent();
            }

            return this.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] CandidateRequest candidateRequest)
        {
            var response = await this.mediator.Send(new CreateCandidateAndContactCommand() { candidateRequest = candidateRequest });

            if (response == 0)
            {
                return this.NoContent();
            }

            return this.Ok(response);
        }
    }
}
