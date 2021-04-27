using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazingSnake
{
    class Snake
    {
        public List<int[]> parts;
        public int[] orientation = { 1, 0 };
        
        public Snake(int startx, int starty)
        {
            parts = new List<int[]>();
            int[] snakehead = { startx, starty };
            parts.Add(snakehead);
        }

        public void setDirection(char c) {
            c = char.ToUpper(c);
            if(c == 'W') { this.goUp(); }
            else if(c == 'A') { this.goLeft(); }
            else if (c == 'S') { this.goDown(); }
            else if (c == 'D') { this.goRight(); }
        }

        private void goUp() { 
            this.orientation = new int[]{ -1, 0 };
        }
        private void goDown() {
            this.orientation = new int[] { 1, 0 };
        }
        private void goRight() {
            this.orientation = new int[] { 0, 1 };
        }
        private void goLeft() {
            this.orientation = new int[] { 0, -1 };
        }

        public void move()
        {
            int[] actual = this.parts[0];
            int x = actual[0] + orientation[0];
            int y = actual[1] + orientation[1];
            this.parts[0] = new int[]{ x, y };
        }
    }
    class Program
    {
        public static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        public static char key = 'S';
        public static Snake sneaky = new Snake(0, 5);
        public static bool gameIsRunning = true;
        public static int[] food = { 5,5 };

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
            Console.WriteLine(key);
            char[,] palya = {
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' },
                { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ' }
            };

            palya[food[0], food[1]] = '$';

            sneaky.setDirection(key);

            sneaky.move();

            foreach (var part in sneaky.parts)
            {
                try
                {
                    if(palya[part[0], part[1]] == '$')
                    {
                        //int[] snakepart = { part[0] , part[1] };
                        //sneaky.parts.Add(snakepart);
                        Console.WriteLine("Nyami!");
                    }
                    palya[part[0], part[1]] = '@';
                }
                catch (Exception)
                {
                    gameIsRunning = false;
                }
            }

            for (int x = 0; x < 10; x++) // MAJD KI KELL JAVÍTANI!
            {
                for (int y = 0; y < 10; y++) // MAJD KI KELL JAVÍTANI!
                {
                    Console.Write("[" + palya[x, y] + "]");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int num = 0;
            while (gameIsRunning) { 
                DateTime now = DateTime.Now;
                DateTime refresh = now.AddSeconds(0.5);
                while(now < refresh) {
                        now = DateTime.Now;    
                }
                num++;
                refreshConsole();
                Console.WriteLine(num);
            }

            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Pontszám: "+ sneaky.parts.Count);
            Console.ReadKey();
        }
    }
}
