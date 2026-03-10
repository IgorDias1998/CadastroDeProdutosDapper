using Application.Interfaces;
using Domain.Entidades;

namespace Application.Services
{
    public class ProdutoServices
    {
        private readonly IProdutoRepository _repository;

        public ProdutoServices(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Produtos>> BuscarTodosProdutosAsync()
        {
            var produtos = await _repository.BuscarTodosProdutosAsync();
            return produtos;
        }

        public async Task<Produtos> AdicionarProdutoAsync(Produtos produto)
        {
            return await _repository.AdicionarProdutoAsync(produto);
        }
    }
}
