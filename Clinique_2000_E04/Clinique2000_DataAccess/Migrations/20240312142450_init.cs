using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseID);
                });

            migrationBuilder.CreateTable(
                name: "AdressesQuebec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProvinceAbbr = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TimeZone = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdressesQuebec", x => x.Id);
                });

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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstApprouvee = table.Column<bool>(type: "bit", nullable: true),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "CliniqueRefusees",
                columns: table => new
                {
                    CliniqueRefuseeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClinique = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HeureOuverture = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFermeture = table.Column<TimeSpan>(type: "time", nullable: false),
                    TempsMoyenConsultation = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdresseID = table.Column<int>(type: "int", nullable: false),
                    CreateurID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstApprouvee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CliniqueRefusees", x => x.CliniqueRefuseeID);
                    table.ForeignKey(
                        name: "FK_CliniqueRefusees_Adresses_AdresseID",
                        column: x => x.AdresseID,
                        principalTable: "Adresses",
                        principalColumn: "AdresseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CliniqueRefusees_AspNetUsers_CreateurID",
                        column: x => x.CreateurID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliniques",
                columns: table => new
                {
                    CliniqueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClinique = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HeureOuverture = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFermeture = table.Column<TimeSpan>(type: "time", nullable: false),
                    TempsMoyenConsultation = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdresseID = table.Column<int>(type: "int", nullable: false),
                    CreateurID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstApprouvee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliniques", x => x.CliniqueID);
                    table.ForeignKey(
                        name: "FK_Cliniques_Adresses_AdresseID",
                        column: x => x.AdresseID,
                        principalTable: "Adresses",
                        principalColumn: "AdresseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliniques_AspNetUsers_CreateurID",
                        column: x => x.CreateurID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAM = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployesClinique",
                columns: table => new
                {
                    EmployeCliniqueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeCliniqueNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeCliniquePrenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeCliniqueCourriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeCliniquePosition = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CliniqueID = table.Column<int>(type: "int", nullable: false),
                    CliniqueRefuseeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployesClinique", x => x.EmployeCliniqueID);
                    table.ForeignKey(
                        name: "FK_EmployesClinique_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployesClinique_CliniqueRefusees_CliniqueRefuseeID",
                        column: x => x.CliniqueRefuseeID,
                        principalTable: "CliniqueRefusees",
                        principalColumn: "CliniqueRefuseeID");
                    table.ForeignKey(
                        name: "FK_EmployesClinique_Cliniques_CliniqueID",
                        column: x => x.CliniqueID,
                        principalTable: "Cliniques",
                        principalColumn: "CliniqueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListeAttentes",
                columns: table => new
                {
                    ListeAttenteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOuverte = table.Column<bool>(type: "bit", nullable: false),
                    DateEffectivite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureOuverture = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFermeture = table.Column<TimeSpan>(type: "time", nullable: false),
                    NbMedecinsDispo = table.Column<int>(type: "int", nullable: false),
                    CliniqueID = table.Column<int>(type: "int", nullable: false),
                    CliniqueRefuseeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeAttentes", x => x.ListeAttenteID);
                    table.ForeignKey(
                        name: "FK_ListeAttentes_CliniqueRefusees_CliniqueRefuseeID",
                        column: x => x.CliniqueRefuseeID,
                        principalTable: "CliniqueRefusees",
                        principalColumn: "CliniqueRefuseeID");
                    table.ForeignKey(
                        name: "FK_ListeAttentes_Cliniques_CliniqueID",
                        column: x => x.CliniqueID,
                        principalTable: "Cliniques",
                        principalColumn: "CliniqueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientACharges",
                columns: table => new
                {
                    PatientAChargeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NAM = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientACharges", x => x.PatientAChargeId);
                    table.ForeignKey(
                        name: "FK_PatientACharges_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlagesHoraires",
                columns: table => new
                {
                    PlageHoraireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeureDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListeAttenteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlagesHoraires", x => x.PlageHoraireID);
                    table.ForeignKey(
                        name: "FK_PlagesHoraires_ListeAttentes_ListeAttenteID",
                        column: x => x.ListeAttenteID,
                        principalTable: "ListeAttentes",
                        principalColumn: "ListeAttenteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    ConsultationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeureDateDebutPrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureDateFinPrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureDateDebutReele = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeureDateFinReele = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatutConsultation = table.Column<int>(type: "int", nullable: false),
                    PlageHoraireID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    MedecinId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedecinEmployeCliniqueID = table.Column<int>(type: "int", nullable: true),
                    ListeAttenteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.ConsultationID);
                    table.ForeignKey(
                        name: "FK_Consultations_EmployesClinique_MedecinEmployeCliniqueID",
                        column: x => x.MedecinEmployeCliniqueID,
                        principalTable: "EmployesClinique",
                        principalColumn: "EmployeCliniqueID");
                    table.ForeignKey(
                        name: "FK_Consultations_ListeAttentes_ListeAttenteID",
                        column: x => x.ListeAttenteID,
                        principalTable: "ListeAttentes",
                        principalColumn: "ListeAttenteID");
                    table.ForeignKey(
                        name: "FK_Consultations_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_Consultations_PlagesHoraires_PlageHoraireID",
                        column: x => x.PlageHoraireID,
                        principalTable: "PlagesHoraires",
                        principalColumn: "PlageHoraireID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseID", "CodePostal", "Numero", "Pays", "Province", "Rue", "Ville" },
                values: new object[,]
                {
                    { 1, "J4G 2M6", "505", "Canada", "Québec", "Rue Adoncour", "Longueuil" },
                    { 2, "J4M 2X1", "1615", "Canada", "Québec", "Blvd Jacques-Cartier", "Longueuil" },
                    { 3, "J4K 1E2", "1144", "Canada", "Québec", "Rue Saint-Laurent", "Longueuil" },
                    { 4, "J4V 2H2", "3141", "Canada", "Québec", "Blvd Taschereau", "Longueuil" },
                    { 5, "H3B 4G1", "895", "Canada", "Québec", "Rue De la Gauchetiére", "Montreal" },
                    { 6, "J3Y 3P5", "5580", "Canada", "Québec", " Ch. de Chambly B", "Saint-Hubert" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EstApprouvee", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7cc96785-8933-4eac-8d7f-a289b28df211", 0, "3c74c0ab-180b-4394-ba89-637aebd6a5db", "ApplicationUser", "patient11@example.com", true, false, false, null, "PATIENT11@EXAMPLE.COM", "PATIENT11@EXAMPLE.COM", null, null, false, "2af0c341-3491-4abe-9a1b-0b58189b8fc7", false, "patient11@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df216", 0, "e7bdbc52-8f79-4cb2-8c8d-3abab194b655", "ApplicationUser", "patient16@example.com", true, false, false, null, "PATIENT16@EXAMPLE.COM", "PATIENT16@EXAMPLE.COM", null, null, false, "dae5a22e-dbee-4c9b-af82-cfe5b2df3649", false, "patient16@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df223", 0, "bcdd2735-5230-41f6-a386-80c865737405", "ApplicationUser", "patient1@example.com", true, false, false, null, "PATIENT1@EXAMPLE.COM", "PATIENT1@EXAMPLE.COM", null, null, false, "b20a66de-0e20-41e5-8660-da6ca77c45e8", false, "patient1@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df226", 0, "c6e94175-f4da-4857-8da8-7baed8481886", "ApplicationUser", "patient6@example.com", true, false, false, null, "PATIENT6@EXAMPLE.COM", "PATIENT6@EXAMPLE.COM", null, null, false, "3bba1705-021e-430c-bac0-d9794cfc0df3", false, "patient6@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d212", 0, "9284b9ea-87b1-49fa-89f6-323e7b2f0889", "ApplicationUser", "patient12@example.com", true, false, false, null, "PATIENT12@EXAMPLE.COM", "PATIENT12@EXAMPLE.COM", null, null, false, "591bd528-16de-48b5-9b34-86d5f79a597a", false, "patient12@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d217", 0, "399da1aa-aeb3-4179-805d-03e5c924b1a5", "ApplicationUser", "patient17@example.com", true, false, false, null, "PATIENT17@EXAMPLE.COM", "PATIENT17@EXAMPLE.COM", null, null, false, "1df8773b-fbf6-4430-9ba5-25223ff6eae4", false, "patient17@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2", 0, "6d269f3c-3557-4077-a878-f1cf168e60d8", "ApplicationUser", "patient2@example.com", true, false, false, null, "PATIENT2@EXAMPLE.COM", "PATIENT2@EXAMPLE.COM", null, null, false, "2edef3bf-1912-49c9-948d-507e69bb7bfb", false, "patient2@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7", 0, "d771053f-d62e-462d-a483-b478bb205ee4", "ApplicationUser", "patient7@example.com", true, false, false, null, "PATIENT7@EXAMPLE.COM", "PATIENT7@EXAMPLE.COM", null, null, false, "81599632-29a4-4d0e-ad4f-b0360d9c7e38", false, "patient7@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313", 0, "432af10e-0e7e-4c79-8fb9-e8a38316ca93", "ApplicationUser", "patient13@example.com", true, false, false, null, "PATIENT13@EXAMPLE.COM", "PATIENT13@EXAMPLE.COM", null, null, false, "c27bb2f0-50d5-414c-9849-6e67eda63d1d", false, "patient13@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318", 0, "ed3fcc49-2d88-405e-a252-677c84b7bf7d", "ApplicationUser", "patient18@example.com", true, false, false, null, "PATIENT18@EXAMPLE.COM", "PATIENT18@EXAMPLE.COM", null, null, false, "5c2a21f2-ab45-44fa-8b1f-31b279e94e5b", false, "patient18@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3", 0, "7112dc3b-3d6c-45ce-b964-cf6f7bad5ecf", "ApplicationUser", "patient3@example.com", true, false, false, null, "PATIENT3@EXAMPLE.COM", "PATIENT3@EXAMPLE.COM", null, null, false, "cc35fbd8-c264-425b-9bc1-dafb6b1cdd96", false, "patient3@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38", 0, "fc98c3ac-0878-4945-aaf7-49d39acd1409", "ApplicationUser", "patient8@example.com", true, false, false, null, "PATIENT8@EXAMPLE.COM", "PATIENT8@EXAMPLE.COM", null, null, false, "36ea2e34-87fb-457d-9ebb-a7a0bbff3e70", false, "patient8@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g22", 0, "444079d7-3d8c-4935-94c6-c150275fc70c", "ApplicationUser", "patient22@example.com", true, false, false, null, "PATIENT22@EXAMPLE.COM", "PATIENT22@EXAMPLE.COM", null, null, false, "a28d8993-c52d-4fb8-a389-8eb860ae5bfe", false, "patient22@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g410", 0, "9ed74ffb-91d9-4511-8103-16c8622f0b39", "ApplicationUser", "patient10@example.com", true, false, false, null, "PATIENT10@EXAMPLE.COM", "PATIENT10@EXAMPLE.COM", null, null, false, "280e3f27-7dac-46b1-8ece-a3e6401a67d4", false, "patient10@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g414", 0, "8e8676dd-71d1-462b-83cb-21410716bc67", "ApplicationUser", "patient14@example.com", true, false, false, null, "PATIENT14@EXAMPLE.COM", "PATIENT14@EXAMPLE.COM", null, null, false, "a52197c0-f4f3-45e1-94c5-b6d6dd7ceab2", false, "patient14@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g415", 0, "16adf863-6b7b-48a9-8582-33abf91747cf", "ApplicationUser", "patient15@example.com", true, false, false, null, "PATIENT15@EXAMPLE.COM", "PATIENT15@EXAMPLE.COM", null, null, false, "2e07ef93-51d1-4aa9-a5a6-16c0cf579f98", false, "patient15@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g419", 0, "2d286ca1-d6b3-4756-9286-93b3f447f7b8", "ApplicationUser", "patient19@example.com", true, false, false, null, "PATIENT19@EXAMPLE.COM", "PATIENT19@EXAMPLE.COM", null, null, false, "54585105-b504-48f8-b6b8-9e7f0e0d21d3", false, "patient19@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g420", 0, "45cd5f73-3f10-43b7-99de-2ac36238e30e", "ApplicationUser", "patient20@example.com", true, false, false, null, "PATIENT20@EXAMPLE.COM", "PATIENT20@EXAMPLE.COM", null, null, false, "952ec5fc-e57f-4524-a603-4c759babbc92", false, "patient20@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g421", 0, "572d9c50-2acf-4cf9-a41c-d398840364a0", "ApplicationUser", "patient21@example.com", true, false, false, null, "PATIENT21@EXAMPLE.COM", "PATIENT21@EXAMPLE.COM", null, null, false, "a8d8df8b-467d-4167-8108-dfbc9cbb06a2", false, "patient21@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g4", 0, "fc4b0b82-af2a-4f8d-a9e2-284ab44f0728", "ApplicationUser", "patient4@example.com", true, false, false, null, "PATIENT4@EXAMPLE.COM", "PATIENT4@EXAMPLE.COM", null, null, false, "fe4a15a4-031c-43ef-8eb7-600f368279f5", false, "patient4@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g5", 0, "713eeedb-1a95-4f4d-aed0-f30609d3989f", "ApplicationUser", "patient5@example.com", true, false, false, null, "PATIENT5@EXAMPLE.COM", "PATIENT5@EXAMPLE.COM", null, null, false, "58e910cd-c9b3-41e2-bdba-b83f3f599cfe", false, "patient5@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g9", 0, "96818d85-afe9-4a51-8e42-392191a35a08", "ApplicationUser", "patient9@example.com", true, false, false, null, "PATIENT9@EXAMPLE.COM", "PATIENT9@EXAMPLE.COM", null, null, false, "405edb97-b6b0-46e4-82a4-1a2c2144292e", false, "patient9@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "CliniqueID", "AdresseID", "Courriel", "CreateurID", "DateCreation", "DateModification", "EstActive", "EstApprouvee", "HeureFermeture", "HeureOuverture", "NomClinique", "NumTelephone", "TempsMoyenConsultation" },
                values: new object[,]
                {
                    { 1, 1, "contact@adoncour.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 3, 12, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8005), null, true, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique Adoncour", "(450) 646-4445", 30 },
                    { 2, 2, "contact@pboucher.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 3, 12, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8059), null, true, true, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique Pierre-Boucher", "(450) 468-6223", 30 },
                    { 3, 3, "contact@camu.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 3, 12, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8062), null, true, false, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique Medicale Urgence Camu", "(450) 679-4333", 20 },
                    { 4, 4, "contact@cigogne.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 3, 12, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8065), null, true, false, new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Medical Clinic GMF La Cigogne", "(450) 466-7892", 40 },
                    { 5, 5, "contact@cmenroute.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 3, 12, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8067), null, true, false, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique Medicale en Route", "(514) 954-1444", 10 },
                    { 6, 6, "contact@chambly.com", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 3, 12, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8069), null, true, false, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Centre Médical Chambly Latour", "(450) 926-2236", 15 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Age", "CodePostal", "DateDeNaissance", "Genre", "NAM", "Nom", "Prenom", "UserId" },
                values: new object[,]
                {
                    { 1, 32, "J4J 1Z4", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculin", "EASC 2342 4332", "Eastwood", "Clint", "7cc96785-8933-4eac-8d7f-a289b28df223" },
                    { 2, 27, "J4J 1V2", new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Féminin", "BLUE 4232 4332", "Blunt", "Emily", "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2" },
                    { 3, 36, "J4J 1G4", new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculin", "MARB 3244 2233", "Brando", "Marlon", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3" },
                    { 4, 44, "J4J 1H6", new DateTime(1980, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Féminin", "PORT 3443 3433", "Portman", "Natalie", "g4d0a589-2b02-4d36-9a85-39c028a4g4g4" },
                    { 5, 53, "V9S 1N2", new DateTime(1971, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "TREA 1234 4569", "Tremblay", "Anne", "g4d0a589-2b02-4d36-9a85-39c028a4g4g5" },
                    { 6, 28, "C1U 7Y0", new DateTime(1996, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "LAVJ 1234 4570", "Lavoie", "Jean", "7cc96785-8933-4eac-8d7f-a289b28df226" },
                    { 7, 33, "T5E 4Z2", new DateTime(1991, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "GAGA 1234 4571", "Gagnon", "Andrew", "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7" },
                    { 8, 42, "E9C 8W3", new DateTime(1982, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "GAUJ 1234 4572", "Gauthier", "Jean", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38" },
                    { 9, 29, "H4Z 0C5", new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "ROYS 1234 4573", "Roy", "Sophie", "g4d0a589-2b02-4d36-9a85-39c028a4g4g9" },
                    { 10, 74, "D2R 4Q3", new DateTime(1950, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "GAGJ 1234 4574", "Gagnon", "Julie", "g4d0a589-2b02-4d36-9a85-39c028a4g410" },
                    { 11, 46, "F1G 2H4", new DateTime(1978, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "BOUM 1234 4575", "Bouchard", "Martin", "7cc96785-8933-4eac-8d7f-a289b28df211" },
                    { 12, 36, "J3K 5L8", new DateTime(1988, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "COUA 1234 4576", "Couto", "Anne", "e2b8f367-6c94-4a3e-b5a6-45dabec4d212" },
                    { 13, 32, "K2L 6M8", new DateTime(1992, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "FORJ 1234 4577", "Fortin", "Julie", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313" },
                    { 14, 30, "X8F 4I7", new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "FORM 1234 4578", "Fortin", "Martin", "g4d0a589-2b02-4d36-9a85-39c028a4g414" },
                    { 15, 39, "S9K 3Z3", new DateTime(1985, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "MORC 1234 4579", "Morin", "Claire", "g4d0a589-2b02-4d36-9a85-39c028a4g415" },
                    { 16, 39, "H3N 3Z8", new DateTime(1985, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "ROYC 1234 4580", "Roy", "Claire", "7cc96785-8933-4eac-8d7f-a289b28df216" },
                    { 17, 66, "M1F 6Z2", new DateTime(1958, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "GAUL 1234 4581", "Gauthier", "Louis", "e2b8f367-6c94-4a3e-b5a6-45dabec4d217" },
                    { 18, 74, "G3W 7Q1", new DateTime(1950, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "COUM 1234 4582", "Couto", "Marie", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318" },
                    { 19, 49, "D1D 3D9", new DateTime(1975, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "MORM 1234 4583", "Morin", "Michel", "g4d0a589-2b02-4d36-9a85-39c028a4g419" },
                    { 20, 69, "M4F 2S8", new DateTime(1955, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "ROYM 1234 4584", "Roy", "Martin", "g4d0a589-2b02-4d36-9a85-39c028a4g420" },
                    { 21, 70, "M4F 2S8", new DateTime(1954, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "ROYM 1234 4585", "Roy", "Matheo", "g4d0a589-2b02-4d36-9a85-39c028a4g421" }
                });

            migrationBuilder.InsertData(
                table: "EmployesClinique",
                columns: new[] { "EmployeCliniqueID", "CliniqueID", "CliniqueRefuseeID", "EmployeCliniqueCourriel", "EmployeCliniqueNom", "EmployeCliniquePosition", "EmployeCliniquePrenom", "UserID" },
                values: new object[,]
                {
                    { 1, 1, null, "numcliniquetest@gmail.com", "Tremblay", 0, "Mark", null },
                    { 2, 1, null, "testproject2132@gmail.com", "Dubois", 0, "Monique", null },
                    { 3, 1, null, "sylviebeton98@gmail.com", "Beton", 1, "Sylvie", null },
                    { 4, 1, null, "clinique597@gmail.com", "Bostan", 1, "Max", null }
                });

            migrationBuilder.InsertData(
                table: "ListeAttentes",
                columns: new[] { "ListeAttenteID", "CliniqueID", "CliniqueRefuseeID", "DateEffectivite", "HeureFermeture", "HeureOuverture", "IsOuverte", "NbMedecinsDispo" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 3, 13, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8162), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 2, 2, null, new DateTime(2024, 3, 13, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8177), new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 1 },
                    { 3, 3, null, new DateTime(2024, 3, 13, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8185), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 4, 4, null, new DateTime(2024, 3, 13, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8192), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 5, 5, null, new DateTime(2024, 3, 13, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8200), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 6, 6, null, new DateTime(2024, 3, 13, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8209), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 7, 2, null, new DateTime(2024, 3, 14, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8216), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 8, 2, null, new DateTime(2024, 3, 14, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8223), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 9, 3, null, new DateTime(2024, 3, 14, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8230), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 10, 4, null, new DateTime(2024, 3, 16, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8239), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 11, 4, null, new DateTime(2024, 3, 17, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8246), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 2 },
                    { 12, 4, null, new DateTime(2024, 3, 18, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8253), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 3 },
                    { 13, 5, null, new DateTime(2024, 3, 15, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8260), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 14, 6, null, new DateTime(2024, 3, 16, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8267), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 15, 1, null, new DateTime(2024, 3, 15, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8274), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 2 },
                    { 16, 5, null, new DateTime(2024, 3, 16, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8282), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 17, 5, null, new DateTime(2024, 3, 17, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8290), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 2 },
                    { 18, 5, null, new DateTime(2024, 3, 18, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8298), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 3 },
                    { 19, 6, null, new DateTime(2024, 3, 13, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8305), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 20, 6, null, new DateTime(2024, 3, 14, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8312), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 21, 6, null, new DateTime(2024, 3, 15, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8319), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 22, 6, null, new DateTime(2024, 3, 16, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8326), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 23, 6, null, new DateTime(2024, 3, 17, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8332), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 2 },
                    { 24, 6, null, new DateTime(2024, 3, 18, 10, 24, 50, 277, DateTimeKind.Local).AddTicks(8339), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 3 }
                });

            migrationBuilder.InsertData(
                table: "PlagesHoraires",
                columns: new[] { "PlageHoraireID", "HeureDebut", "HeureFin", "ListeAttenteID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 13, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 2, new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 4, new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 5, new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 6, new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 7, new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 11, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 8, new DateTime(2024, 3, 13, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 12, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 9, new DateTime(2024, 3, 13, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 10, new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 11, new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 12, new DateTime(2024, 3, 13, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 17, 30, 0, 0, DateTimeKind.Local), 1 }
                });

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "ConsultationID", "HeureDateDebutPrevue", "HeureDateDebutReele", "HeureDateFinPrevue", "HeureDateFinReele", "ListeAttenteID", "MedecinEmployeCliniqueID", "MedecinId", "PatientID", "PlageHoraireID", "StatutConsultation" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 13, 8, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 1, 1, 2 },
                    { 2, new DateTime(2024, 3, 13, 8, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 2, 1, 2 },
                    { 3, new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 3, 2, 2 },
                    { 4, new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 4, 2, 2 },
                    { 5, new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 5, 3, 2 },
                    { 6, new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 6, 3, 2 },
                    { 7, new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 7, 4, 2 },
                    { 8, new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 8, 4, 2 },
                    { 9, new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 9, 5, 2 },
                    { 10, new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 10, 5, 2 },
                    { 11, new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 11, 6, 2 },
                    { 12, new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), null, null, null, null, null, 6, 6 },
                    { 13, new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 11, 30, 0, 0, DateTimeKind.Local), null, null, null, null, null, 7, 6 },
                    { 14, new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 11, 30, 0, 0, DateTimeKind.Local), null, null, null, null, null, 7, 6 },
                    { 15, new DateTime(2024, 3, 13, 12, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), null, null, null, null, null, 8, 6 },
                    { 16, new DateTime(2024, 3, 13, 12, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), null, null, null, null, null, 8, 6 },
                    { 17, new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), null, null, null, null, null, 9, 6 },
                    { 18, new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), null, null, null, null, null, 9, 6 },
                    { 19, new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local), null, null, null, null, null, 10, 6 },
                    { 20, new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local), null, null, null, null, null, 10, 6 },
                    { 21, new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 14, 0, 0, 0, DateTimeKind.Local), null, null, null, null, null, 11, 6 },
                    { 22, new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 14, 0, 0, 0, DateTimeKind.Local), null, null, null, null, null, 11, 6 },
                    { 23, new DateTime(2024, 3, 13, 15, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 15, 0, 0, 0, DateTimeKind.Local), null, null, null, null, null, 12, 6 },
                    { 24, new DateTime(2024, 3, 13, 16, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 3, 13, 17, 0, 0, 0, DateTimeKind.Local), null, null, null, null, null, 12, 6 }
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
                name: "IX_CliniqueRefusees_AdresseID",
                table: "CliniqueRefusees",
                column: "AdresseID");

            migrationBuilder.CreateIndex(
                name: "IX_CliniqueRefusees_CreateurID",
                table: "CliniqueRefusees",
                column: "CreateurID");

            migrationBuilder.CreateIndex(
                name: "IX_Cliniques_AdresseID",
                table: "Cliniques",
                column: "AdresseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliniques_CreateurID",
                table: "Cliniques",
                column: "CreateurID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_ListeAttenteID",
                table: "Consultations",
                column: "ListeAttenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedecinEmployeCliniqueID",
                table: "Consultations",
                column: "MedecinEmployeCliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientID",
                table: "Consultations",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PlageHoraireID",
                table: "Consultations",
                column: "PlageHoraireID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployesClinique_CliniqueID",
                table: "EmployesClinique",
                column: "CliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployesClinique_CliniqueRefuseeID",
                table: "EmployesClinique",
                column: "CliniqueRefuseeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployesClinique_UserID",
                table: "EmployesClinique",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ListeAttentes_CliniqueID",
                table: "ListeAttentes",
                column: "CliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_ListeAttentes_CliniqueRefuseeID",
                table: "ListeAttentes",
                column: "CliniqueRefuseeID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientACharges_PatientId",
                table: "PatientACharges",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlagesHoraires_ListeAttenteID",
                table: "PlagesHoraires",
                column: "ListeAttenteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdressesQuebec");

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
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "PatientACharges");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EmployesClinique");

            migrationBuilder.DropTable(
                name: "PlagesHoraires");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "ListeAttentes");

            migrationBuilder.DropTable(
                name: "CliniqueRefusees");

            migrationBuilder.DropTable(
                name: "Cliniques");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
