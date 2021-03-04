using Microsoft.EntityFrameworkCore.Migrations;

namespace Elsa.Persistence.EntityFramework.PostgreSql.Migrations
{
    public partial class AddDefIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_Status_DefinitionId_Version",
                table: "WorkflowInstances",
                columns: new[] { "WorkflowStatus", "DefinitionId", "Version" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkflowInstance_Status_DefinitionId_Version",
                table: "WorkflowInstances");
        }
    }
}
