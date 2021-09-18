using Microsoft.EntityFrameworkCore.Migrations;

namespace MS.CQRS.Demo.Infrastructure.Migrations
{
    public partial class InitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "candidate");

            migrationBuilder.CreateTable(
                name: "Candidate",
                schema: "candidate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateContacts",
                schema: "candidate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 300, nullable: false),
                    Mobile = table.Column<string>(maxLength: 30, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateContacts", x => x.Id);
                    table.ForeignKey(
                        name: "Candidate_FK_CandidateContact_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "candidate",
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateContacts_CandidateId",
                schema: "candidate",
                table: "CandidateContacts",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateContacts",
                schema: "candidate");

            migrationBuilder.DropTable(
                name: "Candidate",
                schema: "candidate");
        }
    }
}
