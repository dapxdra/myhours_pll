using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHoursApi.Migrations
{
    public partial class CambiodecolumnasenlosModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "project_user");

            migrationBuilder.DropColumn(
                name: "project_id",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "project_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "project_user",
                columns: table => new
                {
                    projects_id = table.Column<long>(type: "bigint", nullable: false),
                    users_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_project_user", x => new { x.projects_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_project_user_projects_projects_id",
                        column: x => x.projects_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_project_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_project_user_users_id",
                table: "project_user",
                column: "users_id");
        }
    }
}
