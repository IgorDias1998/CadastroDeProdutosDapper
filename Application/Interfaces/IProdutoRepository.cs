using Domain.Entidades;

namespace Application.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<IEnumerable<Produtos>> BuscarTodosProdutosAsync();
        public Task<Produtos> AdicionarProdutoAsync(Produtos produto);
    }
}
