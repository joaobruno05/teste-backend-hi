/*
Depende do contexto. Usa-se interfaces quando você quer definir um contrato
que pode ser implementado por várias classes de formas diferentes e independentes. No
caso das classes abstratas, é utilizada quando há um código e comportamento em comum.
*/

// Exemplos:

// Exemplo de Interface:
public interface INotificacao
{
    void Enviar(string mensagem);
}

public class EmailNotificacao : INotificacao
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"Enviando E-mail: {mensagem}");
    }
}

public class SmsNotificacao : INotificacao
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"Enviando SMS: {mensagem}");
    }
}

public class PushNotificacao : INotificacao
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"Enviando Push: {mensagem}");
    }
}

// Exemplo de Classe Abstrata:
public abstract class NotificacaoBase
{
    public void Enviar(string mensagem)
    {
        SalvarHistorico(mensagem);
        EnviarMensagem(mensagem);
        LogEnvio(mensagem);
    }

    protected abstract void EnviarMensagem(string mensagem);

    private void SalvarHistorico(string mensagem)
    {
        Console.WriteLine($"Salvando mensagem no banco: {mensagem}");
    }

    private void LogEnvio(string mensagem)
    {
        Console.WriteLine($"Notificação enviada: {mensagem}");
    }
}

public class EmailNotificacao : NotificacaoBase
{
    protected override void EnviarMensagem(string mensagem)
    {
        Console.WriteLine($"Enviando E-mail: {mensagem}");
    }
}

public class SmsNotificacao : NotificacaoBase
{
    protected override void EnviarMensagem(string mensagem)
    {
        Console.WriteLine($"Enviando SMS: {mensagem}");
    }
}