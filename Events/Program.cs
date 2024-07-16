using System;
using System.Collections.Generic;

// Classe para argumentos do evento de sala cheia
public class SalaCheiaEventArgs : EventArgs
{
    public string NomeSala { get; set; }
    public int Capacidade { get; set; }
}

// Classe para argumentos do evento de início de filme
public class InicioFilmeEventArgs : EventArgs
{
    public string NomeFilme { get; set; }
    public DateTime HorarioInicio { get; set; }
}

public class SalaCinema
{
    public string Nome { get; private set; }
    public int Capacidade { get; private set; }
    private int ocupacaoAtual;

    // Definição dos eventos
    public event EventHandler<SalaCheiaEventArgs> SalaCheia;
    public event EventHandler<InicioFilmeEventArgs> FilmeIniciando;

    public SalaCinema(string nome, int capacidade)
    {
        Nome = nome;
        Capacidade = capacidade;
        ocupacaoAtual = 0;
    }

    public void AdicionarEspectador()
    {
        if (ocupacaoAtual < Capacidade)
        {
            ocupacaoAtual++;
            Console.WriteLine($"Espectador adicionado à sala {Nome}. Ocupação: {ocupacaoAtual}/{Capacidade}");

            if (ocupacaoAtual == Capacidade)
            {
                OnSalaCheia();
            }
        }
        else
        {
            Console.WriteLine($"A sala {Nome} já está lotada!");
        }
    }

    public void IniciarFilme(string nomeFilme)
    {
        OnFilmeIniciando(nomeFilme);
    }

    // Métodos para disparar os eventos
    protected virtual void OnSalaCheia()
    {
        SalaCheia?.Invoke(this, new SalaCheiaEventArgs { NomeSala = Nome, Capacidade = Capacidade });
    }

    protected virtual void OnFilmeIniciando(string nomeFilme)
    {
        FilmeIniciando?.Invoke(this, new InicioFilmeEventArgs { NomeFilme = nomeFilme, HorarioInicio = DateTime.Now });
    }
}

public class GerenciadorCinema
{
    private List<SalaCinema> salas = new List<SalaCinema>();

    public void AdicionarSala(SalaCinema sala)
    {
        salas.Add(sala);
        sala.SalaCheia += OnSalaCheia;
        sala.FilmeIniciando += OnFilmeIniciando;
    }

    private void OnSalaCheia(object sender, SalaCheiaEventArgs e)
    {
        Console.WriteLine($"ALERTA: A sala {e.NomeSala} está cheia! Capacidade máxima de {e.Capacidade} atingida.");
    }

    private void OnFilmeIniciando(object sender, InicioFilmeEventArgs e)
    {
        Console.WriteLine($"AVISO: O filme '{e.NomeFilme}' está começando na sala {((SalaCinema)sender).Nome} às {e.HorarioInicio.ToShortTimeString()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GerenciadorCinema gerenciador = new GerenciadorCinema();

        SalaCinema sala1 = new SalaCinema("Sala 1", 50);
        SalaCinema sala2 = new SalaCinema("Sala 2", 30);

        gerenciador.AdicionarSala(sala1);
        gerenciador.AdicionarSala(sala2);

        // Simulando a chegada de espectadores
        for (int i = 0; i < 55; i++)
        {
            sala1.AdicionarEspectador();
        }

        // Iniciando um filme
        sala2.IniciarFilme("Matrix");

        Console.ReadLine();
    }
}