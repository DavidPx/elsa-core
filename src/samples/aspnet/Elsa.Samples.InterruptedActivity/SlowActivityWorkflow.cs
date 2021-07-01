using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elsa.Builders;

namespace Elsa.Samples.InterruptedActivity
{
    public class SlowActivityWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .WithPersistenceBehavior(Models.WorkflowPersistenceBehavior.ActivityExecuted)
                .StartWith<SlowActivity>()
                .Then<SlowActivity>();
        }
    }
}
