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

        public async Task<Produtos> BuscarProdutoPorIdAsync(int id)
        {
            var produto = await _repository.BuscarProdutoPorIdAsync(id);
            return produto;
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

        public async Task<Produtos> AtualizarProdutoAsync(int id, Produtos produto)
        {
            var produtoExistente = await _repository.BuscarProdutoPorIdAsync(id);

            VerificarProdutoNulo(produtoExistente);

            produtoExistente.ProdutoTitulo = produto.ProdutoTitulo;
            produtoExistente.ProdutoDescricao = produto.ProdutoDescricao;
            produtoExistente.ProdutoValor = produto.ProdutoValor;
            produtoExistente.ProdutoEstoque = produto.ProdutoEstoque;
            produtoExistente.ProdutoCodigo = produto.ProdutoCodigo;

            var prdoutoAtualizado = await _repository.AtualizarProdutoAsync(produto);
            return prdoutoAtualizado;
        }

        public async Task<bool> DeletarProdutoAsync(int id)
        {
            return await _repository.DeletarProdutoAsync(id);
        }

        private static void VerificarProdutoNulo(Produtos? produto)
        {
            if (produto is null)
            {
                throw new InvalidOperationException("Produto não encontrado.");
            }
        }
    }
}
