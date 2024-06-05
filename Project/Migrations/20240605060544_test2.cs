using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PersonId",
                table: "Items",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_persons_PersonId",
                table: "Items",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_persons_PersonId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropIndex(
                name: "IX_Items_PersonId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Items");
        }
    }
}
