namespace Event;

//01 Criar delegate
public delegate void PedidoEventHandler();

public class Pedido
{
    //02 Declarar evento
    public event PedidoEventHandler? OnCriarPedido;
    
    public void CriarPedido()
    {
        Console.WriteLine("Criando pedido");
        
        if (OnCriarPedido != null)
        {
            //03 Disparar o evento
            OnCriarPedido?.Invoke();
        }
    }
}