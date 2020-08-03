using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidade;
using System;

namespace QuickBuy.Web.Controllers
{
    [Route ("api/[controller]") ]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos()); //defini oq se considera ser um retorno ok(uma chamada bem sucedida)
                                                             //devolve um objeto cadastrado na base, quando a chamada é bem sucedida



                //if(condicao == false) 
                //{
                //    return BadRequest("");
                //} isso e pra quando n for sucedida

            }

            catch ( Exception ex) //caso der algum erro nesse caminho de retorno seja no mapeamento, banco de dados, ou na voltar, ele cai em excpetion
            {
                return BadRequest(ex.ToString());  //devolve um BadRequest avisando q aconteceu um problema, o ToString informa td q aconteceu.
            }   
        }
        [HttpPost]
        public IActionResult Post([FromBody]Produto produto) //frombody significa q vai receber a instancia com td as propiedades preenchidas q vem por requisição
                                                             //ou seja, percorre td o corpo e na requisicao transforma essa formação q veio por json num objeto reconhecido                                                    
        { 
            try 
            {
                _produtoRepositorio.Adicionar(produto);     //adicionando no banco de dados
                return Created("api/produto", produto);     //significa q foi adicionado sem erro e devolve um created q  devolve a api e o produto criado

            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
