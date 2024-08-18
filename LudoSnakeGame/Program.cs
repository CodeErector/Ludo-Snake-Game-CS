using System;

namespace LudoSnakeGame
{
    class Program
    {
        static void Main()
        {
            Player player1 = new Player();
            player1.id = 1;
            player1.symbol = '^';
            Player player2 = new Player();
            player2.id = 2;
            player2.symbol = '*';

            output(player1, player2);
            int turn=1;
            while (player1.position < 100 && player2.position < 100)
            {
                Console.WriteLine("\nPress D to play Player: "+ turn);
                char btn = Console.ReadKey().KeyChar;
                if (btn == 'd')
                {
                    int num = dice();
                    if (num == 6)
                    {
                        num += dice();
                    }
                    if (turn == 1)
                    {
                        player1.setposition(num);
                        checkposition(player1);
                        output(player1,player2);
                        Console.WriteLine("\n"+num);
                        turn++;
                    }
                    else
                    {
                        player2.setposition(num);
                        checkposition(player2);
                        output(player1,player2);
                        Console.WriteLine("\n"+num);
                        turn--;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Wrong Input");
                }
            }

            if(player1.position >= 100)
            {
                Console.WriteLine($"Congrats Player {player1.id} You Win");
            }
            else if(player2.position >= 100)
            {
                Console.WriteLine($"Congrats Player {player2.id} You Win");
            }

            int dice()
            {
                Random rand = new Random();
                int num = rand.Next(1,6);
                return num;
            }

            void checkposition(Player player)
            {
                //ladder
                if (player.position == 4)
                {
                    player.position = 35;
                }
                else if (player.position == 19)
                {
                    player.position = 74;
                }
                //snake
                else if (player.position == 52)
                {
                    player.position = 3;
                }
                else if (player.position == 97)
                {
                    player.position = 17;
                }
            }

            void output(Player player1, Player player2)
            {
                Console.Clear();
                for (int i = 100; i >= 1; i--)
                {
                    if (player1.position == i && player2.position == i)
                    {
                        Console.Write($"{i}{player1.symbol}{player2.symbol}");
                    }
                    else if (player1.position == i)
                    {
                        Console.Write($"{i}{player1.symbol}");
                    }
                    else if (player2.position == i)
                    {
                        Console.Write($"{i}{player2.symbol}");
                    }
                    else if (i < 10)
                    {
                        Console.Write($" {i} ");
                    }
                    else
                    {
                        Console.Write(i + " ");
                    }
                    if (i == 11 || i == 21 || i == 31 || i == 41 || i == 51 || i == 61 || i == 71 || i == 81 || i == 91)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }

    class Player
    {
        public int id;
        public int position = 1;
        public char symbol;

        public void setposition(int num)
        {
            position += num;
        }
    }
}