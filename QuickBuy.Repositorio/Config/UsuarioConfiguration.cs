using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidade;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            //coloca id como chave primaria

            builder
                .Property(u => u.Email)
                .IsRequired() //preechimento obrigatorio, nao quero q ela fique nula
                .HasMaxLength(50); //maximo de linha é 50

            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(400);

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder
                .Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(50);

           // builder .Property(u => u.Pedidos)
      
                

                



        }
    }
}
