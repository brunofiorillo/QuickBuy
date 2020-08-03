using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidade;
using QuickBuy.Repositorio.Contexto;

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
    }
}
 