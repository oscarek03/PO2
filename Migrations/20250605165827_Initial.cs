using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalShelter.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetAddress = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Species = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Breed = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Color = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Size = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Microchip = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsAdopted = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    AdditionalNotes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    AdoptionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
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
                    { 15, 2, "Mieszaniec", "Czarny", "Samiec", false, "Boks 15", "1516171819", "Czarek", "Mały", "Kot" },
                    { 16, 7, "Labrador", "Czekoladowy", "Samiec", false, "Boks 16", "1617181920", "Borys", "Duży", "Pies" },
                    { 17, 2, "Shih Tzu", "Biały", "Samica", true, "Boks 17", "1718192021", "Misia", "Mały", "Pies" },
                    { 18, 4, "Border Collie", "Czarny", "Samiec", false, "Boks 18", "1819202122", "Riko", "Średni", "Pies" },
                    { 19, 3, "Brytyjski", "Szary", "Samica", false, "Boks 19", "1920212223", "Bella", "Mały", "Kot" },
                    { 20, 6, "Golden Retriever", "Złoty", "Samiec", false, "Boks 20", "2021222324", "Maks", "Duży", "Pies" },
                    { 21, 2, "Perski", "Biały", "Samica", false, "Boks 21", "2122232425", "Daisy", "Mały", "Kot" },
                    { 22, 1, "Jack Russell", "Biały", "Samiec", false, "Boks 22", "2223242526", "Tobi", "Mały", "Pies" },
                    { 23, 5, "Mieszaniec", "Czarny", "Samica", true, "Boks 23", "2324252627", "Mela", "Mały", "Kot" },
                    { 24, 3, "Mieszaniec", "Rudy", "Samiec", false, "Boks 24", "2425262728", "Simba", "Średni", "Pies" },
                    { 25, 4, "Syjamski", "Biały", "Samica", false, "Boks 25", "2526272829", "Lili", "Mały", "Kot" },
                    { 26, 2, "Dalmatyńczyk", "Czarny-biały", "Samiec", false, "Boks 26", "2627282930", "Oskar", "Duży", "Pies" },
                    { 27, 3, "Mieszaniec", "Biały-pręgowany", "Samica", false, "Boks 27", "2728293031", "Maja", "Mały", "Kot" },
                    { 28, 5, "Jamnik", "Brązowy", "Samica", false, "Boks 28", "2829303132", "Bambi", "Mały", "Pies" },
                    { 29, 6, "Mieszaniec", "Czarny", "Samiec", false, "Boks 29", "2930313233", "Kuba", "Mały", "Kot" },
                    { 30, 4, "Sznaucer", "Srebrny", "Samica", false, "Boks 30", "3031323334", "Pola", "Średni", "Pies" },
                    { 31, 2, "Mieszaniec", "Szary", "Samiec", false, "Boks 31", "3132333435", "Rysio", "Mały", "Kot" },
                    { 32, 1, "Mieszaniec", "Biały", "Samica", false, "Boks 32", "3233343536", "Kira", "Mały", "Pies" },
                    { 33, 3, "Mieszaniec", "Pręgowany", "Samiec", false, "Boks 33", "3334353637", "Miki", "Mały", "Kot" },
                    { 34, 2, "Mieszaniec", "Czarny", "Samica", false, "Boks 34", "3435363738", "Fiona", "Średni", "Pies" },
                    { 35, 4, "Mieszaniec", "Szylkret", "Samica", false, "Boks 35", "3536373839", "Sonia", "Mały", "Kot" },
                    { 36, 5, "Owczarek podhalański", "Biały", "Samiec", false, "Boks 36", "3637383940", "Borys", "Duży", "Pies" },
                    { 37, 2, "Mieszaniec", "Czarny", "Samica", false, "Boks 37", "3738394041", "Marta", "Mały", "Kot" },
                    { 38, 3, "Mieszaniec", "Brązowy", "Samiec", false, "Boks 38", "3839404142", "Tytus", "Średni", "Pies" },
                    { 39, 1, "Mieszaniec", "Biały", "Samica", false, "Boks 39", "3940414243", "Lola", "Mały", "Kot" },
                    { 40, 2, "Mieszaniec", "Czarny", "Samiec", false, "Boks 40", "4041424344", "Bingo", "Duży", "Pies" }
                });

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
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
