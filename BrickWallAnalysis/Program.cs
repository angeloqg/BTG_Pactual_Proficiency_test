using AnalyzeLessBricks;
using System;

namespace BrickWallAnalysis
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // Parâmetros de criação da parede de tijolos
            int colunas = 10;
            int linhas = 10;
            int tamanhoTijolo = 10;

            AnalisesBrickWall objBrickWall = new AnalisesBrickWall();

            var brickWall = objBrickWall.CreateWall(colunas, linhas, tamanhoTijolo, 4);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nBTG Pactual (IT-PME)\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Teste de proficiência em raciocínio lógico e conhecimentos de programação\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Matriz Alteatória (Representação dos tijolos:\n");

            Console.ForegroundColor = ConsoleColor.Magenta;
            objBrickWall.PrintBrickWall(linhas, brickWall);

            int LeastBricks = objBrickWall.MinimumOfBricks(brickWall);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nMínimo de tijolos: {LeastBricks}");


            Console.ReadKey();
        }
    }
}
