using QuickBuy.Dominio.Contratos;
using System.Collections.Generic;

namespace QuickBuy.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntiy> : IBaseRepositorio<TEntiy> where TEntiy : class
    {
        public BaseRepositorio()
        {

        }
        public void Adicionar(TEntiy entity)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar(TEntiy entity)
        {
            throw new System.NotImplementedException();
        }

        public TEntiy ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntiy> ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        public void Remover(TEntiy entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
