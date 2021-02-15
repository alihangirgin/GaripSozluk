using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GaripSozluk.Data.Migrations
{
    public partial class seedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cdcf8fb8-1a87-4080-9ce7-ce3f35878a9a", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(6931), "user1@gmail.com", true, null, true, null, "USER1@GMAIL.COM", "USER1", "AQAAAAEAACcQAAAAEFLTKZM3sI4Uxec9PUhygjVEQpN2LgFi/XysXpyJYzyYbZjHwxsY2hKdFARVzTGeCQ==", "NULL", false, "U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ", false, null, "User1" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "16d0a306-e24a-492d-9142-eaf10f30b783", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(7527), "user2@gmail.com", true, null, true, null, "USER2@GMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEIbs0a708a7L9uyEQLjrYyFqTwiDs223mXOIQjvY6j5p+a7Ap94aQPRxrTabRytuJw==", "NULL", false, "U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ", false, null, "User2" },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4a4f2ff3-8267-4a44-ae6a-06d03f0ce0dc", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(7551), "user3@gmail.com", true, null, true, null, "USER3@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEHDgNLSCdSxOIEwbC3j1lgpK1VGtfcsDjma8EMABjVakzMt0IKnLskeOXoTBUN+/CQ==", "NULL", false, "U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ", false, null, "User3" },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a73462d4-05e7-415d-bd7c-6fbad9a0d2a5", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(7566), "user4@gmail.com", true, null, true, null, "USER4@GMAIL.COM", "USER4", "AQAAAAEAACcQAAAAEFFSlov2zoB5GBM4zJ8cykIbUmTWwnsdbHvbVmFmAvaZQ0larKX/rSBJkrdh5VZ1Dw==", "NULL", false, "U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ", false, null, "User4" },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d49d3e5d-461f-4f06-860c-c6dee94decaf", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(7602), "user5@gmail.com", true, null, true, null, "USER5@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAENTXilkTA0CBlBmw09m2/w8hEoK+rErvs1/yWlppiHRPL3qa+c364B/J1ox4hi7ZDA==", "NULL", false, "U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ", false, null, "User5" }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "Id", "CreateDate", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 15, 5, 5, 43, 847, DateTimeKind.Local).AddTicks(8082), "Category1", null },
                    { 2, new DateTime(2021, 2, 15, 5, 5, 43, 848, DateTimeKind.Local).AddTicks(3593), "Category2", null },
                    { 3, new DateTime(2021, 2, 15, 5, 5, 43, 848, DateTimeKind.Local).AddTicks(3604), "Category3", null },
                    { 4, new DateTime(2021, 2, 15, 5, 5, 43, 848, DateTimeKind.Local).AddTicks(3606), "Category4", null },
                    { 5, new DateTime(2021, 2, 15, 5, 5, 43, 848, DateTimeKind.Local).AddTicks(3608), "Category5", null },
                    { 6, new DateTime(2021, 2, 15, 5, 5, 43, 848, DateTimeKind.Local).AddTicks(3611), "Book", null },
                    { 7, new DateTime(2021, 2, 15, 5, 5, 43, 848, DateTimeKind.Local).AddTicks(3612), "Author", null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "ClickCount", "CreateDate", "Title", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1634), "Post1", null, 1 },
                    { 2, 1, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1651), "Post2", null, 1 },
                    { 8, 2, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1662), "Post8", null, 1 },
                    { 9, 2, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1663), "Post9", null, 1 },
                    { 3, 1, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1653), "Post3", null, 2 },
                    { 7, 1, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1660), "Post7", null, 2 },
                    { 10, 2, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1665), "Post10", null, 2 },
                    { 14, 2, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1670), "Post14", null, 2 },
                    { 4, 1, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1655), "Post4", null, 3 },
                    { 6, 1, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1659), "Post6", null, 3 },
                    { 11, 2, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1666), "Post11", null, 3 },
                    { 13, 2, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1669), "Post13", null, 3 },
                    { 5, 1, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1656), "Post5", null, 4 },
                    { 12, 2, 0, new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(1667), "Post12", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Content", "CreateDate", "PostId", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Entry1", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(2960), 1, null, 1 },
                    { 21, "Entry21", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3033), 3, null, 2 },
                    { 28, "Entry28", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3042), 3, null, 3 },
                    { 29, "Entry29", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3043), 3, null, 3 },
                    { 34, "Entry1", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3050), 3, null, 5 },
                    { 11, "Entry11", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3020), 7, null, 1 },
                    { 14, "Entry14", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3024), 10, null, 1 },
                    { 20, "Entry20", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3032), 3, null, 2 },
                    { 7, "Entry7", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(2984), 4, null, 1 },
                    { 23, "Entry23", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3036), 4, null, 2 },
                    { 30, "Entry30", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3044), 4, null, 3 },
                    { 31, "Entry31", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3045), 4, null, 3 },
                    { 35, "Entry1", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3051), 4, null, 5 },
                    { 10, "Entry10", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3019), 6, null, 1 },
                    { 8, "Entry8", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3015), 5, null, 1 },
                    { 22, "Entry22", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3034), 4, null, 2 },
                    { 6, "Entry6", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(2982), 3, null, 1 },
                    { 5, "Entry5", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(2979), 3, null, 1 },
                    { 13, "Entry13", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3023), 9, null, 1 },
                    { 2, "Entry2", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(2975), 1, null, 1 },
                    { 15, "Entry15", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3025), 1, null, 2 },
                    { 16, "Entry16", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3026), 1, null, 2 },
                    { 17, "Entry17", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3028), 1, null, 2 },
                    { 24, "Entry24", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3037), 1, null, 3 },
                    { 25, "Entry25", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3038), 1, null, 3 },
                    { 32, "Entry32", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3047), 1, null, 5 },
                    { 3, "Entry3", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(2977), 2, null, 1 },
                    { 4, "Entry4", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(2978), 2, null, 1 },
                    { 18, "Entry18", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3029), 2, null, 2 },
                    { 19, "Entry19", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3031), 2, null, 2 },
                    { 26, "Entry26", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3039), 2, null, 3 },
                    { 27, "Entry27", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3041), 2, null, 3 },
                    { 33, "Entry33", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3048), 2, null, 5 },
                    { 12, "Entry12", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3021), 8, null, 1 },
                    { 9, "Entry9", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3017), 5, null, 1 },
                    { 36, "Entry1", new DateTime(2021, 2, 15, 5, 5, 43, 849, DateTimeKind.Local).AddTicks(3052), 5, null, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
