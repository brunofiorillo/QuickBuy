using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Contratos
{
    public interface IBaseRepositorio<TEntiy> : IDisposable where TEntiy : class
    {
        void Adicionar(TEntiy entity);
        TEntiy ObterPorId(int id);
        IEnumerable<TEntiy> ObterTodos();
        void Atualizar(TEntiy entity);
        void Remover(TEntiy entity);

    }
}
