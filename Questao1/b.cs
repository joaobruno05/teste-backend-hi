/*
Depende do contexto também. Utiliza-se herança quando existe uma relação "é um" (is-a) entre as classes,
quando você quer reusar e/ou estender comportamento existente e quando as classes compartilham uma hierarquia comum.
Já a delegação utiliza-se quando você quer composição em vez de herança, quando as responsabilidades estão em classes separadas,
cada uma focada em um comportamento e quer menos acoplamento entre as classes. 
*/

// Exemplos:

// Exemplo de Herança:
public class Veiculo
{
    public void Ligar() => Console.WriteLine("Veículo ligado");
}

public class Carro : Veiculo
{
    public void AbrirPortaMala() => Console.WriteLine("Porta-malas aberto");
}

public class Moto : Veiculo
{
    public void AbaixarGuidão() => Console.WriteLine("Guidão abaixado");
}

// Exemplo de Delegação:
public class TV
{
    public void Ligar() => Console.WriteLine("TV ligada");
}

public class ControleRemoto
{
    private readonly TV tv;

    public ControleRemoto(TV tv)
    {
        this.tv = tv;
    }

    public void LigarTV()
    {
        tv.Ligar();
    }
}