using QuickBuy.Dominio.Contratos;
using QuickBuy.Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntiy> : IBaseRepositorio<TEntiy> where TEntiy : class
    {
        protected readonly QuickBuyContexto QuickBuyContexto;

        ///Antes disso o base reposotiro não conecta com o Banco de Dados, ele faz esse codigo acima para referencia ao DbContext e conectar
       

        public BaseRepositorio(QuickBuyContexto quickBuyContexto)
        {
            QuickBuyContexto = quickBuyContexto;

            ///o construtor vai receber em tempo de requisição o QuickBuyContexto passa para a variavel interna _quickBuyContexto 
            ///q pode ser referenciada nos metodos para add, att, e etc.


        }

        public void Adicionar(TEntiy entity)
        {
            QuickBuyContexto.Set<TEntiy>().Add(entity);
            ///informar q tipo de objeto/instancia e como n pode informar uma classe especifica(usuario,produto, pedito e etc) deve se informar o generico o Entity
           
            QuickBuyContexto.SaveChanges();
            //informando o DbContext para aplicar as alteracoes na base de dados

        }

        public void Atualizar(TEntiy entity)
        {
            QuickBuyContexto.Set<TEntiy>().Update(entity);
            QuickBuyContexto.SaveChanges();
        }

        public TEntiy ObterPorId(int id)
        {
            return QuickBuyContexto.Set<TEntiy>().Find(id);
        }

        public IEnumerable<TEntiy> ObterTodos()
        {
            return QuickBuyContexto.Set<TEntiy>().ToList();
        }

        public void Remover(TEntiy entity)
        {
            QuickBuyContexto.Remove(entity);
            QuickBuyContexto.SaveChanges();
        }

        public void Dispose()
        {
            QuickBuyContexto.Dispose();
            ///esse metodo ira descartar o objeto de repositorio(base repositorio) da memoria 
            
        }
    }
}
