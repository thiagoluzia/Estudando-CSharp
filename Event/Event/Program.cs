using System.ComponentModel.DataAnnotations;
using Event.Exemplo_Alarme;

namespace Event;

#region Exemplo Pedido
//Assinar e disparar o evento
// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Usnado o evento OnCriarPedido");
//         
//         var pedido = new Pedido();
//         
//         //04 Assinando um evento "subscribe"
//         pedido.OnCriarPedido += Email.Enviar;
//         pedido.OnCriarPedido += Sms.Enviar;
//         
//         //Pedido vai publicar os eventos e os assinantes que estão inscritos vão receber as notificações.
//         pedido.CriarPedido();
//     }
// }
#endregion

#region Exemplo Alarme

class Program
{
    static void Main(string[] args)
    {
        var CasaInvadida = true;
        
        Console.WriteLine("Usnado o evento OnDispararAlarme");
        var alarme = new Alarme_Publisher();
        
        //04 Assinando um evento "subscribe"
        alarme.OnDispararAlarme += ReceptorCentral_Subscriber.NotificarPatrulha;
        alarme.OnDispararAlarme += ReceptorCliente_Subscriber.NotificarCliente;
        
        //05 Pedido vai publicar os eventos e os assinantes que estão inscritos vão receber as notificações.
        if(CasaInvadida)
            alarme.DispararAlarme();
    }
}
#endregion