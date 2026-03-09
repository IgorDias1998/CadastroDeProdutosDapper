using Application.Interfaces;
using Dapper;
using Domain.Entidades;

namespace Infrastructure.Repositorios
{
    public class ProdutoRepository(IDbConnectionFactory connectionFactory) : IProdutoRepository
    {
        public async Task<IEnumerable<Produtos>> BuscarTodosProdutosAsync()
        {
            using var conn = connectionFactory.CreateConnection();
            conn.Open();
            return await conn.QueryAsync<Produtos>(
                "SELECT * FROM Produtos");
        }

        public async Task<bool> AdicionarProdutoAsync(Produtos produto)
        {
            using var conn = connectionFactory.CreateConnection();
            conn.Open();
            var rows = await conn.ExecuteAsync(
                "INSERT INTO Produtos (ProdutoTitulo, ProdutoDescricao, ProdutoValor, ProdutoEstoque, ProdutoCodigo) VALUES (@ProdutoId, @ProdutoTitulo, @ProdutoDescricao, @ProdutoValor, @ProdutoEstoque, @ProdutoCodigo)",
                produto);

            return rows > 0;
        }
    }
}
