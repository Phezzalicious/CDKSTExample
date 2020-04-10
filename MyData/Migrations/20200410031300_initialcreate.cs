﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyData.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competency",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    term_identifier = table.Column<string>(nullable: true),
                    prose_task_statement = table.Column<string>(nullable: true),
                    CompositeID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competency", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competency_Competency_CompositeID",
                        column: x => x.CompositeID,
                        principalTable: "Competency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeElement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    term_identifier = table.Column<string>(nullable: true),
                    cartesian_index = table.Column<int>(nullable: false),
                    semiotic_index = table.Column<int>(nullable: false),
                    descriptor = table.Column<string>(nullable: true),
                    etymology = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeElement", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    term_identifier = table.Column<string>(nullable: true),
                    cartesian_index = table.Column<int>(nullable: false),
                    descriptor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DispositionInstance",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    term_identifier = table.Column<string>(nullable: true),
                    cartesian_index = table.Column<int>(nullable: false),
                    descriptor = table.Column<string>(nullable: true),
                    CompetencyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositionInstance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DispositionInstance_Competency_CompetencyID",
                        column: x => x.CompetencyID,
                        principalTable: "Competency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeSkill",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    knowledgeID = table.Column<int>(nullable: true),
                    skillID = table.Column<int>(nullable: true),
                    AtomicID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeSkill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KnowledgeSkill_Competency_AtomicID",
                        column: x => x.AtomicID,
                        principalTable: "Competency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KnowledgeSkill_KnowledgeElement_knowledgeID",
                        column: x => x.knowledgeID,
                        principalTable: "KnowledgeElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KnowledgeSkill_SkillLevel_skillID",
                        column: x => x.skillID,
                        principalTable: "SkillLevel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DispositionInstance",
                columns: new[] { "ID", "CompetencyID", "cartesian_index", "descriptor", "term_identifier" },
                values: new object[,]
                {
                    { 1, null, 1, "With Initiative (Nwokeji, Stachel, & Holmes, 2019) / Self-Starter (Clear, 2017) Shows independence. Ability to assess and start activities independently without needing to be told what to do. Willing to take the lead, not waiting for others to start activities or wait for instructions.", "Proactive" },
                    { 2, null, 2, "Self-motivated (Clear, 2017) / Self-Directed (Nwokeji et al., 2019) Demonstrates determination to sustain efforts to continue tasks. Direction from others is not required to continue a task toward its desired ends.", "Self-Directed" },
                    { 3, null, 3, "With Passion (Nwokeji et al., 2019), (Clear, 2017) / Conviction (Gray, 2015) Strongly committed to and enthusiastic about the realization of the task or goal. Makes the compelling case for the success and benefits of task, project, team or means of achieving goals.", "Passionate" },
                    { 4, null, 4, "Purposefully engaged / Purposefulness (Nwokeji et al., 2019), (Clear, 2017) Goal-directed, intentionally acting and committed to achieve organizational and project goals. Reflects an attitude towards the organizational goals served by decisions, work or work products. e.g., Business acumen.", "Purpose-Driven" },
                    { 5, null, 5, "With Professionalism / Work ethic (Nwokeji et al., 2019) Reflecting qualities connected with trained and skilled people: Acting honestly, with integrity, commitment, determination and dedication to what is required to achieve a task.", "Professional" },
                    { 6, null, 6, "With Judgement / Discretion (Nwokeji et al., 2019) / Responsible (Clear, 2017) / Rectitude (Grey, 2015) Reflect on conditions and concerns, then acting according to what is appropriate to the situation. Making responsible assessments and taking actions using professional knowledge, experience, understanding and common sense. E.g., Responsibility, Professional astuteness (Grey, 2015).", "Responsible" },
                    { 7, null, 7, "Adaptable (Nwokeji et al., 2019) / Flexible (Clear, 2017) / Agile (Weber, 2017) Ability or willingness to adjust approach in response to changing conditions or needs.", "Adaptable" },
                    { 8, null, 8, "Collaborative (Weber, 2017) / Team Player (Clear, 2017) / Influencing (Nwokeji et al., 2019) Willingness to work with others; engaging appropriate involvement of other persons and organizations helpful to the task. Striving to be respectful and productive in achieving a common goal.", "Collaborative" },
                    { 9, null, 9, "Responsive (Weber, 2017) / Respectful (Clear, 2017) Reacting quickly and positively. Respecting the timing needs for communication and actions needed to achieve the goals of the work.", "Responsive" },
                    { 10, null, 10, "Attentive to Detail (Weber, 2017), (Nwokeji et al., 2019) Achieves thoroughness and accuracy when accomplishing a task through concern for relevant details.", "Meticulous" }
                });

            migrationBuilder.InsertData(
                table: "KnowledgeElement",
                columns: new[] { "ID", "cartesian_index", "descriptor", "etymology", "semiotic_index", "term_identifier" },
                values: new object[,]
                {
                    { 5, 5, "I wish this was a coke!", "It was just a mirage!", 5, "RC Cola" },
                    { 4, 4, "The Best Soda you Havent Heard OF", "Guarana", 4, "Bawls" },
                    { 1, 1, "Coca-Cola Revives and Sustains", "Ursus maritimus", 1, "Coke" },
                    { 2, 2, "That's What I Like' – Variety", "Marketing where Coke Doesnt", 2, "Pepsi" },
                    { 3, 3, "Do the Dew", "Spy vs Spy", 3, "Mountain Dew" }
                });

            migrationBuilder.InsertData(
                table: "SkillLevel",
                columns: new[] { "ID", "cartesian_index", "descriptor", "term_identifier" },
                values: new object[,]
                {
                    { 5, 5, "Present and defend opinions by making judgments about information, validity of ideas, or quality of work based on a set of criteria.", "Evaluating" },
                    { 1, 1, "Exhibit memory of previously learned materials by recalling facts, terms, basic concepts, and answers.", "Rembering" },
                    { 2, 2, "Demonstrate understanding of facts and ideas by organizing, comparing, translating, interpreting, giving descriptions, and stating main ideas.", "Understanding" },
                    { 3, 3, "Solve problems to new situations by applying acquired knowledge, facts, techniques and rules in a different way.", "Applying" },
                    { 4, 4, "Examine and break information into parts by identifying motives or causes. Make inferences and find evidence to support generalizations.", "Analyzing" },
                    { 6, 6, "Compile information together in a different way by combining elements in a new pattern or proposing alternative solutions.", "Creating" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competency_CompositeID",
                table: "Competency",
                column: "CompositeID");

            migrationBuilder.CreateIndex(
                name: "IX_DispositionInstance_CompetencyID",
                table: "DispositionInstance",
                column: "CompetencyID");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeSkill_AtomicID",
                table: "KnowledgeSkill",
                column: "AtomicID");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeSkill_knowledgeID",
                table: "KnowledgeSkill",
                column: "knowledgeID");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeSkill_skillID",
                table: "KnowledgeSkill",
                column: "skillID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispositionInstance");

            migrationBuilder.DropTable(
                name: "KnowledgeSkill");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Competency");

            migrationBuilder.DropTable(
                name: "KnowledgeElement");

            migrationBuilder.DropTable(
                name: "SkillLevel");
        }
    }
}