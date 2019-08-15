using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Task_Customer_Inquiry.Migrations
{
    public partial class SqlServerInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Mobile", "Name" },
                values: new object[] { 1, "sample@email.com", 46843214, "Temp Customer" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Mobile", "Name" },
                values: new object[] { 2, "anothersample@email.com", 125124, "Firstname Lastname" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Mobile", "Name" },
                values: new object[] { 3, "somemail@mail.com", 684321, "Some Customer" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Currency", "CustomerId", "Date", "Status" },
                values: new object[,]
                {
                    { 1, 1234m, "USD", 1, new DateTime(2018, 10, 20, 15, 35, 23, 0, DateTimeKind.Unspecified), 0 },
                    { 2, 623m, "USD", 1, new DateTime(2018, 10, 20, 15, 36, 23, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 5456m, "RU", 1, new DateTime(2018, 10, 20, 15, 37, 23, 0, DateTimeKind.Unspecified), 0 },
                    { 4, 1524m, "EUR", 1, new DateTime(2018, 10, 20, 15, 38, 23, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 1234m, "USD", 2, new DateTime(2018, 10, 11, 17, 39, 27, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
