using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КрестикиНолики
{
    internal class Program
    {
        

        public static void GamePlayerStep(int[,] mas)
        {
          

            int playerTurnI = -1;
            int playerTurnY = -1;

            Console.WriteLine("Пожалуйста введи координату X");
            Console.WriteLine("Пожалуйста введи координату Y");

            while (playerTurnI == -1 || playerTurnY == -1)
            {


                playerTurnI = Convert.ToInt32(Console.ReadLine());
                if (playerTurnI < 0 || playerTurnI > 2)
                {

                    while (playerTurnI < 0 || playerTurnI > 2)
                    {
                        Console.WriteLine("Выбрано число вне допусаемого диапозона");
                        playerTurnI = Convert.ToInt32(Console.ReadLine());

                    }
                }

                playerTurnY = Convert.ToInt32(Console.ReadLine());
                if (playerTurnY < 0 || playerTurnY > 2)
                {

                    while (playerTurnY < 0 || playerTurnY > 2)
                    {
                        Console.WriteLine("Выбрано число вне допусаемого диапозона");
                        playerTurnY = Convert.ToInt32(Console.ReadLine());

                    }
                }
                if (mas[playerTurnI, playerTurnY] == 2)
                {  
                    Console.WriteLine("Это поле уже занято");

                    playerTurnI = -1;
                    playerTurnY = -1;

                }
            }
           
            mas[playerTurnI, playerTurnY] = 1;             
        }

        public static void GameComputerStep(int[,] mas)
        {
            Random rnd = new Random();

            int compTurnI = rnd.Next(3);
            int compTurnY = rnd.Next(3);

            // Переменные для хранения индексов строки и столбца
            int row = -1;
            int column = -1;

            // Поиск случайной строки и столбца содержащих 0
            while (row == -1 || column == -1)
            {
                int randomRow = rnd.Next(3);
                int randomColumn = rnd.Next(3);

                if (mas[randomRow, randomColumn] == 0)
                {
                    row = randomRow;
                    column = randomColumn;
                }
            }
            mas[row, column] = 2;
        }

        public static void PrintGame(int[,] mas)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool VictoryCheck(int[,] mas)
        {
            // Проверка горизонтальных и вертикальных линий
            for (int i = 0; i < 3; i++)
            {
                if (mas[i, 0] != 0 && mas[i, 0] == mas[i, 1] && mas[i, 1] == mas[i, 2])
                {
                    if (mas[i, 0] == 1)
                        Console.WriteLine("Победил игрок");
                    else
                        Console.WriteLine("Победил компьютер");
                    return true;
                }

                if (mas[0, i] != 0 && mas[0, i] == mas[1, i] && mas[1, i] == mas[2, i])
                {
                    if (mas[0, i] == 1)
                        Console.WriteLine("Победил игрок");
                    else
                        Console.WriteLine("Победил компьютер");
                    return true;
                }
            }

            // Проверка диагоналей
            if (mas[0, 0] != 0 && mas[0, 0] == mas[1, 1] && mas[1, 1] == mas[2, 2])
            {
                if (mas[0, 0] == 1)
                    Console.WriteLine("Победил игрок");
                else
                    Console.WriteLine("Победил компьютер");
                return true;
            }

            if (mas[0, 2] != 0 && mas[0, 2] == mas[1, 1] && mas[1, 1] == mas[2, 0])
            {
                if (mas[0, 2] == 1)
                    Console.WriteLine("Победил игрок");
                else
                    Console.WriteLine("Победил компьютер");
                return true;
            }

            return false;
        }



        static void Main(string[] args)
        {

            int[,] mas = new int[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
            };

            bool gameIn = true;
          
            while (gameIn) 
            {
                GamePlayerStep(mas);
                if (VictoryCheck(mas))
                {

                    gameIn = false;
                    break;
                   
                }

                GameComputerStep(mas);
                if (VictoryCheck(mas))
                {
                
                    gameIn = false;
                    break;

                }

                PrintGame(mas);

            }
            Console.ReadLine();
        }
    }
}
