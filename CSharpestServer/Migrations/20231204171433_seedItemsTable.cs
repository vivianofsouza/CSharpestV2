using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpestServer.Migrations
{
    /// <inheritdoc />
    public partial class seedItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "bundles",
              columns: new[] { "Id", "Name" },
              values: new object[] { new Guid("6818FB3A-3079-4117-BA4C-7C16BE4F9422"), "bogo" });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                values: new object[] { new Guid("47E5D565-3AF5-4911-AEF4-0BDDCEE90C62"), "Sweet Powdered tablets that melt in your mouth", "Smarties", 0.53m, 500, null, "https://smartiesstore.com/cdn/shop/products/205CandyRolls_1024x1024.jpg?v=1676494015" });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                values: new object[] { new Guid("81590D03-CDF8-45BE-968D-124E4EA9BFAD"), "Milk chocolate with crispy rice", "Crunch", 0.62m, 500, null, "https://www.bulkecandy.com/cdn/shop/products/Nestle_Crunch_Bar__92165.jpeg?v=1455581612" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("910D2A35-1328-48AB-B1F7-18858410DDF1"), "Classic bite-sized milk chocolate bites", "Hershey Kisses", 0.31m, 500, null, "https://zazoli.com/cdn/shop/products/71ldHGWkQ5L._SL1500_b2c553e8-c492-4eb6-bf23-09b72243157e.jpg?v=1644428472" });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                values: new object[] { new Guid("02FE8C11-4D54-4AF8-B878-18DFFC8196FA"), "Extremely sour hard candy", "War Heads", 0.54m, 500, "6818FB3A-3079-4117-BA4C-7C16BE4F9422", "https://pennycandy.com/cdn/shop/products/10032134233013_A1N0.png?v=1640287341" });

            migrationBuilder.InsertData(
               table: "items",
               columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
               values: new object[] { new Guid("658B3656-1249-468E-8324-1FE3CA204AFB"), "Thin chewy, fruit-flavored taffy with sweet and sour taste", "Air Heads", 0.70m, 500, "6818FB3A-3079-4117-BA4C-7C16BE4F9422", "https://zazoli.com/cdn/shop/products/MiniAirheads.jpg?v=1675165281" });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                values: new object[] { new Guid("E3155287-24E0-4839-A1AB-65343934B164"), "Chewy cinnamon-flavored candy with a kick", "Hot Tamales", 0.69m, 500, null, "https://cdn11.bigcommerce.com/s-oxoxmgwste/images/stencil/1280x1280/products/2854/6164/just-born-hot-tamales__17030.1635047570.jpg?c=1" });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                values: new object[] { new Guid("958fe8be-b592-4ce6-b6c7-6761b997065f"), "Hard Candy with tangy flavors", "Jolly Ranchers", 0.18m, 500, null, "https://superiornutchicago.com/wp-content/uploads/2015/06/10041.jpg" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("2A9773E0-2BDC-46F4-87E4-6D3F01F408A7"), "Soft, chewable, fruit-flavored taffy", "Starburst", 0.59m, 500, null, "https://i.ebayimg.com/images/g/AM4AAOSwmvpcPeir/s-l1600.jpg" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("6818FB3A-3079-4117-BA4C-7C16BE4F9422"), "Sweet, tangy, crunchy fruit-flavored pebbles", "Nerds", 0.87m, 500, "6818FB3A-3079-4117-BA4C-7C16BE4F9422", "https://www.mastgeneralstore.com/prodimages/73488-DEFAULT-l.jpg" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("934693DF-8CE7-47E0-8F27-87179BF729D7"), "Soft peanut butter covered in chocolate", "Reeses Peanut Butter Cups", 0.50m, 500, null, "https://theeburgerdude.com/wp-content/uploads/2023/10/Reeses-Blog-3-scaled-735x735.jpg" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("3DFC9A67-4F54-4A2E-8E86-A5BC91FB2098"), "Nougat topped with caramel, all covered in chocolate", "Milky Way", 0.37m, 500, null, "https://www.candywarehouse.com/cdn/shop/files/milky-way-candy-bars-36-piece-box-candy-warehouse-1.jpg?v=1689310168" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("5396BC7C-0917-41C0-BE43-B1734DC22A05"), "Button shaped chocolates covered in a hard shell", "M&Ms", 0.63m, 500, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSVQo_bNMGxqfCy7IuWgRsedgJoutNPiry8mXdkQOtLg&s" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("0692703F-794D-4181-BB50-B549468F019C"), "Chocolate covered wafers", "Kit Kat", 0.47m, 500, null, "https://www.candywarehouse.com/cdn/shop/files/kit-kat-candy-bars-36-piece-box-candy-warehouse-1_de97fd46-6fb3-4b97-89bd-1e2ce12b0270.jpg?v=1689309466" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("C0372D94-8C32-4D3B-8724-B83EB0EA8493"), "Fun-sized chocolate bar with caramel and crispy rice", "100 Grand", 0.61m, 500, null, "https://media.candynation.com/catalog/product/cache/37b377f2a2dfea30b42072b55c737119/1/0/100_grand_candy_bar.jpg" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("B33CF25F-23C5-4308-B665-D63C0A9E9037"), "Iconic diary milk bar", "Cadbury Bar", 1.07m, 500, "6818FB3A-3079-4117-BA4C-7C16BE4F9422", "https://static.independent.co.uk/s3fs-public/thumbnails/image/2020/05/21/15/istock-458614037.jpg?width=1200&height=1200&fit=crop" });

            migrationBuilder.InsertData(
                 table: "items",
                 columns: new[] { "Id", "Description", "Name", "Price", "Stock", "bundleId", "ImageURL" },
                 values: new object[] { new Guid("DA19C23E-A786-42C8-8BAC-E42047781F86"), "Almond and cocount flakes encased in milk chocolate", "Almond Joy", 0.65m, 500, null, "https://www.myamericanmarket.com/media/catalog/product/cache/b77af72255bfd3ee5c7895ae79272b2f/a/l/almond-joy-candy-bar-45g-1.6oz-1.jpg" });


            migrationBuilder.InsertData(
                 table: "users",
                 columns: new[] { "Id", "CartId", "Email", "IsAdmin", "FirstName", "LastName", "Password", "Phone", "Address" },
                 values: new object[] { new Guid("93F164A3-00AE-453E-B21A-C18EA9A43543"), new Guid("039D8391-FE9C-4506-80E3-CA6FE7B05625"), "rando2@email.com", false, "Uncle", "Surname", "password1#", "8037771211", "The Addy St" });

            migrationBuilder.InsertData(
                 table: "users",
                 columns: new[] { "Id", "CartId", "Email", "IsAdmin", "FirstName", "LastName", "Password", "Phone", "Address" },
                 values: new object[] { new Guid("628EB41B-EF6A-4CAB-A860-C916E27272B6"), new Guid("73BDA49F-3457-4D0E-A41B-B471346F9B3C"), "rando@email.com", false, "Doc", "Surname", "password1", "8037771111", "My Addy St" });

            migrationBuilder.InsertData(
                 table: "cards",
                 columns: new[] { "Number", "Month", "Year", "Name", "CVV", "ZipCode" },
                 values: new object[] { "1234123412341234", 11, 2028, "Rando", 321, 29208 });

            migrationBuilder.InsertData(
                 table: "cards",
                 columns: new[] { "Number", "Month", "Year", "Name", "CVV", "ZipCode" },
                 values: new object[] { "1234567812345678", 12, 2026, "Uncle", 123, 29208 });

            migrationBuilder.InsertData(
                 table: "carts",
                 columns: new[] { "Id", "userId", "tax", "subtotal", "totalPrice" },
                 values: new object[] { new Guid("73BDA49F-3457-4D0E-A41B-B471346F9B3C"), new Guid("628EB41B-EF6A-4CAB-A860-C916E27272B6"), 0.0m, 0.0m, 0.0m });

            migrationBuilder.InsertData(
                 table: "carts",
                 columns: new[] { "Id", "userId", "tax", "subtotal", "totalPrice" },
                 values: new object[] { new Guid("039D8391-FE9C-4506-80E3-CA6FE7B05625"), new Guid("93F164A3-00AE-453E-B21A-C18EA9A43543"), 0.0m, 0.0m, 0.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
