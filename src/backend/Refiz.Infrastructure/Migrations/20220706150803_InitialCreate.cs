using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Refiz.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    IDGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    KeyResource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IndexOrder = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groups", x => x.IDGroup);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    IDLanguage = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.IDLanguage);
                });

            migrationBuilder.CreateTable(
                name: "NotifySource",
                columns: table => new
                {
                    IDNotifySource = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifySource", x => x.IDNotifySource);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    IDRole = table.Column<int>(type: "int", nullable: false),
                    NameRole = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.IDRole);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    IDState = table.Column<byte>(type: "tinyint", nullable: false),
                    NameState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.IDState);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IDCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    IDLanguage = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.IDCountry);
                    table.ForeignKey(
                        name: "FK_countries_language",
                        column: x => x.IDLanguage,
                        principalTable: "Language",
                        principalColumn: "IDLanguage");
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDLanguage = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_settings_language",
                        column: x => x.IDLanguage,
                        principalTable: "Language",
                        principalColumn: "IDLanguage");
                });

            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    IDOrganisation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeOrg = table.Column<short>(type: "smallint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IDCountry = table.Column<int>(type: "int", nullable: false),
                    Phones = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SecureKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WebApi = table.Column<bool>(type: "bit", nullable: false),
                    SwVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AllowRestore = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.IDOrganisation);
                    table.ForeignKey(
                        name: "FK_Organisations_Countries",
                        column: x => x.IDCountry,
                        principalTable: "Country",
                        principalColumn: "IDCountry");
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    IDRegion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCountry = table.Column<int>(type: "int", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.IDRegion);
                    table.ForeignKey(
                        name: "FK_Regions_Countries",
                        column: x => x.IDCountry,
                        principalTable: "Country",
                        principalColumn: "IDCountry");
                });

            migrationBuilder.CreateTable(
                name: "Preparation",
                columns: table => new
                {
                    IDPreparation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDOrganisation = table.Column<int>(type: "int", nullable: false),
                    DateImport = table.Column<DateTime>(type: "datetime", nullable: false),
                    State = table.Column<short>(type: "smallint", nullable: false),
                    Data = table.Column<string>(type: "xml", nullable: false),
                    DateStateChange = table.Column<DateTime>(type: "datetime", nullable: false),
                    GuidBatch = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NrBatch = table.Column<int>(type: "int", nullable: false),
                    DataSync = table.Column<string>(type: "xml", nullable: true),
                    VersionXml = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparation", x => x.IDPreparation);
                    table.ForeignKey(
                        name: "FK_Preparations_Organisations",
                        column: x => x.IDOrganisation,
                        principalTable: "Organisation",
                        principalColumn: "IDOrganisation");
                });

            migrationBuilder.CreateTable(
                name: "entities",
                columns: table => new
                {
                    IDEntity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEntity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurnameEntity = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IDRole = table.Column<int>(type: "int", nullable: false),
                    IsFirm = table.Column<bool>(type: "bit", nullable: false),
                    FirmName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateActivated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDCountry = table.Column<int>(type: "int", nullable: false),
                    IDRegion = table.Column<int>(type: "int", nullable: true),
                    IDOrganisation = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entities", x => x.IDEntity);
                    table.ForeignKey(
                        name: "FK_entities_Countries",
                        column: x => x.IDCountry,
                        principalTable: "Country",
                        principalColumn: "IDCountry");
                    table.ForeignKey(
                        name: "FK_entities_Organisations",
                        column: x => x.IDOrganisation,
                        principalTable: "Organisation",
                        principalColumn: "IDOrganisation");
                    table.ForeignKey(
                        name: "FK_entities_Regions",
                        column: x => x.IDRegion,
                        principalTable: "Region",
                        principalColumn: "IDRegion");
                    table.ForeignKey(
                        name: "FK_entities_roles",
                        column: x => x.IDRole,
                        principalTable: "roles",
                        principalColumn: "IDRole");
                });

            migrationBuilder.CreateTable(
                name: "ActivateEntity",
                columns: table => new
                {
                    IDActivateEntity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEntity = table.Column<int>(type: "int", nullable: false),
                    DateExpired = table.Column<DateTime>(type: "datetime", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivateEntity", x => x.IDActivateEntity);
                    table.ForeignKey(
                        name: "FK_ActivateEntities_entities",
                        column: x => x.IDEntity,
                        principalTable: "entities",
                        principalColumn: "IDEntity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntitySetting",
                columns: table => new
                {
                    IDEntitySetting = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEntity = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<string>(type: "xml", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntitySetting", x => x.IDEntitySetting);
                    table.ForeignKey(
                        name: "FK_EntitySettings_entities",
                        column: x => x.IDEntity,
                        principalTable: "entities",
                        principalColumn: "IDEntity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    IDLog = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LogLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Msg = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    IDEntity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.IDLog);
                    table.ForeignKey(
                        name: "FK_Logs_Entities",
                        column: x => x.IDEntity,
                        principalTable: "entities",
                        principalColumn: "IDEntity");
                });

            migrationBuilder.CreateTable(
                name: "NotifyRecipient",
                columns: table => new
                {
                    IDNotifyRecipient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNotifySource = table.Column<int>(type: "int", nullable: false),
                    IDEntity = table.Column<int>(type: "int", nullable: false),
                    AsEmail = table.Column<bool>(type: "bit", nullable: false),
                    AsSms = table.Column<bool>(type: "bit", nullable: false),
                    LastDateNotified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyRecipient", x => x.IDNotifyRecipient);
                    table.ForeignKey(
                        name: "FK_NotifyRecipients_Entities",
                        column: x => x.IDEntity,
                        principalTable: "entities",
                        principalColumn: "IDEntity");
                    table.ForeignKey(
                        name: "FK_NotifyRecipients_NotifySources",
                        column: x => x.IDNotifySource,
                        principalTable: "NotifySource",
                        principalColumn: "IDNotifySource");
                });

            migrationBuilder.CreateTable(
                name: "registers",
                columns: table => new
                {
                    IDRegister = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateReg = table.Column<DateTime>(type: "datetime", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IDEntity = table.Column<int>(type: "int", nullable: false),
                    IDState = table.Column<byte>(type: "tinyint", nullable: false),
                    NameSubject = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CodeType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegNumber = table.Column<int>(type: "int", nullable: true),
                    DateChangeState = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDGroup = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registers", x => x.IDRegister);
                    table.ForeignKey(
                        name: "FK_registers_entities",
                        column: x => x.IDEntity,
                        principalTable: "entities",
                        principalColumn: "IDEntity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_registers_group",
                        column: x => x.IDGroup,
                        principalTable: "Group",
                        principalColumn: "IDGroup");
                    table.ForeignKey(
                        name: "FK_registers_states",
                        column: x => x.IDState,
                        principalTable: "states",
                        principalColumn: "IDState");
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    IDPhoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDRegister = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HashCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.IDPhoto);
                    table.ForeignKey(
                        name: "FK_Photos_Register",
                        column: x => x.IDRegister,
                        principalTable: "registers",
                        principalColumn: "IDRegister",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterHistory",
                columns: table => new
                {
                    IDRegisterHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDLog = table.Column<long>(type: "bigint", nullable: false),
                    IDRegister = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterHistory", x => x.IDRegisterHistory);
                    table.ForeignKey(
                        name: "FK_RegisterHistories_Logs",
                        column: x => x.IDLog,
                        principalTable: "Log",
                        principalColumn: "IDLog");
                    table.ForeignKey(
                        name: "FK_RegisterHistories_Registers",
                        column: x => x.IDRegister,
                        principalTable: "registers",
                        principalColumn: "IDRegister");
                });

            migrationBuilder.CreateIndex(
                name: "UK_ActivateEntities",
                table: "ActivateEntity",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UL_ActivateEntities_Entity",
                table: "ActivateEntity",
                column: "IDEntity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_IDLanguage",
                table: "Country",
                column: "IDLanguage");

            migrationBuilder.CreateIndex(
                name: "UK_countries",
                table: "Country",
                column: "CountryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entities_IDCountry",
                table: "entities",
                column: "IDCountry");

            migrationBuilder.CreateIndex(
                name: "IX_entities_IDOrganisation",
                table: "entities",
                column: "IDOrganisation");

            migrationBuilder.CreateIndex(
                name: "IX_entities_IDRegion",
                table: "entities",
                column: "IDRegion");

            migrationBuilder.CreateIndex(
                name: "IX_entities_IDRole",
                table: "entities",
                column: "IDRole");

            migrationBuilder.CreateIndex(
                name: "UK_entities_email",
                table: "entities",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntitySetting_IDEntity",
                table: "EntitySetting",
                column: "IDEntity");

            migrationBuilder.CreateIndex(
                name: "uk_groups_code",
                table: "Group",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_languages_code",
                table: "Language",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Log_IDEntity",
                table: "Log",
                column: "IDEntity");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyRecipient_IDEntity",
                table: "NotifyRecipient",
                column: "IDEntity");

            migrationBuilder.CreateIndex(
                name: "UK_NotifyRecipients",
                table: "NotifyRecipient",
                columns: new[] { "IDNotifySource", "IDEntity" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_NotifySources",
                table: "NotifySource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_IDCountry",
                table: "Organisation",
                column: "IDCountry");

            migrationBuilder.CreateIndex(
                name: "UK_Organisations_Code",
                table: "Organisation",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Organisations_Email",
                table: "Organisation",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Organisations_Name",
                table: "Organisation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_IDRegister",
                table: "Photo",
                column: "IDRegister");

            migrationBuilder.CreateIndex(
                name: "IX_Preparation_IDOrganisation",
                table: "Preparation",
                column: "IDOrganisation");

            migrationBuilder.CreateIndex(
                name: "UK_Preparations_Guid",
                table: "Preparation",
                column: "GuidBatch",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Region_IDCountry",
                table: "Region",
                column: "IDCountry");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterHistory_IDLog",
                table: "RegisterHistory",
                column: "IDLog");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterHistory_IDRegister",
                table: "RegisterHistory",
                column: "IDRegister");

            migrationBuilder.CreateIndex(
                name: "FK_registers_entities",
                table: "registers",
                column: "IDEntity");

            migrationBuilder.CreateIndex(
                name: "FK_registers_states",
                table: "registers",
                column: "IDState");

            migrationBuilder.CreateIndex(
                name: "IX_registers_IDGroup",
                table: "registers",
                column: "IDGroup");

            migrationBuilder.CreateIndex(
                name: "UK_registers",
                table: "registers",
                columns: new[] { "IDEntity", "RegNumber" },
                unique: true,
                filter: "[RegNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_settings_IDLanguage",
                table: "settings",
                column: "IDLanguage");

            migrationBuilder.CreateIndex(
                name: "PK_settings",
                table: "settings",
                columns: new[] { "Key", "IDLanguage" },
                unique: true,
                filter: "[IDLanguage] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivateEntity");

            migrationBuilder.DropTable(
                name: "EntitySetting");

            migrationBuilder.DropTable(
                name: "NotifyRecipient");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Preparation");

            migrationBuilder.DropTable(
                name: "RegisterHistory");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "NotifySource");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "registers");

            migrationBuilder.DropTable(
                name: "entities");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "Organisation");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
