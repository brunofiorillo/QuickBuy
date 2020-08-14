using QuickBuy.Dominio.Entidade;

namespace QuickBuy.Dominio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario obter(string email, string senha);   
    }
}
