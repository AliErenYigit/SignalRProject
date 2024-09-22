using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRDataAccessLayer.Migrations
{
    public partial class add_message_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MesageCount",
                table: "Messages",
                newName: "MesageContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MesageContent",
                table: "Messages",
                newName: "MesageCount");
        }
    }
}
