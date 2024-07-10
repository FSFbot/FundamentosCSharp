using System;
using System.Collections.Generic;

namespace ListaCompression{
    class Program{
        static void Main(string[] args)
        {
            Console.WriteLine("Ola mundo em c#");
            List<string> nomes = new List<string>();

            nomes.Add("Felipe");
            nomes.Add("Thamires");
            nomes.Add("Laís");

            foreach(var nome in nomes){
                Console.WriteLine($"Olá Seja bem vindo {nome}");
            }
        }
    }
}