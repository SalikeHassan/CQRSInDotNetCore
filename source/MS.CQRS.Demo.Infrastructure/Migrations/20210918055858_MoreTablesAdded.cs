using Microsoft.EntityFrameworkCore.Migrations;

namespace MS.CQRS.Demo.Infrastructure.Migrations
{
    public partial class MoreTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateAddress",
                schema: "candidate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "varchar(100)", nullable: true),
                    StateName = table.Column<string>(type: "varchar(100)", nullable: true),
                    PinCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAddress", x => x.Id);
                    table.ForeignKey(
                        name: "Candidate_FK_CandidateAddress_CandidateID",
                        column: x => x.CandidateId,
                        principalSchema: "candidate",
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "candidate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkillXref",
                schema: "candidate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkillXref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkillXref_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "candidate",
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateSkillXref_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "candidate",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAddress_CandidateId",
                schema: "candidate",
                table: "CandidateAddress",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillXref_CandidateId",
                schema: "candidate",
                table: "CandidateSkillXref",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillXref_SkillId",
                schema: "candidate",
                table: "CandidateSkillXref",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateAddress",
                schema: "candidate");

            migrationBuilder.DropTable(
                name: "CandidateSkillXref",
                schema: "candidate");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "candidate");
        }
    }
}
