public static class CalculadoraJuros
{
    public static decimal Calcular(
        decimal valor,
        DateOnly vencimento,
        DateOnly dataAtual)
    {
        int diasAtraso =
            dataAtual.DayNumber - vencimento.DayNumber;
        
        if (diasAtraso <= 0)
        {
            return 0m;
        }

        return valor * 0.025m * diasAtraso;
    }
}
