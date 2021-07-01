using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.Builders;
using Elsa.Models;

namespace Elsa.Samples.InterruptedActivity
{
    public class TheWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .WithPersistenceBehavior(WorkflowPersistenceBehavior.ActivityExecuted)
                .StartWith<SlowActivity>();
        }
    }
}
