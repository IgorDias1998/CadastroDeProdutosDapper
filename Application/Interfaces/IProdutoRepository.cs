using Domain.Entidades;

namespace Application.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<Produtos> BuscarProdutoPorIdAsync(int id);
        public Task<IEnumerable<Produtos>> BuscarTodosProdutosAsync();
        public Task<Produtos> AdicionarProdutoAsync(Produtos produto);
        public Task<Produtos> AtualizarProdutoAsync(Produtos produto);
        public Task<bool> DeletarProdutoAsync(int id);
    }
}
