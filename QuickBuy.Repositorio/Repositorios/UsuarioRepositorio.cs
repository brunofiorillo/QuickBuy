using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidade;
using QuickBuy.Repositorio.Contexto;
using System.Linq;

namespace QuickBuy.Repositorio.Repositorios
{
    /// <summary>
    /// a classe UsuarioRepositorio herda de BaseRepositorio forçando trabalhar so com a classe Usuario e tbm herda de Iusuariorepositorio
    /// </summary>
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(QuickBuyContexto quickBuyContexto) : base(quickBuyContexto)
        {
        }

        public Usuario Obter(string email, string senha)
        {
            return QuickBuyContexto.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
  