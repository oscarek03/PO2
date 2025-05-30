﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalShelter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Species = table.Column<string>(type: "text", nullable: true),
                    Breed = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Microchip = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    IsAdopted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonorName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    DonationType = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    DonationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NotesOrDedication = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    EventType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volunteers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    AdoptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoptions_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoptions_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Warszawa", "Polska", "00-001", "ul. Kwiatowa 1" },
                    { 2, "Kraków", "Polska", "30-002", "ul. Leśna 5" },
                    { 3, "Poznań", "Polska", "60-003", "ul. Słoneczna 10" },
                    { 4, "Gdańsk", "Polska", "80-004", "ul. Morska 7" },
                    { 5, "Zakopane", "Polska", "34-500", "ul. Górska 15" },
                    { 6, "Wrocław", "Polska", "50-005", "ul. Spacerowa 20" },
                    { 7, "Lublin", "Polska", "20-006", "ul. Zielona 3" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Breed", "Color", "Gender", "IsAdopted", "Location", "Microchip", "Name", "Size", "Species" },
                values: new object[,]
                {
                    { 1, 3, "Mieszaniec", "Czarny", "Samiec", true, "Boks 1", "1234567890", "Kajtek", "Duży", "Pies" },
                    { 2, 2, "Europejski", "Szary", "Samica", false, "Boks 2", "0987654321", "Luna", "Mały", "Kot" },
                    { 3, 4, "Owczarek niemiecki", "Brązowy", "Samica", false, "Boks 3", "2233445566", "Sara", "Duży", "Pies" },
                    { 4, 2, "Beagle", "Tricolor", "Samiec", true, "Boks 4", "3344556677", "Benio", "Średni", "Pies" },
                    { 5, 5, "Mieszaniec", "Złoty", "Samica", false, "Boks 5", "4455667788", "Mila", "Duży", "Pies" },
                    { 6, 6, "Bulldog", "Biały", "Samiec", false, "Boks 6", "5566778899", "Gucio", "Średni", "Pies" },
                    { 7, 3, "Mieszaniec", "Srebrny", "Samica", false, "Boks 7", "6677889900", "Tosia", "Mały", "Pies" },
                    { 8, 1, "Mieszaniec", "Brązowy", "Samiec", false, "Boks 8", "7788990011", "Felek", "Mały", "Pies" },
                    { 9, 5, "Syjamski", "Biały", "Samiec", true, "Boks 9", "8899001122", "Leo", "Mały", "Kot" },
                    { 10, 3, "Mieszaniec", "Biały", "Samica", false, "Boks 10", "9900112233", "Klara", "Mały", "Kot" },
                    { 11, 4, "Maine Coon", "Rudy", "Samiec", false, "Boks 11", "1011121314", "Rufus", "Duży", "Kot" },
                    { 12, 2, "Mieszaniec", "Pręgowany", "Samica", false, "Boks 12", "1213141516", "Zoe", "Średni", "Kot" },
                    { 13, 1, "Sfinks", "Beżowy", "Samiec", false, "Boks 13", "1314151617", "Neo", "Mały", "Kot" },
                    { 14, 3, "Mieszaniec", "Niebieski", "Samica", false, "Boks 14", "1415161718", "Nina", "Mały", "Kot" },
                    { 15, 2, "Mieszaniec", "Czarny", "Samiec", false, "Boks 15", "1516171819", "Czarek", "Mały", "Kot" }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Amount", "DonationDate", "DonationType", "DonorName", "Email", "NotesOrDedication", "PaymentMethod", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 100m, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Pieniądze", "Anna Nowak", "anna.nowak@example.com", "Dla zwierząt", "Przelew", "987654321" },
                    { 2, 50m, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Karma", "Jan Kowalski", "jan.kowalski@example.com", "Karma dla psów", "Osobiście", "123456789" },
                    { 3, 200m, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Pieniądze", "Piotr Zieliński", "piotr.zielinski@example.com", "Na leczenie kotów", "Karta", "555666777" },
                    { 4, 75m, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Akcesoria", "Maria Wiśniewska", "maria.wisniewska@example.com", "Zabawki dla zwierząt", "Osobiście", "888999000" },
                    { 5, 120m, new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Pieniądze", "Tomasz Lewandowski", "tomasz.lewandowski@example.com", "Dla schroniska", "Przelew", "111222333" },
                    { 6, 60m, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Karma", "Karolina Maj", "karolina.maj@example.com", "Karma dla kotów", "Osobiście", "444555666" },
                    { 7, 150m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pieniądze", "Grzegorz Nowak", "grzegorz.nowak@example.com", "Wsparcie ogólne", "Karta", "777888999" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "EventDate", "EventType", "Note", "Title" },
                values: new object[] { 1, new DateTime(2024, 6, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Wydarzenie", "Zapraszamy wszystkich!", "Dzień otwarty" });

            migrationBuilder.InsertData(
                table: "Adoptions",
                columns: new[] { "Id", "AddressId", "AdoptionDate", "AnimalId", "Email", "FullName", "Notes", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "jan.kowalski@example.com", "Jan Kowalski", "Brak uwag", "123456789" },
                    { 2, 3, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), 9, "anna.nowak@example.com", "Anna Nowak", "Adopcja przebiegła pomyślnie", "987654321" },
                    { 3, 5, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), 4, "piotr.zielinski@example.com", "Piotr Zieliński", "Nowy dom z ogrodem", "555666777" }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "AdditionalNotes", "AddressId", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Może pracować w weekendy", 7, "piotr.zielinski@example.com", "Piotr Zieliński", "555666777" },
                    { 2, "Dostępna popołudniami", 6, "anna.maj@example.com", "Anna Maj", "600700800" },
                    { 3, "Może pracować tylko w poniedziałki", 1, "tomasz.nowak@example.com", "Tomasz Nowak", "601701801" },
                    { 4, "Lubi pracować ze zwierzętami starszymi", 1, "karolina.wisniewska@example.com", "Karolina Wiśniewska", "602702802" },
                    { 5, "Dostępny w weekendy", 2, "marek.lewandowski@example.com", "Marek Lewandowski", "603703803" },
                    { 6, "Może pomagać przy adopcjach", 3, "ewa.kaczmarek@example.com", "Ewa Kaczmarek", "604704804" },
                    { 7, "Zainteresowany opieką nad psami", 4, "grzegorz.lis@example.com", "Grzegorz Lis", "605705805" },
                    { 8, "Pomoc w organizacji wydarzeń", 5, "magdalena.bak@example.com", "Magdalena Bąk", "606706806" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_AddressId",
                table: "Adoptions",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_AnimalId",
                table: "Adoptions",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_AddressId",
                table: "Volunteers",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
