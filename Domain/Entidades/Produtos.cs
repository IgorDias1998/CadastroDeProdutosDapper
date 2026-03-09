namespace Domain.Entidades
{
    public class Produtos
    {
        public int ProdutoId { get; set; }
        public string ProdutoTitulo { get; set; } = string.Empty;
        public string ProdutoDescricao { get; set; } = string.Empty;
        public decimal ProdutoValor { get; set; }
        public int ProdutoEstoque { get; set; }
        public string ProdutoCodigo { get; set; } = string.Empty;
    }
}
