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
                    Statut = table.Column<int>(type: "int", nullable: true),
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
                name: "DetailsConsultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotifRendezVous = table.Column<int>(type: "int", nullable: true),
                    Symptomes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Diagnostic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MedicamentsPrescrits = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EstAlergique = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsConsultation", x => x.Id);
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
                name: "ApiKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiKeys_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    Statut = table.Column<int>(type: "int", nullable: false),
                    HeurePauseDebut = table.Column<TimeSpan>(type: "time", nullable: true),
                    HeurePauseFin = table.Column<TimeSpan>(type: "time", nullable: true)
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
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    CliniqueID = table.Column<int>(type: "int", nullable: false)
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
                    HeurePauseDebut = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeurePauseFin = table.Column<TimeSpan>(type: "time", nullable: false),
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
                name: "Critiques",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CliniqueId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Critiques", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Critiques_Cliniques_CliniqueId",
                        column: x => x.CliniqueId,
                        principalTable: "Cliniques",
                        principalColumn: "CliniqueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Critiques_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "PatientACharges",
                columns: table => new
                {
                    PatientAChargeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAM = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
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
                    EmployeCliniqueID = table.Column<int>(type: "int", nullable: true),
                    DetailsConsultationId = table.Column<int>(type: "int", nullable: true),
                    ListeAttenteID = table.Column<int>(type: "int", nullable: true),
                    PatientAChargeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.ConsultationID);
                    table.ForeignKey(
                        name: "FK_Consultations_DetailsConsultation_DetailsConsultationId",
                        column: x => x.DetailsConsultationId,
                        principalTable: "DetailsConsultation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultations_EmployesClinique_EmployeCliniqueID",
                        column: x => x.EmployeCliniqueID,
                        principalTable: "EmployesClinique",
                        principalColumn: "EmployeCliniqueID");
                    table.ForeignKey(
                        name: "FK_Consultations_ListeAttentes_ListeAttenteID",
                        column: x => x.ListeAttenteID,
                        principalTable: "ListeAttentes",
                        principalColumn: "ListeAttenteID");
                    table.ForeignKey(
                        name: "FK_Consultations_PatientACharges_PatientAChargeId",
                        column: x => x.PatientAChargeId,
                        principalTable: "PatientACharges",
                        principalColumn: "PatientAChargeId");
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Statut", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7cc96785-8933-4eac-8d7f-a289b28df211", 0, "3e449e3b-725e-4291-9fb5-cb261d381a92", "ApplicationUser", "patient11@example.com", true, false, null, "PATIENT11@EXAMPLE.COM", "PATIENT11@EXAMPLE.COM", null, null, false, "23810788-b0da-4d13-9249-a34c1c002146", null, false, "patient11@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df216", 0, "207086f1-d6c4-432d-afa3-45881208ebfe", "ApplicationUser", "patient16@example.com", true, false, null, "PATIENT16@EXAMPLE.COM", "PATIENT16@EXAMPLE.COM", null, null, false, "12b8d98e-bfa9-415b-b5ed-022ad8e0d86a", null, false, "patient16@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df223", 0, "98ae5677-60fe-426f-a718-08f754aff286", "ApplicationUser", "patient1@example.com", true, false, null, "PATIENT1@EXAMPLE.COM", "PATIENT1@EXAMPLE.COM", null, null, false, "af7ff445-9a0d-4ecb-b57a-e55836fc43f5", null, false, "patient1@example.com" },
                    { "7cc96785-8933-4eac-8d7f-a289b28df226", 0, "31d23393-6abd-49e3-9a9b-497e7478e077", "ApplicationUser", "patient6@example.com", true, false, null, "PATIENT6@EXAMPLE.COM", "PATIENT6@EXAMPLE.COM", null, null, false, "913d23ec-2ac5-4a1c-a489-a0b129126344", null, false, "patient6@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d212", 0, "c604bd54-88ce-4a31-98c3-6c638b8540ea", "ApplicationUser", "patient12@example.com", true, false, null, "PATIENT12@EXAMPLE.COM", "PATIENT12@EXAMPLE.COM", null, null, false, "44de8102-aec0-4ea8-b8be-5a30c74d65a1", null, false, "patient12@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d217", 0, "3465d4ea-e98d-451c-8f4b-3a4bdc64c632", "ApplicationUser", "patient17@example.com", true, false, null, "PATIENT17@EXAMPLE.COM", "PATIENT17@EXAMPLE.COM", null, null, false, "6c081710-bf4d-4437-8ffa-ce9567d940ae", null, false, "patient17@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2", 0, "f4687f57-e82f-42b0-a2b0-11e06bf047ff", "ApplicationUser", "patient2@example.com", true, false, null, "PATIENT2@EXAMPLE.COM", "PATIENT2@EXAMPLE.COM", null, null, false, "b0e4321a-a2ec-4cf6-b3f4-d2449e233d1a", null, false, "patient2@example.com" },
                    { "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7", 0, "f5e70efb-8373-41cd-8c09-72bf0d18798d", "ApplicationUser", "patient7@example.com", true, false, null, "PATIENT7@EXAMPLE.COM", "PATIENT7@EXAMPLE.COM", null, null, false, "ba3b45c5-4312-4dd2-997d-faf305911bcc", null, false, "patient7@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313", 0, "56589863-d383-4b2d-abff-fb12e7fa8d3f", "ApplicationUser", "patient13@example.com", true, false, null, "PATIENT13@EXAMPLE.COM", "PATIENT13@EXAMPLE.COM", null, null, false, "6ee15b42-531a-4106-86db-923bdd1c4caf", null, false, "patient13@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318", 0, "ebabc570-d19f-470b-835a-50fb82d01e69", "ApplicationUser", "patient18@example.com", true, false, null, "PATIENT18@EXAMPLE.COM", "PATIENT18@EXAMPLE.COM", null, null, false, "a3ff3909-1c7f-463f-b4a4-be420a7cec4b", null, false, "patient18@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3", 0, "67df4031-78d4-4469-b3e3-7beec86af00e", "ApplicationUser", "patient3@example.com", true, false, null, "PATIENT3@EXAMPLE.COM", "PATIENT3@EXAMPLE.COM", null, null, false, "018700b1-6add-45f0-9c12-d37d21f2c199", null, false, "patient3@example.com" },
                    { "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38", 0, "ac8a6e20-f3f3-48b0-8eea-b7890e11e626", "ApplicationUser", "patient8@example.com", true, false, null, "PATIENT8@EXAMPLE.COM", "PATIENT8@EXAMPLE.COM", null, null, false, "d46852f0-6ef1-45b4-90f7-218e7454eeec", null, false, "patient8@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g22", 0, "98a60414-1fc3-462b-9e00-ddaa81156112", "ApplicationUser", "patient22@example.com", true, false, null, "PATIENT22@EXAMPLE.COM", "PATIENT22@EXAMPLE.COM", null, null, false, "f88f98ad-8de4-4689-a6de-97bc406820c8", null, false, "patient22@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g410", 0, "fcac022a-3c9c-49fa-8f05-722e008569c0", "ApplicationUser", "patient10@example.com", true, false, null, "PATIENT10@EXAMPLE.COM", "PATIENT10@EXAMPLE.COM", null, null, false, "b3f9121a-ec44-4ab5-a251-cbef2666eb45", null, false, "patient10@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g414", 0, "e9060bb4-58d2-40d1-a248-b9e97428d861", "ApplicationUser", "patient14@example.com", true, false, null, "PATIENT14@EXAMPLE.COM", "PATIENT14@EXAMPLE.COM", null, null, false, "1b1d23a6-f11f-4434-8ac3-f9eb879a68ed", null, false, "patient14@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g415", 0, "0ff90a3c-e125-4251-8232-9a3bad517804", "ApplicationUser", "patient15@example.com", true, false, null, "PATIENT15@EXAMPLE.COM", "PATIENT15@EXAMPLE.COM", null, null, false, "3f45a951-0111-47f1-bbd7-30639b8148a5", null, false, "patient15@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g419", 0, "805c657c-d8ea-483e-b7e4-2f8a761518c3", "ApplicationUser", "patient19@example.com", true, false, null, "PATIENT19@EXAMPLE.COM", "PATIENT19@EXAMPLE.COM", null, null, false, "0e3b8dfa-e7e9-4c70-a77f-d7374dd299c9", null, false, "patient19@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g420", 0, "d677ba0c-a5f6-4f2b-9b79-f3e1ec0d6b7d", "ApplicationUser", "patient20@example.com", true, false, null, "PATIENT20@EXAMPLE.COM", "PATIENT20@EXAMPLE.COM", null, null, false, "8d8c6d4e-85b2-42d4-9a53-d3e2ca8a4ac7", null, false, "patient20@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g421", 0, "82be0fa5-c430-471f-9886-7a5157ef6f13", "ApplicationUser", "patient21@example.com", true, false, null, "PATIENT21@EXAMPLE.COM", "PATIENT21@EXAMPLE.COM", null, null, false, "074e3699-d6fa-45b7-82a7-6184d4a8d3c1", null, false, "patient21@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g4", 0, "a98e1078-ca64-4b56-b31b-9e84641e7ae4", "ApplicationUser", "patient4@example.com", true, false, null, "PATIENT4@EXAMPLE.COM", "PATIENT4@EXAMPLE.COM", null, null, false, "ccde47c9-331c-4f81-b281-a655f89a7deb", null, false, "patient4@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g5", 0, "02106a9e-bde3-4240-992a-a670532d5648", "ApplicationUser", "patient5@example.com", true, false, null, "PATIENT5@EXAMPLE.COM", "PATIENT5@EXAMPLE.COM", null, null, false, "ae2110d3-51a7-4ce7-95ed-8d6d07fa3d57", null, false, "patient5@example.com" },
                    { "g4d0a589-2b02-4d36-9a85-39c028a4g4g9", 0, "968a484b-536d-4866-a4db-fa93b1689af2", "ApplicationUser", "patient9@example.com", true, false, null, "PATIENT9@EXAMPLE.COM", "PATIENT9@EXAMPLE.COM", null, null, false, "b9a2ba2f-82a5-4253-8d33-d31b724a5a61", null, false, "patient9@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "CliniqueID", "AdresseID", "Courriel", "CreateurID", "DateCreation", "DateModification", "EstActive", "HeureFermeture", "HeureOuverture", "HeurePauseDebut", "HeurePauseFin", "NomClinique", "NumTelephone", "Statut", "TempsMoyenConsultation" },
                values: new object[,]
                {
                    { 1, 1, "contact@adoncour.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 4, 3, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9207), null, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), "Clinique Adoncour", "(450) 646-4445", 1, 30 },
                    { 2, 2, "contact@pboucher.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 4, 3, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9262), null, true, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), "Clinique Pierre-Boucher", "(450) 468-6223", 1, 30 },
                    { 3, 3, "contact@camu.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 4, 3, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9265), null, true, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), "Clinique Medicale Urgence Camu", "(450) 679-4333", 0, 20 },
                    { 4, 4, "contact@cigogne.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 4, 3, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9268), null, true, new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), "Medical Clinic GMF La Cigogne", "(450) 466-7892", 0, 40 },
                    { 5, 5, "contact@cmenroute.ca", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 4, 3, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9270), null, true, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), "Clinique Medicale en Route", "(514) 954-1444", 0, 10 },
                    { 6, 6, "contact@chambly.com", "7cc96785-8933-4eac-8d7f-a289b28df223", new DateTime(2024, 4, 3, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9273), null, true, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), "Centre Médical Chambly Latour", "(450) 926-2236", 0, 15 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Age", "CodePostal", "Courriel", "DateDeNaissance", "Genre", "NAM", "Nom", "Prenom", "UserId" },
                values: new object[,]
                {
                    { 1, 32, "J4J 1Z4", null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculin", "EASC 2342 4332", "Eastwood", "Clint", "7cc96785-8933-4eac-8d7f-a289b28df223" },
                    { 2, 27, "J4J 1V2", null, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Féminin", "BLUE 4232 4332", "Blunt", "Emily", "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2" },
                    { 3, 36, "J4J 1G4", null, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculin", "MARB 3244 2233", "Brando", "Marlon", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3" },
                    { 4, 44, "J4J 1H6", null, new DateTime(1980, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Féminin", "PORT 3443 3433", "Portman", "Natalie", "g4d0a589-2b02-4d36-9a85-39c028a4g4g4" },
                    { 5, 53, "V9S 1N2", null, new DateTime(1971, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "TREA 1234 4569", "Tremblay", "Anne", "g4d0a589-2b02-4d36-9a85-39c028a4g4g5" },
                    { 6, 28, "C1U 7Y0", null, new DateTime(1996, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "LAVJ 1234 4570", "Lavoie", "Jean", "7cc96785-8933-4eac-8d7f-a289b28df226" },
                    { 7, 33, "T5E 4Z2", null, new DateTime(1991, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "GAGA 1234 4571", "Gagnon", "Andrew", "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7" },
                    { 8, 42, "E9C 8W3", null, new DateTime(1982, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "GAUJ 1234 4572", "Gauthier", "Jean", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38" },
                    { 9, 29, "H4Z 0C5", null, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "ROYS 1234 4573", "Roy", "Sophie", "g4d0a589-2b02-4d36-9a85-39c028a4g4g9" },
                    { 10, 74, "D2R 4Q3", null, new DateTime(1950, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "GAGJ 1234 4574", "Gagnon", "Julie", "g4d0a589-2b02-4d36-9a85-39c028a4g410" },
                    { 11, 46, "F1G 2H4", null, new DateTime(1978, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "BOUM 1234 4575", "Bouchard", "Martin", "7cc96785-8933-4eac-8d7f-a289b28df211" },
                    { 12, 36, "J3K 5L8", null, new DateTime(1988, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "COUA 1234 4576", "Couto", "Anne", "e2b8f367-6c94-4a3e-b5a6-45dabec4d212" },
                    { 13, 32, "K2L 6M8", null, new DateTime(1992, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "FORJ 1234 4577", "Fortin", "Julie", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313" },
                    { 14, 30, "X8F 4I7", null, new DateTime(1994, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "FORM 1234 4578", "Fortin", "Martin", "g4d0a589-2b02-4d36-9a85-39c028a4g414" },
                    { 15, 39, "S9K 3Z3", null, new DateTime(1985, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "MORC 1234 4579", "Morin", "Claire", "g4d0a589-2b02-4d36-9a85-39c028a4g415" },
                    { 16, 39, "H3N 3Z8", null, new DateTime(1985, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "ROYC 1234 4580", "Roy", "Claire", "7cc96785-8933-4eac-8d7f-a289b28df216" },
                    { 17, 66, "M1F 6Z2", null, new DateTime(1958, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "GAUL 1234 4581", "Gauthier", "Louis", "e2b8f367-6c94-4a3e-b5a6-45dabec4d217" },
                    { 18, 74, "G3W 7Q1", null, new DateTime(1950, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "COUM 1234 4582", "Couto", "Marie", "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318" },
                    { 19, 49, "D1D 3D9", null, new DateTime(1975, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "MORM 1234 4583", "Morin", "Michel", "g4d0a589-2b02-4d36-9a85-39c028a4g419" },
                    { 20, 69, "M4F 2S8", null, new DateTime(1955, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "ROYM 1234 4584", "Roy", "Martin", "g4d0a589-2b02-4d36-9a85-39c028a4g420" },
                    { 21, 70, "M4F 2S8", null, new DateTime(1954, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "ROYM 1234 4585", "Roy", "Matheo", "g4d0a589-2b02-4d36-9a85-39c028a4g421" }
                });

            migrationBuilder.InsertData(
                table: "EmployesClinique",
                columns: new[] { "EmployeCliniqueID", "CliniqueID", "EmployeCliniqueCourriel", "EmployeCliniqueNom", "EmployeCliniquePosition", "EmployeCliniquePrenom", "UserID" },
                values: new object[,]
                {
                    { 1, 1, "numcliniquetest@gmail.com", "Tremblay", 0, "Mark", null },
                    { 2, 1, "testproject2132@gmail.com", "Dubois", 0, "Monique", null },
                    { 3, 1, "sylviebeton98@gmail.com", "Beton", 1, "Sylvie", null },
                    { 4, 1, "clinique597@gmail.com", "Bostan", 1, "Max", null }
                });

            migrationBuilder.InsertData(
                table: "ListeAttentes",
                columns: new[] { "ListeAttenteID", "CliniqueID", "DateEffectivite", "HeureFermeture", "HeureOuverture", "HeurePauseDebut", "HeurePauseFin", "IsOuverte", "NbMedecinsDispo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 4, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9307), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 2 },
                    { 2, 2, new DateTime(2024, 4, 4, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9321), new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 1 },
                    { 3, 3, new DateTime(2024, 4, 4, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9330), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 2 },
                    { 4, 4, new DateTime(2024, 4, 4, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9339), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 3 },
                    { 5, 5, new DateTime(2024, 4, 4, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9348), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 2 },
                    { 6, 6, new DateTime(2024, 4, 4, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9358), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 3 },
                    { 7, 2, new DateTime(2024, 4, 5, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9366), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 2 },
                    { 8, 2, new DateTime(2024, 4, 5, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9375), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 3 },
                    { 9, 3, new DateTime(2024, 4, 5, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9384), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 2 },
                    { 10, 4, new DateTime(2024, 4, 7, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9394), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 3 },
                    { 11, 4, new DateTime(2024, 4, 8, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9403), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), false, 2 },
                    { 12, 4, new DateTime(2024, 4, 9, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9475), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), false, 3 },
                    { 13, 5, new DateTime(2024, 4, 6, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9486), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 2 },
                    { 14, 6, new DateTime(2024, 4, 7, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9495), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 3 },
                    { 15, 1, new DateTime(2024, 4, 6, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9504), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), false, 2 },
                    { 16, 5, new DateTime(2024, 4, 7, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9512), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 3 },
                    { 17, 5, new DateTime(2024, 4, 8, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9520), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), false, 2 },
                    { 18, 5, new DateTime(2024, 4, 9, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9531), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), false, 3 },
                    { 19, 6, new DateTime(2024, 4, 4, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9540), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 2 },
                    { 20, 6, new DateTime(2024, 4, 5, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9548), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 3 },
                    { 21, 6, new DateTime(2024, 4, 6, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9556), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 2 },
                    { 22, 6, new DateTime(2024, 4, 7, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9565), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), true, 3 },
                    { 23, 6, new DateTime(2024, 4, 8, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9573), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), false, 2 },
                    { 24, 6, new DateTime(2024, 4, 9, 10, 40, 12, 986, DateTimeKind.Local).AddTicks(9582), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), false, 3 }
                });

            migrationBuilder.InsertData(
                table: "PlagesHoraires",
                columns: new[] { "PlageHoraireID", "HeureDebut", "HeureFin", "ListeAttenteID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 4, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 8, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 2, new DateTime(2024, 4, 4, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 9, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, new DateTime(2024, 4, 4, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 9, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 4, new DateTime(2024, 4, 4, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 10, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 5, new DateTime(2024, 4, 4, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 10, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 6, new DateTime(2024, 4, 4, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 11, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 7, new DateTime(2024, 4, 4, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 11, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 8, new DateTime(2024, 4, 4, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 12, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 9, new DateTime(2024, 4, 4, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 12, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 10, new DateTime(2024, 4, 4, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 13, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 11, new DateTime(2024, 4, 4, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 13, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 12, new DateTime(2024, 4, 4, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 4, 4, 17, 30, 0, 0, DateTimeKind.Local), 1 }
                });

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "ConsultationID", "DetailsConsultationId", "EmployeCliniqueID", "HeureDateDebutPrevue", "HeureDateDebutReele", "HeureDateFinPrevue", "HeureDateFinReele", "ListeAttenteID", "PatientAChargeId", "PatientID", "PlageHoraireID", "StatutConsultation" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 4, 4, 8, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 8, 30, 0, 0, DateTimeKind.Local), null, null, null, 1, 1, 2 },
                    { 2, null, null, new DateTime(2024, 4, 4, 8, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 8, 30, 0, 0, DateTimeKind.Local), null, null, null, 2, 1, 2 },
                    { 3, null, null, new DateTime(2024, 4, 4, 8, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 9, 0, 0, 0, DateTimeKind.Local), null, null, null, 3, 2, 2 },
                    { 4, null, null, new DateTime(2024, 4, 4, 8, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 9, 0, 0, 0, DateTimeKind.Local), null, null, null, 4, 2, 2 },
                    { 5, null, null, new DateTime(2024, 4, 4, 9, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 9, 30, 0, 0, DateTimeKind.Local), null, null, null, 5, 3, 2 },
                    { 6, null, null, new DateTime(2024, 4, 4, 9, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 9, 30, 0, 0, DateTimeKind.Local), null, null, null, 6, 3, 2 },
                    { 7, null, null, new DateTime(2024, 4, 4, 9, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 10, 0, 0, 0, DateTimeKind.Local), null, null, null, 7, 4, 2 },
                    { 8, null, null, new DateTime(2024, 4, 4, 9, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 10, 0, 0, 0, DateTimeKind.Local), null, null, null, 8, 4, 2 },
                    { 9, null, null, new DateTime(2024, 4, 4, 10, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 10, 30, 0, 0, DateTimeKind.Local), null, null, null, 9, 5, 2 },
                    { 10, null, null, new DateTime(2024, 4, 4, 10, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 10, 30, 0, 0, DateTimeKind.Local), null, null, null, 10, 5, 2 },
                    { 11, null, null, new DateTime(2024, 4, 4, 10, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 11, 0, 0, 0, DateTimeKind.Local), null, null, null, 11, 6, 2 },
                    { 12, null, null, new DateTime(2024, 4, 4, 10, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 11, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 6, 6 },
                    { 13, null, null, new DateTime(2024, 4, 4, 11, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 11, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 7, 6 },
                    { 14, null, null, new DateTime(2024, 4, 4, 11, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 11, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 7, 6 },
                    { 15, null, null, new DateTime(2024, 4, 4, 12, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 12, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 8, 6 },
                    { 16, null, null, new DateTime(2024, 4, 4, 12, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 12, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 8, 6 },
                    { 17, null, null, new DateTime(2024, 4, 4, 12, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 13, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 9, 6 },
                    { 18, null, null, new DateTime(2024, 4, 4, 12, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 13, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 9, 6 },
                    { 19, null, null, new DateTime(2024, 4, 4, 13, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 13, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 10, 6 },
                    { 20, null, null, new DateTime(2024, 4, 4, 13, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 13, 30, 0, 0, DateTimeKind.Local), null, null, null, null, 10, 6 },
                    { 21, null, null, new DateTime(2024, 4, 4, 13, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 14, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 11, 6 },
                    { 22, null, null, new DateTime(2024, 4, 4, 13, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 14, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 11, 6 },
                    { 23, null, null, new DateTime(2024, 4, 4, 15, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 15, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 12, 6 },
                    { 24, null, null, new DateTime(2024, 4, 4, 16, 30, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 4, 4, 17, 0, 0, 0, DateTimeKind.Local), null, null, null, null, 12, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeys_UserId",
                table: "ApiKeys",
                column: "UserId",
                unique: true);

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
                name: "IX_Consultations_DetailsConsultationId",
                table: "Consultations",
                column: "DetailsConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_EmployeCliniqueID",
                table: "Consultations",
                column: "EmployeCliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_ListeAttenteID",
                table: "Consultations",
                column: "ListeAttenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientAChargeId",
                table: "Consultations",
                column: "PatientAChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientID",
                table: "Consultations",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PlageHoraireID",
                table: "Consultations",
                column: "PlageHoraireID");

            migrationBuilder.CreateIndex(
                name: "IX_Critiques_CliniqueId",
                table: "Critiques",
                column: "CliniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Critiques_PatientId",
                table: "Critiques",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployesClinique_CliniqueID",
                table: "EmployesClinique",
                column: "CliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployesClinique_UserID",
                table: "EmployesClinique",
                column: "UserID");

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
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "ApiKeys");

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
                name: "Critiques");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DetailsConsultation");

            migrationBuilder.DropTable(
                name: "EmployesClinique");

            migrationBuilder.DropTable(
                name: "PatientACharges");

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
