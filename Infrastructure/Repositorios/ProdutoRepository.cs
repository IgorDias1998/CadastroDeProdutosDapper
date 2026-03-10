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

        public async Task<Produtos> AdicionarProdutoAsync(Produtos produto)
        {
            using var conn = connectionFactory.CreateConnection();
            conn.Open();
            var id = await conn.ExecuteScalarAsync<int>(
                @"INSERT INTO Produtos
                (ProdutoTitulo, ProdutoDescricao, ProdutoValor, ProdutoEstoque, ProdutoCodigo)
                VALUES(@ProdutoTitulo, @ProdutoDescricao, @ProdutoValor, @ProdutoEstoque, @ProdutoCodigo);    
                SELECT CAST(SCOPE_IDENTITY() as int);",
                produto);

            produto.ProdutoId = id;

            return produto;
        }
    }
}
