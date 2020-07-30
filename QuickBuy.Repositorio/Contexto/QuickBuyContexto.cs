using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidade;
using QuickBuy.Dominio.ObjetoDeValor;
using QuickBuy.Repositorio.Config;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //classes de mapeamento aqui...
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());

            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento()
                {
                    Id = 1, 
                    Nome = "Boleto",
                    Descricao = "Forma de Pagamento Boleto",
                },

                 new FormaPagamento()
                 {
                     Id = 2,
                     Nome = "Cartao de Crédito",
                     Descricao = "Forma de Pagamento Crédito",
                 },

                  new FormaPagamento()
                  {
                      Id = 3,
                      Nome = "Depósito",
                      Descricao = "Forma de Pagamento Depósito",
                  }



                );
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
