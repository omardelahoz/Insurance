using Insurance.Application.Contracts.Persistance.Common;
using Insurance.Application.Features.Policy;
using Insurance.Application.Features.Policy.Queries;
using Insurance.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.ApiQuery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PolicyController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var response = new Response<PolicyVm>();
            var query = new GetPolicyListQuery();

            response.ResultList = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetPolicies")]
        public async Task<ActionResult> GetPolicies(string param)
        {
            var response = new Response<PolicyVm>();
            var query = new GetPolicyQuery(param);

            response.ResultList = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
