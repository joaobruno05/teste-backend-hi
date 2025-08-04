public class Rua
{
    public string Cep { get; set; }
    public string Nome { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Rua other)
            return Cep == other.Cep && Nome == other.Nome;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Cep, Nome);
    }
}

public class Casa
{
    public Rua Rua { get; set; }
    public int Numero { get; set; }
    public int TotalEleitores { get; set; }
}

public static class EleitorHelper
{
    public static List<Rua> RuasPorEleitores(List<Casa> casas)
    {
        var eleitoresPorRua = new Dictionary<Rua, int>();

        foreach (var casa in casas)
        {
            if (eleitoresPorRua.ContainsKey(casa.Rua))
                eleitoresPorRua[casa.Rua] += casa.TotalEleitores;
            else
                eleitoresPorRua[casa.Rua] = casa.TotalEleitores;
        }

        return eleitoresPorRua
            .OrderByDescending(kv => kv.Value)
            .Select(kv => kv.Key)
            .ToList();
    }
}


// Exemplo de uso:
public class Program
{
    public static void Main()
    {
        var rua1 = new Rua { Cep = "12345-000", Nome = "Rua A" };
        var rua2 = new Rua { Cep = "12345-001", Nome = "Rua B" };
        var casas = new List<Casa>
        {
            new Casa { Rua = rua1, Numero = 1, TotalEleitores = 10 },
            new Casa { Rua = rua1, Numero = 2, TotalEleitores = 20 },
            new Casa { Rua = rua2, Numero = 1, TotalEleitores = 50 }
        };
        var ruasOrdenadas = EleitorHelper.RuasPorEleitores(casas);
        // ruasOrdenadas[0] será rua2, pois tem mais eleitores
    }
}