using Insurance.Application.Features.Policy;
using Insurance.Application.Features.Policy.Commands;
using Insurance.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.ApiCommand.Controllers
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

        [HttpPost]
        [Route("Save")]
        public async Task<ActionResult> Save(CreatePolicyCommand policy)
        {
            Response<PolicyVm> response = new Response<PolicyVm>();
            response.Result = await _mediator.Send(policy);

            return Ok(response);
        }
       
    }
}
