using Elsa.ActivityResults;
using Elsa.Services.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Activity = Elsa.Services.Activity;

namespace Elsa.Samples.InterruptedActivity
{
    public class SlowActivity : Activity
    {
        protected override async ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
        {
            Trace.WriteLine($"Starting my slow task.. {context.WorkflowInstance.Id}.{context.ActivityId}.  {DateTime.Now.TimeOfDay}");
            //Trace.WriteLine("fioo");
            await Task.Delay(10000);

            Trace.WriteLine($"Phew, I finished!  {context.WorkflowInstance.Id}. {context.ActivityId}.  {DateTime.Now.TimeOfDay}");

            return Done();
        }
    }
}
