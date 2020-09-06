using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidade;
using System;
using System.IO;
using System.Linq;

namespace QuickBuy.Web.Controllers
{
    [Route ("api/[controller]") ]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;

        public ProdutoController(IProdutoRepositorio produtoRepositorio,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_produtoRepositorio.ObterTodos()); //defini oq se considera ser um retorno ok(uma chamada bem sucedida)
                                                               //devolve um objeto cadastrado na base, quando a chamada é bem sucedida
                }catch(Exception ex) //caso der algum erro nesse caminho de retorno seja no mapeamento, banco de dados, ou na voltar, ele cai em excpetion
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
                produto.Validate();
                if (!produto.EhValido) 
                {
                    return BadRequest(produto.ObterMensagemValidacao());
                }

                _produtoRepositorio.Adicionar(produto);     //adicionando no banco de dados
                return Created("api/produto", produto);     //significa q foi adicionado sem erro e devolve um created q  devolve a api e o produto criado

            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                var extensao = nomeArquivo.Split(".").Last();
                string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo, extensao);
                var pastaArquivos = _hostingEnvironment.WebRootPath + "\\arquivos\\";
                var nomeCompleto = pastaArquivos + novoNomeArquivo;

                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }
                return Json(novoNomeArquivo);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.ToString());
            }
        }

        private static string GerarNovoNomeArquivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-");
            novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extensao}";
            return novoNomeArquivo;
        }
    }
}
 