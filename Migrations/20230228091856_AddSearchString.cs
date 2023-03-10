using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapenexisLearners23.Migrations
{
    /// <inheritdoc />
    public partial class AddSearchString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LearnerIdNumber",
                table: "Learner",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LearnerIdNumber",
                table: "Learner",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
