using Application.Interfaces;
using Dapper;
using Domain.Entidades;

namespace Infrastructure.Repositorios
{
    public class ProdutoRepository(IDbConnectionFactory connectionFactory) : IProdutoRepository
    {
        public async Task<bool> AdicionarProduto(Produtos produto)
        {
            using var conn = connectionFactory.CreateConnection();
            conn.Open();
            var rows = await conn.ExecuteAsync(
                "INSERT INTO Produtos (ProdutoTitulo, ProdutoDescricao, ProdutoValor, ProdutoCodigo) VALUES (@ProdutoId, @ProdutoTitulo, @ProdutoDescricao, @ProdutoValor, @ProdutoCodigo)",
                produto);

            return rows > 0;
        }
    }
}
