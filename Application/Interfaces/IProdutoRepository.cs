using Domain.Entidades;

namespace Application.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<IEnumerable<Produtos>> BuscarTodosProdutosAsync();
        public Task<bool> AdicionarProdutoAsync(Produtos produto);
    }
}
