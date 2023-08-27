using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrierConfigurationId",
                table: "CarrierConfigurations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrierConfigurations_CarrierConfigurationId",
                table: "CarrierConfigurations",
                column: "CarrierConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarrierConfigurationId",
                table: "CarrierConfigurations",
                column: "CarrierConfigurationId",
                principalTable: "Carriers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarrierConfigurationId",
                table: "CarrierConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_CarrierConfigurations_CarrierConfigurationId",
                table: "CarrierConfigurations");

            migrationBuilder.DropColumn(
                name: "CarrierConfigurationId",
                table: "CarrierConfigurations");
        }
    }
}
