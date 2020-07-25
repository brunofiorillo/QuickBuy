using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Contratos
{
    /// <summary>
    /// nessa interface tera todos os metodos q serão utilizados como base de contratos ,
    /// explicando codigo abaixo, : -> herdar, definiu uma interface de nome ibaserepositorio que trabalho somente com o TEntity, essa interface herda de outra interface 
    /// de Idisposable e o TEntiy é uma classe. 
    /// </summary>
   
    public interface IBaseRepositorio<TEntiy> : IDisposable where TEntiy : class
    {
        void Adicionar(TEntiy entity);
        TEntiy ObterPorId(int id);
        IEnumerable<TEntiy> ObterTodos();
        void Atualizar(TEntiy entity);
        void Remover(TEntiy entity);

    }
    

}
