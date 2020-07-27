using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidade;
using QuickBuy.Dominio.ObjetoDeValor;

namespace QuickBuy.Repositorio.Contexto
{
    public class QuickBuyContexto: DbContext
    {
        

        public DbSet<Usuario> Usuarios { get; set; }

        ///Aqui o nome colocado "Usuarios" Vai ser o nome da tabela no banco de dados
        ///
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<FormaPagamento> FormaPagamento{ get; set; }

        public QuickBuyContexto( DbContextOptions options) : base(options)
        {
        }
    }
}
