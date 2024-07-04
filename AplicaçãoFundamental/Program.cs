namespace AplicaçãoFundamental;

class Program
{
    static void Main(string[] args)
    {
        List<int> arquivos = new List<int>();
        
        arquivos.Add(1);
        arquivos.Add(3);
        arquivos.Add(3);

        foreach (int arquivo in arquivos)
        {
            Console.WriteLine(arquivo);
        }
        
    }
}