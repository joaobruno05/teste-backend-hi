using System;
using System.Collections.Generic;
using System.Linq;

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