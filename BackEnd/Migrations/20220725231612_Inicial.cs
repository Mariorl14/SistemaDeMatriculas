using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PLAN_ESTUDIO",
                columns: table => new
                {
                    ID_PLAN_ESTUDIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_PLAN_ESTDUIO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PLAN_EST__680979317DA2985E", x => x.ID_PLAN_ESTUDIO);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_USUARIO",
                columns: table => new
                {
                    ID_TIPO_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TIPO_USU__85A05968E5C690B5", x => x.ID_TIPO_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CURSO",
                columns: table => new
                {
                    ID_CURSO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_CURSO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CODIGO_CURSO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    PRECIO = table.Column<double>(type: "float", nullable: false),
                    CREDITOS = table.Column<int>(type: "int", nullable: false),
                    DURACION = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HORARIO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NATURALEZA_CURSO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ID_PLAN_ESTUDIO_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CURSO__9B4AE7986ACB66CF", x => x.ID_CURSO);
                    table.ForeignKey(
                        name: "FK__CURSO__ID_PLAN_E__267ABA7A",
                        column: x => x.ID_PLAN_ESTUDIO_FK,
                        principalTable: "PLAN_ESTUDIO",
                        principalColumn: "ID_PLAN_ESTUDIO");
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CONTRASENA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TELEFONO = table.Column<int>(type: "int", nullable: false),
                    CONFIRMAR_CONTRASENA = table.Column<bool>(type: "bit", nullable: false),
                    ID_TIPO_USUARIO_FK = table.Column<int>(type: "int", nullable: false),
                    ROL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__91136B906697E81C", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK__USUARIO__ID_TIPO__2B3F6F97",
                        column: x => x.ID_TIPO_USUARIO_FK,
                        principalTable: "TIPO_USUARIO",
                        principalColumn: "ID_TIPO_USUARIO");
                });

            migrationBuilder.CreateTable(
                name: "ESTUDIANTE",
                columns: table => new
                {
                    ID_ESTUDIANTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PRIMER_APELLIDO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SEGUNDO_APELLIDO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FECHA_NACIMIENTO = table.Column<DateTime>(type: "date", nullable: false),
                    GENERO = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    ID_USUARIO_FK = table.Column<int>(type: "int", nullable: false),
                    ID_PLAN_ESTUDIO_FK = table.Column<int>(type: "int", nullable: false),
                    ID_TIPO_USUARIO_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESTUDIAN__5598088036A6CE5D", x => x.ID_ESTUDIANTE);
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__ID_PL__2F10007B",
                        column: x => x.ID_PLAN_ESTUDIO_FK,
                        principalTable: "PLAN_ESTUDIO",
                        principalColumn: "ID_PLAN_ESTUDIO");
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__ID_TI__300424B4",
                        column: x => x.ID_TIPO_USUARIO_FK,
                        principalTable: "TIPO_USUARIO",
                        principalColumn: "ID_TIPO_USUARIO");
                    table.ForeignKey(
                        name: "FK__ESTUDIANT__ID_US__2E1BDC42",
                        column: x => x.ID_USUARIO_FK,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO");
                });

            migrationBuilder.CreateTable(
                name: "MATRICULA",
                columns: table => new
                {
                    ID_MATRICULA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FECHA_MATRICULA = table.Column<DateTime>(type: "date", nullable: false),
                    ID_ESTUDIANTE_FK = table.Column<int>(type: "int", nullable: false),
                    ID_PLAN_ESTUDIO_FK = table.Column<int>(type: "int", nullable: false),
                    ID_CURSO_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MATRICUL__09B08780303982ED", x => x.ID_MATRICULA);
                    table.ForeignKey(
                        name: "FK__MATRICULA__ID_CU__34C8D9D1",
                        column: x => x.ID_CURSO_FK,
                        principalTable: "CURSO",
                        principalColumn: "ID_CURSO");
                    table.ForeignKey(
                        name: "FK__MATRICULA__ID_ES__32E0915F",
                        column: x => x.ID_ESTUDIANTE_FK,
                        principalTable: "ESTUDIANTE",
                        principalColumn: "ID_ESTUDIANTE");
                    table.ForeignKey(
                        name: "FK__MATRICULA__ID_PL__33D4B598",
                        column: x => x.ID_PLAN_ESTUDIO_FK,
                        principalTable: "PLAN_ESTUDIO",
                        principalColumn: "ID_PLAN_ESTUDIO");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CURSO_ID_PLAN_ESTUDIO_FK",
                table: "CURSO",
                column: "ID_PLAN_ESTUDIO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTE_ID_PLAN_ESTUDIO_FK",
                table: "ESTUDIANTE",
                column: "ID_PLAN_ESTUDIO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTE_ID_TIPO_USUARIO_FK",
                table: "ESTUDIANTE",
                column: "ID_TIPO_USUARIO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIANTE_ID_USUARIO_FK",
                table: "ESTUDIANTE",
                column: "ID_USUARIO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MATRICULA_ID_CURSO_FK",
                table: "MATRICULA",
                column: "ID_CURSO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MATRICULA_ID_ESTUDIANTE_FK",
                table: "MATRICULA",
                column: "ID_ESTUDIANTE_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MATRICULA_ID_PLAN_ESTUDIO_FK",
                table: "MATRICULA",
                column: "ID_PLAN_ESTUDIO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ID_TIPO_USUARIO_FK",
                table: "USUARIO",
                column: "ID_TIPO_USUARIO_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MATRICULA");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CURSO");

            migrationBuilder.DropTable(
                name: "ESTUDIANTE");

            migrationBuilder.DropTable(
                name: "PLAN_ESTUDIO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "TIPO_USUARIO");
        }
    }
}
