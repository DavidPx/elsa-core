using System;
using System.Threading.Tasks;
using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;

namespace Elsa.Samples.InterruptedActivity
{
    public class SlowActivity : Activity
    {
        protected override async ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
        {
            Console.WriteLine($"Starting my slow task.. {context.WorkflowInstance.Id}.{context.ActivityId}.  {DateTime.Now.TimeOfDay}");

            await Task.Delay(10000);

            Console.WriteLine($"Phew, I finished!  {context.WorkflowInstance.Id}. {context.ActivityId}.  {DateTime.Now.TimeOfDay}");

            return Done();
        }
    }
}
