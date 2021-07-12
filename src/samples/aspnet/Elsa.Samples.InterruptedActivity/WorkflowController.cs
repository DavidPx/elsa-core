using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elsa.Persistence.Specifications.Bookmarks;
using Elsa.Services;

namespace Elsa.Samples.InterruptedActivity
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowDefinitionDispatcher dispatcher;

        public WorkflowController(IWorkflowDefinitionDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
        [HttpPost]
        public async Task<IActionResult> Start()
        {
            await dispatcher.DispatchAsync(
                new ExecuteWorkflowDefinitionRequest(nameof(SlowActivityWorkflow), CorrelationId: Guid.NewGuid().ToString()));

            //var result = await starter.BuildAndStartWorkflowAsync<SlowActivityWorkflow>();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Poke()
        {

            return Ok("ouch");
        }
    }
}
