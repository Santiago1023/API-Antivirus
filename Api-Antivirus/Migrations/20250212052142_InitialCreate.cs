using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Antivirus.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "institutions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    url_general = table.Column<string>(type: "text", nullable: false),
                    url_academic_offers = table.Column<string>(type: "text", nullable: false),
                    url_wellbeing = table.Column<string>(type: "text", nullable: false),
                    url_admission = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "topics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bootcamps",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    information = table.Column<string>(type: "text", nullable: false),
                    costs = table.Column<string>(type: "text", nullable: false),
                    institution_id = table.Column<int>(type: "integer", nullable: true),
                    institutionid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bootcamps", x => x.id);
                    table.ForeignKey(
                        name: "FK_bootcamps_institutions_institutionid",
                        column: x => x.institutionid,
                        principalTable: "institutions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "opportunities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    observations = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    requirements = table.Column<string>(type: "text", nullable: false),
                    guide = table.Column<string>(type: "text", nullable: false),
                    additional_data = table.Column<string>(type: "text", nullable: false),
                    contact_channels = table.Column<string>(type: "text", nullable: false),
                    manager = table.Column<string>(type: "text", nullable: false),
                    modality = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: true),
                    categoryid = table.Column<int>(type: "integer", nullable: false),
                    institution_id = table.Column<int>(type: "integer", nullable: true),
                    institutionid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opportunities", x => x.id);
                    table.ForeignKey(
                        name: "FK_opportunities_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunities_institutions_institutionid",
                        column: x => x.institutionid,
                        principalTable: "institutions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bootcamp_topics",
                columns: table => new
                {
                    bootcamp_id = table.Column<int>(type: "integer", nullable: false),
                    topic_id = table.Column<int>(type: "integer", nullable: false),
                    bootcampid = table.Column<int>(type: "integer", nullable: false),
                    topicid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bootcamp_topics", x => new { x.bootcamp_id, x.topic_id });
                    table.ForeignKey(
                        name: "FK_bootcamp_topics_bootcamps_bootcampid",
                        column: x => x.bootcampid,
                        principalTable: "bootcamps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bootcamp_topics_topics_topicid",
                        column: x => x.topicid,
                        principalTable: "topics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "institution_bootcamps",
                columns: table => new
                {
                    institution_id = table.Column<int>(type: "integer", nullable: false),
                    bootcamp_id = table.Column<int>(type: "integer", nullable: false),
                    institutionid = table.Column<int>(type: "integer", nullable: false),
                    bootcampid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institution_bootcamps", x => new { x.institution_id, x.bootcamp_id });
                    table.ForeignKey(
                        name: "FK_institution_bootcamps_bootcamps_bootcampid",
                        column: x => x.bootcampid,
                        principalTable: "bootcamps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_institution_bootcamps_institutions_institutionid",
                        column: x => x.institutionid,
                        principalTable: "institutions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "opportunity_institutions",
                columns: table => new
                {
                    opportunity_id = table.Column<int>(type: "integer", nullable: false),
                    institution_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    opportunityid = table.Column<int>(type: "integer", nullable: false),
                    institutionid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opportunity_institutions", x => new { x.opportunity_id, x.institution_id });
                    table.ForeignKey(
                        name: "FK_opportunity_institutions_institutions_institutionid",
                        column: x => x.institutionid,
                        principalTable: "institutions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunity_institutions_opportunities_opportunityid",
                        column: x => x.opportunityid,
                        principalTable: "opportunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_opportunities",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    opportunity_id = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    opportunityid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_opportunities", x => new { x.user_id, x.opportunity_id });
                    table.ForeignKey(
                        name: "FK_user_opportunities_opportunities_opportunityid",
                        column: x => x.opportunityid,
                        principalTable: "opportunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_opportunities_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bootcamp_topics_bootcampid",
                table: "bootcamp_topics",
                column: "bootcampid");

            migrationBuilder.CreateIndex(
                name: "IX_bootcamp_topics_topicid",
                table: "bootcamp_topics",
                column: "topicid");

            migrationBuilder.CreateIndex(
                name: "IX_bootcamps_institutionid",
                table: "bootcamps",
                column: "institutionid");

            migrationBuilder.CreateIndex(
                name: "IX_institution_bootcamps_bootcampid",
                table: "institution_bootcamps",
                column: "bootcampid");

            migrationBuilder.CreateIndex(
                name: "IX_institution_bootcamps_institutionid",
                table: "institution_bootcamps",
                column: "institutionid");

            migrationBuilder.CreateIndex(
                name: "IX_opportunities_categoryid",
                table: "opportunities",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_opportunities_institutionid",
                table: "opportunities",
                column: "institutionid");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_institutions_institutionid",
                table: "opportunity_institutions",
                column: "institutionid");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_institutions_opportunityid",
                table: "opportunity_institutions",
                column: "opportunityid");

            migrationBuilder.CreateIndex(
                name: "IX_user_opportunities_opportunityid",
                table: "user_opportunities",
                column: "opportunityid");

            migrationBuilder.CreateIndex(
                name: "IX_user_opportunities_userid",
                table: "user_opportunities",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bootcamp_topics");

            migrationBuilder.DropTable(
                name: "institution_bootcamps");

            migrationBuilder.DropTable(
                name: "opportunity_institutions");

            migrationBuilder.DropTable(
                name: "user_opportunities");

            migrationBuilder.DropTable(
                name: "topics");

            migrationBuilder.DropTable(
                name: "bootcamps");

            migrationBuilder.DropTable(
                name: "opportunities");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "institutions");
        }
    }
}
