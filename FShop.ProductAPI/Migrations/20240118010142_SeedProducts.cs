using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FShop.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT into products (Name, Price, Description, Stock, ImageURL, CategoryId) values ('Camiseta Slim', 19.9,'Camiseta simples drifit', 25, 'camiseta.png',1)");

            mb.Sql("INSERT into products (Name, Price, Description, Stock, ImageURL, CategoryId) values ('Camiseta', 30,'Camiseta simples', 30, 'camiseta2.png',1)");

            mb.Sql("INSERT into products (Name, Price, Description, Stock, ImageURL, CategoryId) values ('Short', 80.9,'Short cargo', 54, 'short.png',2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Products");
        }
    }
}
