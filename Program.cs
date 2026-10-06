using System.Text.Json;

Console.WriteLine("Comissões dos Vendedores");

string json = File.ReadAllText("vendas.json");

var opcoes = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

var dados = JsonSerializer.Deserialize<DadosVendas>(json, opcoes);

if (dados == null || dados.Vendas == null)
{
    Console.WriteLine("Não foi possível obter a lista de vendas.");
    return;
}

Venda[] vendas = dados.Vendas;

Dictionary<string, decimal> comissoesPorVendedor = new();

foreach (Venda venda in vendas)
{
    decimal valorVenda = venda.Valor;
    decimal comissao;

    if (valorVenda < 100m)
    {
    comissao = 0m;
    }
    else if (valorVenda < 500m)
    {
    comissao = valorVenda * 0.01m;
    }
    else
    {
    comissao = valorVenda * 0.05m;
    }

    if (comissoesPorVendedor.ContainsKey(venda.Vendedor))
    {
        comissoesPorVendedor[venda.Vendedor] =
            comissoesPorVendedor[venda.Vendedor] + comissao;
    }
    else
    {
        comissoesPorVendedor[venda.Vendedor] = comissao;
    }
}

foreach (var resultado in comissoesPorVendedor)
{
    Console.WriteLine($"{resultado.Key}: {resultado.Value:F2}");
}

Console.WriteLine("Estoque inicial");

string jsonEstoque = File.ReadAllText("estoque.json");

var dadosEstoque =
    JsonSerializer.Deserialize<DadosEstoque>(jsonEstoque, opcoes);

if (dadosEstoque == null || dadosEstoque.Estoque == null)
{
    Console.WriteLine("Não foi possível obter a lista de produtos.");
    return;
}

Produto[] produtos = dadosEstoque.Estoque;

foreach (Produto produto in produtos)
{
    Console.WriteLine(
        $"{produto.CodigoProduto} - {produto.DescricaoProduto}: {produto.Estoque}");
}

int CodigoProduto = 101;
int quantidadeEntrada = 10;

foreach (Produto produto in produtos)
{
    if (produto.CodigoProduto == CodigoProduto)
    {
        produto.Estoque = produto.Estoque + quantidadeEntrada;
        Console.WriteLine(produto.Estoque);
    }
}
