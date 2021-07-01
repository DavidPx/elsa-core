using System;
using System.Threading.Tasks;
using Elsa.Persistence;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.PostgreSql;
using Elsa.Persistence.Specifications.WorkflowInstances;
using Elsa.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Samples.InterruptedActivity
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddElsa(options => options
                    // Configure Elsa to use the Entity Framework Core persistence provider using one of the three available providers 
                    .UseEntityFrameworkPersistence(ef =>
                    {
                        ef.UsePostgreSql("Server=127.0.0.1;Port=5432;Database=elsa;User Id=postgres;Password=foobar;");
                    })
                    .AddConsoleActivities()
                    .AddWorkflowsFrom<Program>()
                    .AddActivitiesFrom<Program>()
                )
                .AddAutoMapperProfiles<Program>()
                .BuildServiceProvider();

            // Run startup actions (not needed when registering Elsa with a Host).
            var startupRunner = services.GetRequiredService<IStartupRunner>();
            await startupRunner.StartupAsync();

            // Get a workflow runner.
            var workflowRunner = services.GetRequiredService<IBuildsAndStartsWorkflow>();

            // Run the workflow.
            var runWorkflowResult = await workflowRunner.BuildAndStartWorkflowAsync<TheWorkflow>();
            var workflowInstance = runWorkflowResult.WorkflowInstance!;
            
            // Get a reference to the workflow instance store.
            var store = services.GetRequiredService<IWorkflowInstanceStore>();
            
            var loadedWorkflowInstance = await store.FindByIdAsync(workflowInstance.Id);
            Console.WriteLine(loadedWorkflowInstance);
        }
    }
}
