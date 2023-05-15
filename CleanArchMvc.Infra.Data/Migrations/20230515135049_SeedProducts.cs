using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO  Products (Name, Description, Price, Stock, Image, CategoryId)" + 
                   "Values('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno1.jpg',1)");

            mb.Sql("INSERT INTO  Products (Name, Description, Price, Stock, Image, CategoryId)" +
                   "Values('Estojo Escolar', 'Estojo escolar cinza', 5.65, 30, 'estojo1.jpg',1)");

            mb.Sql("INSERT INTO  Products (Name, Description, Price, Stock, Image, CategoryId)" +
                   "Values('Calculadora comum', 'Caclculadora simples', 15.80, 20, 'calculadora1.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
