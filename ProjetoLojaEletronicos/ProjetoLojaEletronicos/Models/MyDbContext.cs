using Microsoft.EntityFrameworkCore;

namespace ProjetoLojaEletronicos.Models
{
    // A classe de contexto de banco de dados ou DbContext é responsável por
    // mapear as classes que serão atreladas às tabelas do banco de dados.
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        // Nesta sessão, especificamos as classes do Model que serão espalhadas em tabelas do BD
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}
