# Desafio técnico Target Sistemas

Aplicação de console em C# para os três exercícios do desafio técnico.

## Requisitos

- .NET SDK 10

## Como executar

Na pasta do projeto, execute:

```bash
dotnet run
```

## Exercícios

### 1. Comissão de vendas

Lê as vendas de `vendas.json` e calcula a comissão de cada vendedor:

- abaixo de R$ 100,00: 0%;
- de R$ 100,00 até abaixo de R$ 500,00: 1%;
- a partir de R$ 500,00: 5%.

### 2. Movimentação de estoque

Lê os produtos de `estoque.json` e registra entradas e saídas.

Cada movimentação possui:

- identificador único durante a execução;
- descrição do tipo da movimentação;
- produto e quantidade movimentada.

Após cada operação, o programa mostra a quantidade final do produto movimentado.

### 3. Juros por atraso

Recebe um valor e uma data de vencimento e calcula os juros na data atual.

A implementação calcula 2,5% do valor por dia de atraso. O vencimento deve ser informado no formato `AAAA-MM-DD`.

## Estrutura

- `Program.cs`: fluxo da aplicação;
- `Venda.cs` e `DadosVendas.cs`: dados das vendas;
- `Produto.cs` e `DadosEstoque.cs`: dados do estoque;
- `MovimentacaoEstoque.cs`: movimentações;
- `CalculadoraJuros.cs`: cálculo dos juros;
- `vendas.json`: vendas do primeiro exercício;
- `estoque.json`: produtos do segundo exercício.
