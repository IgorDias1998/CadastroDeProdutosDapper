using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ProdutoServices _services;

        public ProdutoController(ProdutoServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<Produtos>> BuscarTodosProdutosAsync()
        {
            var produtos = await _services.BuscarTodosProdutosAsync();
            return produtos;
        }

        [HttpPost]
        public async Task<Produtos> AdicionarProdutosAsync([FromBody] Produtos produto)
        {
            var produtoAdicionado = await _services.AdicionarProdutoAsync(produto);
            return produtoAdicionado;
        }
    }
}
