using Microsoft.EntityFrameworkCore.Migrations;

namespace frout_implementation.Migrations
{
    public partial class UpdateSubscriptionCalendarWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OccurenceInDays",
                table: "Subscriptions",
                newName: "NextDeliveryCalendarWeek");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextDeliveryCalendarWeek",
                table: "Subscriptions",
                newName: "OccurenceInDays");
        }
    }
}
