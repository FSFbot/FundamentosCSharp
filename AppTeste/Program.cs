namespace AppTeste;
using System.Collections.Generic;

class Program
{
   

    static string chamadas(string nome, string sobrenome)
    {
      
        return nome+" "+ sobrenome;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Ola senhor "+""+chamadas("Felipe","Freitas"));
        var valor = 0;
        do
        {
            List<int> lista = new List<int>();
            lista.Add(valor++);
            Console.WriteLine(string.Join(", ",lista));
        } while (valor <= 10);

        
    }
}