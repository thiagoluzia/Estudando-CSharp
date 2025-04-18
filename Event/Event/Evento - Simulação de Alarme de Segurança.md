# Evento com Simulação de Alarme de Segurança em C#

## ✨ Conceito
Este exemplo simula o funcionamento de uma central de segurança utilizando **eventos em C#**, reforçando a ideia de comunicação desacoplada entre objetos. Um objeto **Alarme_Publisher** dispara um evento que é ouvido por dois **subscribers**: um que notifica o cliente e outro que notifica a central de patrulha.

O exemplo segue o padrão **Publisher/Subscriber**, facilitando a extensibilidade do sistema sem que o emissor (publisher) precise conhecer quem irá reagir.

---

## 🔗 Estrutura do Projeto

### 1. Delegate e Publisher (Alarme)

```csharp
public delegate void DispararAlarmeHandler();

public class Alarme_Publisher
{
    public event DispararAlarmeHandler? OnDispararAlarme;

    public void DispararAlarme()
    {
        Console.WriteLine("Disparando alarme: Casa Invadida");
        OnDispararAlarme?.Invoke();
    }
}
```

- **Delegate:** Define a assinatura dos métodos que podem se inscrever no evento.
- **Evento:** `OnDispararAlarme` permite registrar ouvintes (subscribers).
- **Disparo:** `Invoke()` executa todos os métodos inscritos.

---

### 2. Subscribers

```csharp
public static class ReceptorCentral_Subscriber
{
    public static void NotificarPatrulha()
    {
        Console.WriteLine("Notificando patrulha para o evento: Casa invadida (Endereço: XPTO)");
    }
}

public static class ReceptorCliente_Subscriber
{
    public static void NotificarCliente()
    {
        Console.WriteLine("Notificando cliente para o evento: Casa Invadida (Patrulha a caminho)");
    }
}
```

- **ReceptorCentral_Subscriber**: reage notificando a patrulha.
- **ReceptorCliente_Subscriber**: reage notificando o cliente.

Ambos são inscritos no evento do alarme.

---

### 3. Programa Principal (Main)

```csharp
class Program
{
    static void Main(string[] args)
    {
        var CasaInvadida = true;

        Console.WriteLine("Usnado o evento OnDispararAlarme");
        var alarme = new Alarme_Publisher();

        // Inscreve os métodos nos eventos
        alarme.OnDispararAlarme += ReceptorCentral_Subscriber.NotificarPatrulha;
        alarme.OnDispararAlarme += ReceptorCliente_Subscriber.NotificarCliente;

        if(CasaInvadida)
            alarme.DispararAlarme();
    }
}
```

- Cria a instância de `Alarme_Publisher`.
- Registra os métodos dos subscribers no evento.
- Dispara o evento se a casa estiver invadida.

---

## 📊 Saída Esperada no Console
```
Usnado o evento OnDispararAlarme
Disparando alarme: Casa Invadida
Notificando patrulha para o evento: Casa invadida (Endereço: XPTO)
Notificando cliente para o evento: Casa Invadida (Patrulha a caminho)
```

---

## 🔄 Quadro-Resumo

| Elemento              | Papel no Evento                                                             |
|-----------------------|------------------------------------------------------------------------------|
| **Delegate**          | Define a assinatura dos métodos que podem ser chamados pelo evento           |
| **Alarme_Publisher**  | Dispara o evento                                                            |
| **ReceptorCentral**   | Subscriber que reage notificando a patrulha                                 |
| **ReceptorCliente**   | Subscriber que reage notificando o cliente                                  |
| **Evento**            | Mecanismo de notificação usado para disparar os métodos inscritos            |

---

## 🚀 Conclusão

Esse exemplo mostra claramente como **eventos permitem uma comunicação flexível e desacoplada**. O `Alarme_Publisher` não sabe quantos nem quais objetos estão ouvindo. Isso permite adicionar/remover subscribers sem alterar a lógica principal.

Ideal para aplicações escaláveis e responsivas como sistemas de notificação, logs, sensores, entre outros.

---

## 📄 Referências Oficiais
- ECMA-334 – *C# Language Specification*
- Microsoft Docs: [Events (C# Programming Guide)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/)
- Albahari, J. & Albahari, B. (2022). *C# 10 in a Nutshell*. O’Reilly Media
