public static class HiperMercado
{
    public static class Hi
    {
        public static double FormulaMagica(double custo, int validade)
        {
            // Fórmula hipotética de exemplo:
            return custo * (1 + (30.0 / validade));
        }
    }
}

public class ItemEstoque
{
    public string Nome { get; }
    public double Custo { get; }
    public int ValidadeDias { get; }

    public ItemEstoque(string nome, double custo, int validadeDias)
    {
        Nome = nome;
        Custo = custo;
        ValidadeDias = validadeDias;
    }
}

public class CalculadoraPreco
{
    public double CalcularPreco(ItemEstoque item)
    {
        return HiperMercado.Hi.formulaMagica(item.Custo, item.ValidadeDias);
    }
}

public class PrecoItem
{
    public static void Main(string[] args)
    {
        var item = new ItemEstoque("Produto A", 100.0, 30);
        var calculadora = new CalculadoraPreco();
        double preco = calculadora.CalcularPreco(item);
        Console.WriteLine($"O preço do item {item.Nome} é: R${preco}");
    }
}