//Classe Subscriber, responsável por ouvir o evento
namespace Event.Exemplo_Alarme;

public static class ReceptorCentral_Subscriber
{
    public static void NotificarPatrulha()
    {
        Console.WriteLine("Notificando patrulha para o evento: Casa invadida (Endereço: XPTO)");
    }
}