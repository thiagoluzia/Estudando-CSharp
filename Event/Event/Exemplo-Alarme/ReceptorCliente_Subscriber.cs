//Classe Subscriber, responsável por ouvir o evento
namespace Event.Exemplo_Alarme;

public static class ReceptorCliente_Subscriber
{
    public static void NotificarCliente()
    {
        Console.WriteLine("Notificando cliente para o evento: Casa Invadia (Patrulha a caminho)");
    }
}