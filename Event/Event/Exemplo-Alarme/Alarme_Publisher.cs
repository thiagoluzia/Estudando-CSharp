//Classe Publisher, responsável pelo evento (Criação, declaração e envio)
namespace Event.Exemplo_Alarme;

//01 Criar delegate para o envento
public delegate void DispararAlarmeHandler();

public class Alarme_Publisher
{
    //02 Declarar o evento
    public event DispararAlarmeHandler? OnDispararAlarme;
        
    public void DispararAlarme()
    {
        Console.WriteLine("Disparando alarme: Casa Invadida");
        
        //03 Disparar o evento
        if(OnDispararAlarme != null)
            OnDispararAlarme?.Invoke();
    }
}