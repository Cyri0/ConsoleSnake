using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazingSnake
{
        class Program
        {
        public static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        public static char key = 'S';
        public static Snake sneaky = new Snake(0, 5);
        public static bool gameIsRunning = true;
        public static int[] food = { 5,5 };
        public static int width = 15;
        public static int height = 15;


        static void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                if(keyInfo.KeyChar == 'w' || keyInfo.KeyChar == 'W' ||
                   keyInfo.KeyChar == 'a' || keyInfo.KeyChar == 'A' ||
                   keyInfo.KeyChar == 's' || keyInfo.KeyChar == 'S' ||
                   keyInfo.KeyChar == 'd' || keyInfo.KeyChar == 'D')
                key = keyInfo.KeyChar;
            }
        }
        static void refreshConsole() {
            Console.Clear();
            Input();
            char[,] palya = new char[width,height];

            for (int w = 0; w < width; w++) {
                for (int h = 0; h < height; h++) {
                    palya[w, h] = '.';
                }
            }

            

            palya[food[0], food[1]] = '$';

            sneaky.setDirection(key);
            sneaky.move();

            int[] head = sneaky.getHead();
            int[] tail = sneaky.getTail();

            try {
            if (palya[head[0], head[1]] == '$')
                {
                    Random rand = new Random();

                    food = new int[] { rand.Next(width), rand.Next(height) };

                    int[] snakepart = { tail[0]-1, tail[1]};
                    sneaky.parts.Add(snakepart);
                }
            }
                catch (Exception)
                {
                    gameIsRunning = false;
                }

            foreach (var part in sneaky.parts)
            {
                try
                {   
                    palya[part[0], part[1]] = '@';   
                }
                catch (Exception)
                { }
            }

            for (int x = 0; x < palya.GetLength(0); x++)
            {
                for (int y = 0; y < palya.GetLength(1); y++)
                {
                    Console.Write(" "+palya[x, y]+" ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int num = 0;
            while (gameIsRunning) { 
                DateTime now = DateTime.Now;
                DateTime refresh = now.AddSeconds(0.1);
                while(now < refresh) {
                        now = DateTime.Now;    
                }
                num++;
                refreshConsole();
            }
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Pontszám: "+ sneaky.parts.Count);
            Console.ReadKey();
        }
    }
}