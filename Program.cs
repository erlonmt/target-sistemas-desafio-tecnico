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

List<MovimentacaoEstoque> movimentacoes = new();

int proximoId = 1;
int codigoProdutoMovimentado = 101;
int quantidadeEntrada = 10;

foreach (Produto produto in produtos)
{
    if (produto.CodigoProduto == codigoProdutoMovimentado)
    {
        produto.Estoque += quantidadeEntrada;

        MovimentacaoEstoque movimentacao = new()
        {
            Id = proximoId,
            CodigoProduto = produto.CodigoProduto,
            Quantidade = quantidadeEntrada,
            Descricao = "Entrada"
        };

        movimentacoes.Add(movimentacao);
        proximoId++;
        
        Console.WriteLine(
            $"Movimentação {movimentacao.Id}: " +
            $"{movimentacao.Descricao} de {movimentacao.Quantidade} unidades " +
            $"do produto {movimentacao.CodigoProduto}");

        Console.WriteLine($"Estoque atual: {produto.Estoque}");
    }
}

int quantidadeSaida = 5;

foreach (Produto produto in produtos)
{
    if (produto.CodigoProduto == codigoProdutoMovimentado)
    {
        produto.Estoque -= quantidadeSaida;

        MovimentacaoEstoque movimentacao = new()
        {
            Id = proximoId,
            CodigoProduto = produto.CodigoProduto,
            Quantidade = quantidadeSaida,
            Descricao = "Saída"
        };

        movimentacoes.Add(movimentacao);
        proximoId++;

        Console.WriteLine(
            $"Movimentação {movimentacao.Id}: " +
            $"{movimentacao.Descricao} de {movimentacao.Quantidade} unidades " +
            $"do produto {movimentacao.CodigoProduto}");
        
        Console.WriteLine($"Estoque atual: {produto.Estoque}");
    }
}

Console.WriteLine("Histórico de movimentações");

foreach (MovimentacaoEstoque movimento in movimentacoes)
{
    Console.WriteLine(
        $"{movimento.Id} - {movimento.Descricao} - " +
        $"Produto {movimento.CodigoProduto} - " +
        $"Quantidade {movimento.Quantidade}");
}
