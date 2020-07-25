using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidade;

namespace QuickBuy.Repositorio.Repositorios
{
    /// <summary>
    /// a classe UsuarioRepositorio herda de BaseRepositorio forçando trabalhar so com a classe Usuario e tbm herda de Iusuariorepositorio
    /// </summary>
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio()
        {

        }
    }
}
 