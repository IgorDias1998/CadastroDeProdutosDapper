using Domain.Entidades;

namespace Application.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<bool> AdicionarProduto(Produtos produto);
    }
}
