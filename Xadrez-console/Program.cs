using System;
using tabuleiro;
using Xadrez;
namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidadeXadrez partida = new PartidadeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);
                        Console.WriteLine("\nOrigem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);
                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }

                Console.Clear();
                Tela.imprimirPartida(partida);

                
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
