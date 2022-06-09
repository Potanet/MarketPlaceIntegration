using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlaceIntegration.IdentityServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketplaceLogin_AspNetUsers_ApplicationUserId",
                table: "MarketplaceLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketplaceLogin_Marketplace_MarketPlaceId",
                table: "MarketplaceLogin");

            migrationBuilder.DropIndex(
                name: "IX_MarketplaceLogin_ApplicationUserId",
                table: "MarketplaceLogin");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "MarketplaceLogin");

            migrationBuilder.DropColumn(
                name: "MaeketPlaceId",
                table: "MarketplaceLogin");

            migrationBuilder.RenameColumn(
                name: "MarketPlaceId",
                table: "MarketplaceLogin",
                newName: "MarketplaceId");

            migrationBuilder.RenameIndex(
                name: "IX_MarketplaceLogin_MarketPlaceId",
                table: "MarketplaceLogin",
                newName: "IX_MarketplaceLogin_MarketplaceId");

            migrationBuilder.AddColumn<string>(
                name: "UserMarketplaceId",
                table: "MarketplaceLogin",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserMarketplaces",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    MarketplaceId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMarketplaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMarketplaces_Marketplace_MarketplaceId",
                        column: x => x.MarketplaceId,
                        principalTable: "Marketplace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMarketplaces_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceLogin_UserMarketplaceId",
                table: "MarketplaceLogin",
                column: "UserMarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMarketplaces_MarketplaceId",
                table: "UserMarketplaces",
                column: "MarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMarketplaces_UserId",
                table: "UserMarketplaces",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplaceLogin_Marketplace_MarketplaceId",
                table: "MarketplaceLogin",
                column: "MarketplaceId",
                principalTable: "Marketplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplaceLogin_UserMarketplaces_UserMarketplaceId",
                table: "MarketplaceLogin",
                column: "UserMarketplaceId",
                principalTable: "UserMarketplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketplaceLogin_Marketplace_MarketplaceId",
                table: "MarketplaceLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketplaceLogin_UserMarketplaces_UserMarketplaceId",
                table: "MarketplaceLogin");

            migrationBuilder.DropTable(
                name: "UserMarketplaces");

            migrationBuilder.DropIndex(
                name: "IX_MarketplaceLogin_UserMarketplaceId",
                table: "MarketplaceLogin");

            migrationBuilder.DropColumn(
                name: "UserMarketplaceId",
                table: "MarketplaceLogin");

            migrationBuilder.RenameColumn(
                name: "MarketplaceId",
                table: "MarketplaceLogin",
                newName: "MarketPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_MarketplaceLogin_MarketplaceId",
                table: "MarketplaceLogin",
                newName: "IX_MarketplaceLogin_MarketPlaceId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "MarketplaceLogin",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaeketPlaceId",
                table: "MarketplaceLogin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceLogin_ApplicationUserId",
                table: "MarketplaceLogin",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplaceLogin_AspNetUsers_ApplicationUserId",
                table: "MarketplaceLogin",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplaceLogin_Marketplace_MarketPlaceId",
                table: "MarketplaceLogin",
                column: "MarketPlaceId",
                principalTable: "Marketplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
