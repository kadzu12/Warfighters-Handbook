using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warfighters.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "artifact",
                columns: table => new
                {
                    id_artifact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_artifact);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "set_artifact",
                columns: table => new
                {
                    id_set = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    image_set = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_set = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dungeon = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    incomplete_stat_bonus = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    full_stat_bonus = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_set);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "stats",
                columns: table => new
                {
                    id_stat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_stat = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start_number = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    max_number = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    type_stat = table.Column<string>(type: "char(3)", fixedLength: true, maxLength: 3, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_stat);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "weapon",
                columns: table => new
                {
                    id_weapon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    image_weapon = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_weapon = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type_weapon = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rarity_weapon = table.Column<int>(type: "int", nullable: false),
                    basic_attack = table.Column<int>(type: "int", nullable: false),
                    additional_stat = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passive_effect = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_weapon);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "artifact_stats",
                columns: table => new
                {
                    id_artifact = table.Column<int>(type: "int", nullable: false),
                    id_stat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_artifact, x.id_stat })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "fk_as_a",
                        column: x => x.id_artifact,
                        principalTable: "artifact",
                        principalColumn: "id_artifact");
                    table.ForeignKey(
                        name: "fk_as_s",
                        column: x => x.id_stat,
                        principalTable: "stats",
                        principalColumn: "id_stat");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    id_character = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    image_character = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_character = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    eye_god = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type_weapon = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rariry = table.Column<int>(type: "int", nullable: false),
                    id_signature_wepons = table.Column<int>(type: "int", nullable: false),
                    id_signature_set_artifact = table.Column<int>(type: "int", nullable: false),
                    count_views = table.Column<int>(type: "int", nullable: false),
                    main_dps = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sub_dps = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    support = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_character);
                    table.ForeignKey(
                        name: "fk_c_s",
                        column: x => x.id_signature_set_artifact,
                        principalTable: "set_artifact",
                        principalColumn: "id_set");
                    table.ForeignKey(
                        name: "fk_c_w",
                        column: x => x.id_signature_wepons,
                        principalTable: "weapon",
                        principalColumn: "id_weapon");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "characters_set",
                columns: table => new
                {
                    id_character = table.Column<int>(type: "int", nullable: false),
                    id_set = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_character, x.id_set })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "fk_cs_c",
                        column: x => x.id_character,
                        principalTable: "characters",
                        principalColumn: "id_character");
                    table.ForeignKey(
                        name: "fk_cs_s",
                        column: x => x.id_set,
                        principalTable: "set_artifact",
                        principalColumn: "id_set");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "characters_weapon",
                columns: table => new
                {
                    id_character = table.Column<int>(type: "int", nullable: false),
                    id_weapon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_character, x.id_weapon })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "fk_cw_c",
                        column: x => x.id_character,
                        principalTable: "characters",
                        principalColumn: "id_character");
                    table.ForeignKey(
                        name: "fk_cw_w",
                        column: x => x.id_weapon,
                        principalTable: "weapon",
                        principalColumn: "id_weapon");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "constellation",
                columns: table => new
                {
                    id_constellation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_character = table.Column<int>(type: "int", nullable: false),
                    name_constellation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    constellation_level = table.Column<int>(type: "int", nullable: false),
                    description_constellation = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_constellation);
                    table.ForeignKey(
                        name: "fk_c_c",
                        column: x => x.id_character,
                        principalTable: "characters",
                        principalColumn: "id_character");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "recommended_stats",
                columns: table => new
                {
                    id_character = table.Column<int>(type: "int", nullable: false),
                    id_artifact = table.Column<int>(type: "int", nullable: false),
                    id_stat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_character, x.id_artifact, x.id_stat })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                    table.ForeignKey(
                        name: "FK_recommended_stats_artifact_id_artifact",
                        column: x => x.id_artifact,
                        principalTable: "artifact",
                        principalColumn: "id_artifact",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rs_c",
                        column: x => x.id_character,
                        principalTable: "characters",
                        principalColumn: "id_character");
                    table.ForeignKey(
                        name: "fk_rs_s",
                        column: x => x.id_stat,
                        principalTable: "stats",
                        principalColumn: "id_stat");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "talent",
                columns: table => new
                {
                    id_talent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_character = table.Column<int>(type: "int", nullable: false),
                    category_talent = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_talent = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_talent = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    priority_improvement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_talent);
                    table.ForeignKey(
                        name: "fk_t_c",
                        column: x => x.id_character,
                        principalTable: "characters",
                        principalColumn: "id_character");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "fk_as_s",
                table: "artifact_stats",
                column: "id_stat");

            migrationBuilder.CreateIndex(
                name: "fk_c_w",
                table: "characters",
                column: "id_signature_wepons");

            migrationBuilder.CreateIndex(
                name: "id_character_UNIQUE",
                table: "characters",
                column: "id_character",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "image_character_UNIQUE",
                table: "characters",
                column: "image_character",
                unique: true)
                .Annotation("MySql:IndexPrefixLength", new[] { 255 });

            migrationBuilder.CreateIndex(
                name: "IX_characters_id_signature_set_artifact",
                table: "characters",
                column: "id_signature_set_artifact");

            migrationBuilder.CreateIndex(
                name: "name_character_UNIQUE",
                table: "characters",
                column: "name_character",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_cs_s",
                table: "characters_set",
                column: "id_set");

            migrationBuilder.CreateIndex(
                name: "fk_cw_w",
                table: "characters_weapon",
                column: "id_weapon");

            migrationBuilder.CreateIndex(
                name: "description_constellation_UNIQUE",
                table: "constellation",
                column: "description_constellation",
                unique: true)
                .Annotation("MySql:IndexPrefixLength", new[] { 255 });

            migrationBuilder.CreateIndex(
                name: "fk_c_c",
                table: "constellation",
                column: "id_character");

            migrationBuilder.CreateIndex(
                name: "name_constellation_UNIQUE",
                table: "constellation",
                column: "name_constellation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_rs_a",
                table: "recommended_stats",
                column: "id_artifact");

            migrationBuilder.CreateIndex(
                name: "fk_rs_s",
                table: "recommended_stats",
                column: "id_stat");

            migrationBuilder.CreateIndex(
                name: "full_stat_bonus_UNIQUE",
                table: "set_artifact",
                column: "full_stat_bonus",
                unique: true)
                .Annotation("MySql:IndexPrefixLength", new[] { 255 });

            migrationBuilder.CreateIndex(
                name: "image_set_UNIQUE",
                table: "set_artifact",
                column: "image_set",
                unique: true)
                .Annotation("MySql:IndexPrefixLength", new[] { 255 });

            migrationBuilder.CreateIndex(
                name: "name_set_UNIQUE",
                table: "set_artifact",
                column: "name_set",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_stat_UNIQUE",
                table: "stats",
                column: "id_stat",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_t_c",
                table: "talent",
                column: "id_character");

            migrationBuilder.CreateIndex(
                name: "name_talent_UNIQUE",
                table: "talent",
                column: "name_talent",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_weapon_UNIQUE",
                table: "weapon",
                column: "id_weapon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "image_weapon_UNIQUE",
                table: "weapon",
                column: "image_weapon",
                unique: true)
                .Annotation("MySql:IndexPrefixLength", new[] { 255 });

            migrationBuilder.CreateIndex(
                name: "name_weapon_UNIQUE",
                table: "weapon",
                column: "name_weapon",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "artifact_stats");

            migrationBuilder.DropTable(
                name: "characters_set");

            migrationBuilder.DropTable(
                name: "characters_weapon");

            migrationBuilder.DropTable(
                name: "constellation");

            migrationBuilder.DropTable(
                name: "recommended_stats");

            migrationBuilder.DropTable(
                name: "talent");

            migrationBuilder.DropTable(
                name: "artifact");

            migrationBuilder.DropTable(
                name: "stats");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "set_artifact");

            migrationBuilder.DropTable(
                name: "weapon");
        }
    }
}
