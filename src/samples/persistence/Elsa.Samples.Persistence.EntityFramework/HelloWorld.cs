using Elsa.Activities.Console;
using Elsa.Builders;
using Elsa.Models;

namespace Elsa.Samples.Persistence.EntityFramework
{
    public class HelloWorld : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .WithPersistenceBehavior(WorkflowPersistenceBehavior.WorkflowBurst)
                .WriteLine("Hello World!");
        }
    }
}