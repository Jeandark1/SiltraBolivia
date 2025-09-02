using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.CreateTable(
                name: "CargoSharingGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SharingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxVehicles = table.Column<int>(type: "int", nullable: true),
                    CurrentVehicles = table.Column<int>(type: "int", nullable: false),
                    TotalDistance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstimatedDuration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CostPerVehicle = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoSharingGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GeneralStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => 
                {
                    table.PrimaryKey("PK_DataUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BankAccountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_DataUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TermsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    TermsAcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataClients_DataUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ComercialName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NitId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeprecRegistration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MainActivity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LegalAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OperatingCities = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    OfficePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CorporateEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataCompanies_DataUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicenseCategory = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LicenseExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TermsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    PoliticsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    TermsAcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SalaryPerKm = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsAvailableForSharing = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    TotalTrips = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_DataUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_DataUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsPushSent = table.Column<bool>(type: "bit", nullable: false),
                    PushSentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_DataUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaterId = table.Column<int>(type: "int", nullable: false),
                    RatedId = table.Column<int>(type: "int", nullable: false),
                    RatingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceQualityRating = table.Column<int>(type: "int", nullable: true),
                    PunctualityRating = table.Column<int>(type: "int", nullable: true),
                    CommunicationRating = table.Column<int>(type: "int", nullable: true),
                    OverallRating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_DataUsers_RatedId",
                        column: x => x.RatedId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_DataUsers_RaterId",
                        column: x => x.RaterId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DocumentDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedById = table.Column<int>(type: "int", nullable: true),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_DataCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "DataCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_DataUsers_VerifiedById",
                        column: x => x.VerifiedById,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLegalRepresentatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLegalRepresentatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyLegalRepresentatives_DataCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "DataCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCompanyId = table.Column<int>(type: "int", nullable: true),
                    DataUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_DataCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "DataCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_DataCompanies_DataCompanyId",
                        column: x => x.DataCompanyId,
                        principalTable: "DataCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyUsers_DataUsers_DataUserId",
                        column: x => x.DataUserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyUsers_DataUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAgreement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    AgreementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractTerms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAgreement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAgreement_DataCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "DataCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriverDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DocumentDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedById = table.Column<int>(type: "int", nullable: true),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverDocuments_DataUsers_VerifiedById",
                        column: x => x.VerifiedById,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DriverDocuments_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PassengerCapacity = table.Column<int>(type: "int", nullable: false),
                    CargoCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperationalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastLocationUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedAvailabilityTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentRoute = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ScheduledDestination = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RentalRatePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RentalRatePerKm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsAvailableForRental = table.Column<bool>(type: "bit", nullable: false),
                    MaintenanceNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingId = table.Column<int>(type: "int", nullable: false),
                    FeedbackType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StatusFeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolutionNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_DataUsers_ResolvedBy",
                        column: x => x.ResolvedBy,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CargoLoads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    SharingGroupId = table.Column<int>(type: "int", nullable: true),
                    IsShared = table.Column<bool>(type: "bit", nullable: false),
                    CargoType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LoadCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricePerKm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSharingVehicles = table.Column<int>(type: "int", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickupDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CancelledById = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CargoSharingGroupId = table.Column<int>(type: "int", nullable: true),
                    DriverId1 = table.Column<int>(type: "int", nullable: true),
                    VehicleId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoLoads_CargoSharingGroups_CargoSharingGroupId",
                        column: x => x.CargoSharingGroupId,
                        principalTable: "CargoSharingGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoLoads_CargoSharingGroups_SharingGroupId",
                        column: x => x.SharingGroupId,
                        principalTable: "CargoSharingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CargoLoads_DataUsers_CancelledById",
                        column: x => x.CancelledById,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CargoLoads_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CargoLoads_Drivers_DriverId1",
                        column: x => x.DriverId1,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoLoads_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoLoads_Vehicles_VehicleId1",
                        column: x => x.VehicleId1,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DocumentDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedById = table.Column<int>(type: "int", nullable: true),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDocuments_DataUsers_VerifiedById",
                        column: x => x.VerifiedById,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleDocuments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRental",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RentalStartDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KmRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstimatedTotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualTotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecurityDeposit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RentalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalTerms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCompanyId = table.Column<int>(type: "int", nullable: true),
                    DriverId1 = table.Column<int>(type: "int", nullable: true),
                    VehicleId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleRental_DataCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "DataCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleRental_DataCompanies_DataCompanyId",
                        column: x => x.DataCompanyId,
                        principalTable: "DataCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleRental_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleRental_Drivers_DriverId1",
                        column: x => x.DriverId1,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleRental_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleRental_Vehicles_VehicleId1",
                        column: x => x.VehicleId1,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoLoadId = table.Column<int>(type: "int", nullable: true),
                    Participant1Id = table.Column<int>(type: "int", nullable: false),
                    Participant2Id = table.Column<int>(type: "int", nullable: false),
                    ConversationType = table.Column<int>(type: "int", nullable: true),
                    LastMessageAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_CargoLoads_CargoLoadId",
                        column: x => x.CargoLoadId,
                        principalTable: "CargoLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversations_DataUsers_Participant1Id",
                        column: x => x.Participant1Id,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversations_DataUsers_Participant2Id",
                        column: x => x.Participant2Id,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GpsTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    LoadId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Heading = table.Column<int>(type: "int", nullable: true),
                    Accuracy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpsTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GpsTrackings_CargoLoads_LoadId",
                        column: x => x.LoadId,
                        principalTable: "CargoLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GpsTrackings_DataUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GpsTrackings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageLoads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoLoadId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    PackageCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OriginAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OriginLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DestinationLatitudeSuggested = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DestinationLongitudeSuggested = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DestinationAddressSuggested = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DestinationLatitudeFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DestinationLongitudeFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DestinationAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DistanceFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricePerKm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SharingGroupId = table.Column<int>(type: "int", nullable: true),
                    CargoDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CargoWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateInit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackStatusProcess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageLoads_CargoLoads_CargoLoadId",
                        column: x => x.CargoLoadId,
                        principalTable: "CargoLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageLoads_CargoSharingGroups_SharingGroupId",
                        column: x => x.SharingGroupId,
                        principalTable: "CargoSharingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackageLoads_DataUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackageLoads_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RouteOptimization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoLoadId = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    OptimizedRouteJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDistance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstimatedDurationMinutes = table.Column<int>(type: "int", nullable: true),
                    FuelCostEstimate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FuelCostTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaypointsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CargoLoadId1 = table.Column<int>(type: "int", nullable: true),
                    VehicleId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteOptimization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteOptimization_CargoLoads_CargoLoadId",
                        column: x => x.CargoLoadId,
                        principalTable: "CargoLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteOptimization_CargoLoads_CargoLoadId1",
                        column: x => x.CargoLoadId1,
                        principalTable: "CargoLoads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RouteOptimization_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteOptimization_Vehicles_VehicleId1",
                        column: x => x.VehicleId1,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_DataUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageLoadId = table.Column<int>(type: "int", nullable: false),
                    PayerId = table.Column<int>(type: "int", nullable: false),
                    PayeeId = table.Column<int>(type: "int", nullable: false),
                    ImageQr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CommissionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StatusTransaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaymentGateway = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_DataUsers_PayeeId",
                        column: x => x.PayeeId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_DataUsers_PayerId",
                        column: x => x.PayerId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_PackageLoads_PackageLoadId",
                        column: x => x.PackageLoadId,
                        principalTable: "PackageLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageLoadId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StatusInvoice = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ElectronicInvoiceCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InvoiceFilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InvoiceType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ServiceAgreementId = table.Column<int>(type: "int", nullable: true),
                    VehicleRentalId = table.Column<int>(type: "int", nullable: true),
                    ServiceAgreementId1 = table.Column<int>(type: "int", nullable: true),
                    VehicleRentalId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeletionAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRegistry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDeletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_DataUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "DataUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_PackageLoads_PackageLoadId",
                        column: x => x.PackageLoadId,
                        principalTable: "PackageLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_ServiceAgreement_ServiceAgreementId",
                        column: x => x.ServiceAgreementId,
                        principalTable: "ServiceAgreement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_ServiceAgreement_ServiceAgreementId1",
                        column: x => x.ServiceAgreementId1,
                        principalTable: "ServiceAgreement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_VehicleRental_VehicleRentalId",
                        column: x => x.VehicleRentalId,
                        principalTable: "VehicleRental",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_VehicleRental_VehicleRentalId1",
                        column: x => x.VehicleRentalId1,
                        principalTable: "VehicleRental",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLoads_CancelledById",
                table: "CargoLoads",
                column: "CancelledById");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLoads_CargoSharingGroupId",
                table: "CargoLoads",
                column: "CargoSharingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLoads_DriverId",
                table: "CargoLoads",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLoads_DriverId1",
                table: "CargoLoads",
                column: "DriverId1");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLoads_LoadCode",
                table: "CargoLoads",
                column: "LoadCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CargoLoads_SharingGroupId",
                table: "CargoLoads",
                column: "SharingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLoads_VehicleId",
                table: "CargoLoads",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLoads_VehicleId1",
                table: "CargoLoads",
                column: "VehicleId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_CompanyId",
                table: "CompanyDocuments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_VerifiedById",
                table: "CompanyDocuments",
                column: "VerifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLegalRepresentatives_CompanyId",
                table: "CompanyLegalRepresentatives",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId_UserId",
                table: "CompanyUsers",
                columns: new[] { "CompanyId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_DataCompanyId",
                table: "CompanyUsers",
                column: "DataCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_DataUserId",
                table: "CompanyUsers",
                column: "DataUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_UserId",
                table: "CompanyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_CargoLoadId",
                table: "Conversations",
                column: "CargoLoadId",
                unique: true,
                filter: "[CargoLoadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_Participant1Id",
                table: "Conversations",
                column: "Participant1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_Participant2Id",
                table: "Conversations",
                column: "Participant2Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataClients_UserId",
                table: "DataClients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataCompanies_UserId",
                table: "DataCompanies",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataUsers_ExternalUserId",
                table: "DataUsers",
                column: "ExternalUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverDocuments_DriverId",
                table: "DriverDocuments",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverDocuments_VerifiedById",
                table: "DriverDocuments",
                column: "VerifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_IdentityNumber",
                table: "Drivers",
                column: "IdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LicenseNumber",
                table: "Drivers",
                column: "LicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RatingId",
                table: "Feedbacks",
                column: "RatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ResolvedBy",
                table: "Feedbacks",
                column: "ResolvedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GpsTrackings_LoadId",
                table: "GpsTrackings",
                column: "LoadId");

            migrationBuilder.CreateIndex(
                name: "IX_GpsTrackings_UserId",
                table: "GpsTrackings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GpsTrackings_VehicleId",
                table: "GpsTrackings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceNumber",
                table: "Invoices",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PackageLoadId",
                table: "Invoices",
                column: "PackageLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ServiceAgreementId",
                table: "Invoices",
                column: "ServiceAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ServiceAgreementId1",
                table: "Invoices",
                column: "ServiceAgreementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TransactionId",
                table: "Invoices",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_VehicleRentalId",
                table: "Invoices",
                column: "VehicleRentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_VehicleRentalId1",
                table: "Invoices",
                column: "VehicleRentalId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageLoads_CargoLoadId",
                table: "PackageLoads",
                column: "CargoLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageLoads_ClientId",
                table: "PackageLoads",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageLoads_PackageCode",
                table: "PackageLoads",
                column: "PackageCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageLoads_SharingGroupId",
                table: "PackageLoads",
                column: "SharingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageLoads_VehicleId",
                table: "PackageLoads",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedId",
                table: "Ratings",
                column: "RatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RaterId",
                table: "Ratings",
                column: "RaterId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteOptimization_CargoLoadId",
                table: "RouteOptimization",
                column: "CargoLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteOptimization_CargoLoadId1",
                table: "RouteOptimization",
                column: "CargoLoadId1");

            migrationBuilder.CreateIndex(
                name: "IX_RouteOptimization_VehicleId",
                table: "RouteOptimization",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteOptimization_VehicleId1",
                table: "RouteOptimization",
                column: "VehicleId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAgreement_CompanyId",
                table: "ServiceAgreement",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PackageLoadId",
                table: "Transactions",
                column: "PackageLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PayeeId",
                table: "Transactions",
                column: "PayeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PayerId",
                table: "Transactions",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionCode",
                table: "Transactions",
                column: "TransactionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocuments_VehicleId",
                table: "VehicleDocuments",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocuments_VerifiedById",
                table: "VehicleDocuments",
                column: "VerifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRental_ClientCompanyId",
                table: "VehicleRental",
                column: "ClientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRental_DataCompanyId",
                table: "VehicleRental",
                column: "DataCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRental_DriverId",
                table: "VehicleRental",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRental_DriverId1",
                table: "VehicleRental",
                column: "DriverId1");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRental_VehicleId",
                table: "VehicleRental",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRental_VehicleId1",
                table: "VehicleRental",
                column: "VehicleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ChassisNumber",
                table: "Vehicles",
                column: "ChassisNumber",
                unique: true,
                filter: "[ChassisNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverId",
                table: "Vehicles",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LicensePlate",
                table: "Vehicles",
                column: "LicensePlate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "CompanyDocuments");

            migrationBuilder.DropTable(
                name: "CompanyLegalRepresentatives");

            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "DataClients");

            migrationBuilder.DropTable(
                name: "DriverDocuments");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "GpsTrackings");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RouteOptimization");

            migrationBuilder.DropTable(
                name: "VehicleDocuments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "ServiceAgreement");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "VehicleRental");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "PackageLoads");

            migrationBuilder.DropTable(
                name: "DataCompanies");

            migrationBuilder.DropTable(
                name: "CargoLoads");

            migrationBuilder.DropTable(
                name: "CargoSharingGroups");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "DataUsers");
        }
    }
}
