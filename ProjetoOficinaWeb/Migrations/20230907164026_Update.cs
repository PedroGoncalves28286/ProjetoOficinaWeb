using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoOficinaWeb.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "Orders",
                newName: "AppointmentDate");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Orders",
                newName: "DeliveryDate");
        }
    }
}
