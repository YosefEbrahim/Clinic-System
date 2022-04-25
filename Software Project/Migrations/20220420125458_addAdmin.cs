using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Project.Migrations
{
    public partial class addAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Name], [Gender], [Type], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2f586427-0228-4967-84ae-0ffadd54f739', N'Yossef Ebrahim', N'Male',N'Admin', N'Admin', N'ADMIN', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFjc74H8Ag4f59VLVtGdtMwxPq5neawfBer8hGpptUH0jgIKTp5zx97pLsNWS34ZMA==', N'H4OJGY2VKIU4H3ZTUITCRM6VNS37N64L', N'7312fbaf-d58b-4867-8c4b-763ed5dcb726', NULL, 0, 0, NULL, 1, 0)"); 

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [dbo].[AspNetUsers] where Id='2f586427-0228-4967-84ae-0ffadd54f739'");
        }
    }
}
