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
                name: "Cliniques",
                columns: table => new
                {
                    CliniqueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClinique = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HeureOuverture = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFermeture = table.Column<TimeSpan>(type: "time", nullable: false),
                    TempsMoyenConsultation = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdresseID = table.Column<int>(type: "int", nullable: false),
                    CreateurID = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Nom = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
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
                    DureeConsultationMinutes = table.Column<int>(type: "int", nullable: true),
                    CliniqueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeAttentes", x => x.ListeAttenteID);
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
                    PlageHoraireID = table.Column<int>(type: "int", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    ListeAttenteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.ConsultationID);
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
                        principalColumn: "PlageHoraireID");
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseID", "CodePostal", "Numero", "Pays", "Province", "Rue", "Ville" },
                values: new object[,]
                {
                    { 1, "H1H 1H1", "7-756", "Canada", "Québec", "rue de la Clinique", "Montréal" },
                    { 2, "A1A 1A1", "2-66", "Canada", "Québec", "rue de la Cegep", "Longueuil" },
                    { 3, "J1J 1J1", "123", "Canada", "Québec", "rue de la Santé", "Sherbrooke" },
                    { 4, "L2L 2L2", "456", "Canada", "Québec", "rue de l'Hôpital", "Laval" },
                    { 5, "G3G 3G3", "789", "Canada", "Québec", "rue de la Thérapie", "Gatineau" },
                    { 6, "Q4Q 4Q4", "012", "Canada", "Québec", "rue de la Médecine", "Québec" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7cc96785-8933-4eac-8d7f-a289b28df211", 0, "81d4e38a-c1ac-4ded-a0fe-029b4b185513", "ApplicationUser", "patient11@example.com", true, false, null, "PATIENT11@EXAMPLE.COM", "PATIENT11@EXAMPLE.COM", null, null, false, "6c27002c-1af8-4b20-9f46-cdbcc788d93b", false, "patient11@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df216", 0, "280091f6-ff8b-4330-bc52-e0aed5516d8e", "ApplicationUser", "patient16@example.com", true, false, null, "PATIENT16@EXAMPLE.COM", "PATIENT16@EXAMPLE.COM", null, null, false, "992af400-9118-4e52-8b0e-b15879459396", false, "patient16@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df223", 0, "5b9907c3-49c8-4d67-a69f-aa16cccee871", "ApplicationUser", "patient1@example.com", true, false, null, "PATIENT1@EXAMPLE.COM", "PATIENT1@EXAMPLE.COM", null, null, false, "ead8cd2e-8e7d-4a4e-a86f-ed3ba01dbbcf", false, "patient1@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df226", 0, "5bf58150-e872-4384-a1af-3613f4e2bd42", "ApplicationUser", "patient6@example.com", true, false, null, "PATIENT6@EXAMPLE.COM", "PATIENT6@EXAMPLE.COM", null, null, false, "4b202741-cd6f-48c5-bf23-9f0ad5a9fe87", false, "patient6@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d212", 0, "a1f97278-4cbc-4c16-8895-b445d38c7b40", "ApplicationUser", "patient12@example.com", true, false, null, "PATIENT12@EXAMPLE.COM", "PATIENT12@EXAMPLE.COM", null, null, false, "b2dc034f-dafd-4526-bfac-306a1bbfcf42", false, "patient12@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d217", 0, "cf5576b3-3008-41f6-9790-9609dfd7d37a", "ApplicationUser", "patient17@example.com", true, false, null, "PATIENT17@EXAMPLE.COM", "PATIENT17@EXAMPLE.COM", null, null, false, "c5ce915b-0cde-411c-8b60-69ec94fa7c8e", false, "patient17@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2", 0, "27eea71c-1365-4606-a8ab-423c7555efa7", "ApplicationUser", "patient2@example.com", true, false, null, "PATIENT2@EXAMPLE.COM", "PATIENT2@EXAMPLE.COM", null, null, false, "bdc5933a-e236-4a5f-9674-f97db26a15dd", false, "patient2@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7", 0, "99682662-6e46-4102-84f7-c8fa6d936878", "ApplicationUser", "patient7@example.com", true, false, null, "PATIENT7@EXAMPLE.COM", "PATIENT7@EXAMPLE.COM", null, null, false, "d8f44dbd-a2a6-42e7-9222-60caf1102f35", false, "patient7@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313", 0, "df4b61b0-7ae9-4c6b-8894-1f443baa949e", "ApplicationUser", "patient13@example.com", true, false, null, "PATIENT13@EXAMPLE.COM", "PATIENT13@EXAMPLE.COM", null, null, false, "bfc2e824-98bc-4f86-ab47-d77dd5759c11", false, "patient13@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318", 0, "26ff265c-bd6f-459a-8fb0-2d684c712269", "ApplicationUser", "patient18@example.com", true, false, null, "PATIENT18@EXAMPLE.COM", "PATIENT18@EXAMPLE.COM", null, null, false, "1c3729be-3c85-4d1a-9285-35009718c927", false, "patient18@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3", 0, "ca722a4c-1d1b-45ad-999b-5374926c3749", "ApplicationUser", "patient3@example.com", true, false, null, "PATIENT3@EXAMPLE.COM", "PATIENT3@EXAMPLE.COM", null, null, false, "c156c2af-737a-410d-aa6f-3a051412ca31", false, "patient3@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38", 0, "104c72ab-37b1-4c11-ae73-c28fb90b944c", "ApplicationUser", "patient8@example.com", true, false, null, "PATIENT8@EXAMPLE.COM", "PATIENT8@EXAMPLE.COM", null, null, false, "cdd06da2-469c-444c-9e53-2795cdcb5b33", false, "patient8@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g22", 0, "fd248814-9e17-46f9-b7da-6e02abfaea76", "ApplicationUser", "patient22@example.com", true, false, null, "PATIENT22@EXAMPLE.COM", "PATIENT22@EXAMPLE.COM", null, null, false, "4b24d931-12c0-4445-b527-b7ea3dbc021d", false, "patient22@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g410", 0, "dfc91aa8-f841-4874-b8c4-b875e6cfcb68", "ApplicationUser", "patient10@example.com", true, false, null, "PATIENT10@EXAMPLE.COM", "PATIENT10@EXAMPLE.COM", null, null, false, "6ead3bb8-e910-49c8-9247-42bb7b93562d", false, "patient10@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g414", 0, "feab6787-55c0-4dac-9251-704442f87691", "ApplicationUser", "patient14@example.com", true, false, null, "PATIENT14@EXAMPLE.COM", "PATIENT14@EXAMPLE.COM", null, null, false, "3a981fcc-5e12-4909-9a43-b3301f7e75dc", false, "patient14@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g415", 0, "0b8cdcdf-8a82-4ff7-bb2b-d002890091d4", "ApplicationUser", "patient15@example.com", true, false, null, "PATIENT15@EXAMPLE.COM", "PATIENT15@EXAMPLE.COM", null, null, false, "79ed1286-f4ff-43ba-bf39-e0ed2313af1c", false, "patient15@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g419", 0, "258f3b6b-6921-4f80-a231-6a2c80fe5e0d", "ApplicationUser", "patient19@example.com", true, false, null, "PATIENT19@EXAMPLE.COM", "PATIENT19@EXAMPLE.COM", null, null, false, "942a937b-7703-4b55-b8cf-29a03e86d205", false, "patient19@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g420", 0, "56ef53bb-fe20-481f-bbb4-b98fb7df06f7", "ApplicationUser", "patient20@example.com", true, false, null, "PATIENT20@EXAMPLE.COM", "PATIENT20@EXAMPLE.COM", null, null, false, "359f5de8-bc95-4194-9251-52644b551a00", false, "patient20@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g421", 0, "bf2f863e-b2ee-4805-bba1-7e5ec003a79b", "ApplicationUser", "patient21@example.com", true, false, null, "PATIENT21@EXAMPLE.COM", "PATIENT21@EXAMPLE.COM", null, null, false, "e7a30752-f969-41f8-81eb-1c31643515da", false, "patient21@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g4", 0, "c2797c86-d841-40d0-9aa1-0bf99a49306d", "ApplicationUser", "patient4@example.com", true, false, null, "PATIENT4@EXAMPLE.COM", "PATIENT4@EXAMPLE.COM", null, null, false, "52233d12-428a-4b3e-a58d-ae92deea2644", false, "patient4@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g5", 0, "5442af95-cd9d-442d-a756-c42466e60a5f", "ApplicationUser", "patient5@example.com", true, false, null, "PATIENT5@EXAMPLE.COM", "PATIENT5@EXAMPLE.COM", null, null, false, "c9c03e29-ad48-4359-9dcd-d304ed1d60b6", false, "patient5@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g9", 0, "15320e02-e0df-4930-bbd6-290786c09e8a", "ApplicationUser", "patient9@example.com", true, false, null, "PATIENT9@EXAMPLE.COM", "PATIENT9@EXAMPLE.COM", null, null, false, "aa89c8ee-65c2-4994-ae8c-39e04a833302", false, "patient9@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "CliniqueID", "AdresseID", "Courriel", "CreateurID", "DateCreation", "DateModification", "EstActive", "HeureFermeture", "HeureOuverture", "NomClinique", "NumTelephone", "TempsMoyenConsultation" },
                values: new object[,]
                {
                    { 1, 1, "test@clinique2000.com", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 1, 27, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6121), null, true, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique Médicale Horizon", "(438) 333-5555", 30 },
                    { 2, 2, "Test2@test.com", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 1, 27, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6168), null, true, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "CliniqueB", "(438) 333-7777", 30 },
                    { 3, 3, "contact@clinique3.com", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 1, 27, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6250), null, true, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique3", "(100) 100-1030", 30 },
                    { 4, 4, "contact@clinique4.com", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 1, 27, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6259), null, true, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique4", "(100) 100-1040", 30 },
                    { 5, 5, "contact@clinique5.com", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 1, 27, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6266), null, true, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique5", "(100) 100-1050", 30 },
                    { 6, 6, "contact@clinique6.com", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 1, 27, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6276), null, true, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Clinique6", "(100) 100-1060", 30 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Age", "CodePostal", "DateDeNaissance", "Genre", "NAM", "Nom", "Prenom", "UserId" },
                values: new object[,]
                {
                    { 1, 65, "U4O 0G3", new DateTime(1959, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM01", "Côté", "Sophie", "7cc96785-8933-4eac-8d7f-a289b28df223" },
                    { 2, 62, "T8D 6T5", new DateTime(1962, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM02", "Gagnon", "Sophie", "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2" },
                    { 3, 42, "L9A 3Z3", new DateTime(1982, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM03", "Gagné", "Louis", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3" },
                    { 4, 59, "H1R 9L8", new DateTime(1965, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM04", "Morin", "Sophie", "g4d0a589-2b02-4d36-9a85-39c028a4g4g4" },
                    { 5, 53, "V9S 1N2", new DateTime(1971, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM05", "Tremblay", "Anne", "g4d0a589-2b02-4d36-9a85-39c028a4g4g5" },
                    { 6, 28, "C1U 7Y0", new DateTime(1996, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM06", "Lavoie", "Jean", "7cc96785-8933-4eac-8d7f-a289b28df226" },
                    { 7, 33, "T5E 4Z2", new DateTime(1991, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM07", "Gagnon", "André", "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7" },
                    { 8, 42, "E9C 8W3", new DateTime(1982, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM08", "Gauthier", "Jean", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38" },
                    { 9, 29, "H4Z 0C5", new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM09", "Roy", "Sophie", "g4d0a589-2b02-4d36-9a85-39c028a4g4g9" },
                    { 10, 74, "D2R 4Q3", new DateTime(1950, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM10", "Gagnon", "Julie", "g4d0a589-2b02-4d36-9a85-39c028a4g410" },
                    { 11, 46, "F1G 2H4", new DateTime(1978, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM11", "Bouchard", "Martin", "7cc96785-8933-4eac-8d7f-a289b28df211" },
                    { 12, 36, "J3K 5L8", new DateTime(1988, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM12", "Côté", "Anne", "e2b8f367-6c94-4a3e-b5a6-45dabec4d212" },
                    { 13, 32, "K2L 6M8", new DateTime(1992, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM13", "Fortin", "Julie", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313" },
                    { 14, 30, "X8F 4I7", new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM14", "Fortin", "Martin", "g4d0a589-2b02-4d36-9a85-39c028a4g414" },
                    { 15, 39, "S9K 3Z3", new DateTime(1985, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM15", "Morin", "Claire", "g4d0a589-2b02-4d36-9a85-39c028a4g415" },
                    { 16, 39, "H3N 3Z8", new DateTime(1985, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM16", "Roy", "Claire", "7cc96785-8933-4eac-8d7f-a289b28df216" },
                    { 17, 66, "M1F 6Z2", new DateTime(1958, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "NAM17", "Gauthier", "Louis", "e2b8f367-6c94-4a3e-b5a6-45dabec4d217" },
                    { 18, 74, "G3W 7Q1", new DateTime(1950, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM18", "Côté", "Marie", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318" },
                    { 19, 49, "D1D 3D9", new DateTime(1975, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM19", "Morin", "Michel", "g4d0a589-2b02-4d36-9a85-39c028a4g419" },
                    { 20, 69, "M4F 2S8", new DateTime(1955, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM20", "Roy", "Martin", "g4d0a589-2b02-4d36-9a85-39c028a4g420" },
                    { 21, 70, "M4F 2S8", new DateTime(1954, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "NAM20", "Roy", "Matheo", "g4d0a589-2b02-4d36-9a85-39c028a4g421" }
                });

            migrationBuilder.InsertData(
                table: "ListeAttentes",
                columns: new[] { "ListeAttenteID", "CliniqueID", "DateEffectivite", "DureeConsultationMinutes", "HeureFermeture", "HeureOuverture", "IsOuverte", "NbMedecinsDispo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 28, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6293), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 2, 3, new DateTime(2024, 1, 29, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6305), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 3, 3, new DateTime(2024, 1, 30, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6314), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 4, 3, new DateTime(2024, 1, 31, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6321), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 5, 3, new DateTime(2024, 2, 1, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6328), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 2 },
                    { 6, 3, new DateTime(2024, 2, 2, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6336), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 3 },
                    { 7, 4, new DateTime(2024, 1, 28, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6345), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 8, 4, new DateTime(2024, 1, 29, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6352), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 9, 4, new DateTime(2024, 1, 30, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6360), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 10, 4, new DateTime(2024, 1, 31, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6369), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 11, 4, new DateTime(2024, 2, 1, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6376), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 2 },
                    { 12, 4, new DateTime(2024, 2, 2, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6383), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 3 },
                    { 13, 5, new DateTime(2024, 1, 28, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6390), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 14, 5, new DateTime(2024, 1, 29, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6397), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 15, 5, new DateTime(2024, 1, 30, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6405), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 16, 5, new DateTime(2024, 1, 31, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6414), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 17, 5, new DateTime(2024, 2, 1, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6421), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 2 },
                    { 18, 5, new DateTime(2024, 2, 2, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6430), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 3 },
                    { 19, 6, new DateTime(2024, 1, 28, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6437), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 20, 6, new DateTime(2024, 1, 29, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6444), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 21, 6, new DateTime(2024, 1, 30, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6481), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 2 },
                    { 22, 6, new DateTime(2024, 1, 31, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6492), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), true, 3 },
                    { 23, 6, new DateTime(2024, 2, 1, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6499), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 2 },
                    { 24, 6, new DateTime(2024, 2, 2, 23, 5, 35, 255, DateTimeKind.Local).AddTicks(6508), 30, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), false, 3 }
                });

            migrationBuilder.InsertData(
                table: "PlagesHoraires",
                columns: new[] { "PlageHoraireID", "HeureDebut", "HeureFin", "ListeAttenteID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 28, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 8, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 2, new DateTime(2024, 1, 28, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 9, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, new DateTime(2024, 1, 28, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 9, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 4, new DateTime(2024, 1, 28, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 10, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 5, new DateTime(2024, 1, 28, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 10, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 6, new DateTime(2024, 1, 28, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 11, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 7, new DateTime(2024, 1, 28, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 11, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 8, new DateTime(2024, 1, 28, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 12, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 9, new DateTime(2024, 1, 28, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 12, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 10, new DateTime(2024, 1, 28, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 13, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 11, new DateTime(2024, 1, 28, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 13, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 12, new DateTime(2024, 1, 28, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 28, 14, 0, 0, 0, DateTimeKind.Local), 1 }
                });

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "ConsultationID", "HeureDateDebutPrevue", "HeureDateDebutReele", "HeureDateFinPrevue", "HeureDateFinReele", "ListeAttenteID", "PatientID", "PlageHoraireID", "StatutConsultation" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 28, 8, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 8, 30, 0, 0, DateTimeKind.Local), null, null, 1, 1, 2 },
                    { 2, new DateTime(2024, 1, 28, 8, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 8, 30, 0, 0, DateTimeKind.Local), null, null, 2, 1, 2 },
                    { 3, new DateTime(2024, 1, 28, 8, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 9, 0, 0, 0, DateTimeKind.Local), null, null, 3, 2, 2 },
                    { 4, new DateTime(2024, 1, 28, 8, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 9, 0, 0, 0, DateTimeKind.Local), null, null, 4, 2, 2 },
                    { 5, new DateTime(2024, 1, 28, 9, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 9, 30, 0, 0, DateTimeKind.Local), null, null, 5, 3, 2 },
                    { 6, new DateTime(2024, 1, 28, 9, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 9, 30, 0, 0, DateTimeKind.Local), null, null, 6, 3, 2 },
                    { 7, new DateTime(2024, 1, 28, 9, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 10, 0, 0, 0, DateTimeKind.Local), null, null, 7, 4, 2 },
                    { 8, new DateTime(2024, 1, 28, 9, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 10, 0, 0, 0, DateTimeKind.Local), null, null, 8, 4, 2 },
                    { 9, new DateTime(2024, 1, 28, 10, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 10, 30, 0, 0, DateTimeKind.Local), null, null, 9, 5, 2 },
                    { 10, new DateTime(2024, 1, 28, 10, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 10, 30, 0, 0, DateTimeKind.Local), null, null, 10, 6, 2 },
                    { 11, new DateTime(2024, 1, 28, 10, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 11, 0, 0, 0, DateTimeKind.Local), null, null, 11, 7, 2 },
                    { 12, new DateTime(2024, 1, 28, 10, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 11, 0, 0, 0, DateTimeKind.Local), null, null, 12, 7, 2 },
                    { 13, new DateTime(2024, 1, 28, 11, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 11, 30, 0, 0, DateTimeKind.Local), null, null, 13, 8, 2 },
                    { 14, new DateTime(2024, 1, 28, 11, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 11, 30, 0, 0, DateTimeKind.Local), null, null, 14, 8, 2 },
                    { 15, new DateTime(2024, 1, 28, 12, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 12, 30, 0, 0, DateTimeKind.Local), null, null, 15, 9, 2 },
                    { 16, new DateTime(2024, 1, 28, 12, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 12, 30, 0, 0, DateTimeKind.Local), null, null, 16, 9, 2 },
                    { 17, new DateTime(2024, 1, 28, 12, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 13, 0, 0, 0, DateTimeKind.Local), null, null, 17, 10, 2 },
                    { 18, new DateTime(2024, 1, 28, 12, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 13, 0, 0, 0, DateTimeKind.Local), null, null, 18, 10, 2 },
                    { 19, new DateTime(2024, 1, 28, 13, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 13, 30, 0, 0, DateTimeKind.Local), null, null, 19, 11, 2 },
                    { 20, new DateTime(2024, 1, 28, 13, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 13, 30, 0, 0, DateTimeKind.Local), null, null, 20, 11, 2 },
                    { 21, new DateTime(2024, 1, 28, 13, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 1, 28, 14, 0, 0, 0, DateTimeKind.Local), null, null, 21, 12, 2 }
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
                name: "IX_Consultations_PatientID",
                table: "Consultations",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PlageHoraireID",
                table: "Consultations",
                column: "PlageHoraireID");

            migrationBuilder.CreateIndex(
                name: "IX_ListeAttentes_CliniqueID",
                table: "ListeAttentes",
                column: "CliniqueID");

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
                name: "PlagesHoraires");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "ListeAttentes");

            migrationBuilder.DropTable(
                name: "Cliniques");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
