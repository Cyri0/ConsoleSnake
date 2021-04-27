using System;
using System.Collections.Generic;
using System.Text;

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

        public int[] getHead()
        {
            return this.parts[0];
        }

        public int[] getTail()
        {
            return this.parts[this.parts.Count - 1];
        }

        public void setDirection(char c)
        {
            c = char.ToUpper(c);
            if (c == 'W') { this.goUp(); }
            else if (c == 'A') { this.goLeft(); }
            else if (c == 'S') { this.goDown(); }
            else if (c == 'D') { this.goRight(); }
        }

        private void goUp()
        {
            this.orientation = new int[] { -1, 0 };
        }
        private void goDown()
        {
            this.orientation = new int[] { 1, 0 };
        }
        private void goRight()
        {
            this.orientation = new int[] { 0, 1 };
        }
        private void goLeft()
        {
            this.orientation = new int[] { 0, -1 };
        }

        public void move()
        {
            for (int i = this.parts.Count - 1; i > 0; i--)
            {
                this.parts[i] = this.parts[i - 1];
            }
            int[] actual = this.parts[0];
            int x = actual[0] + orientation[0];
            int y = actual[1] + orientation[1];
            this.parts[0] = new int[] { x, y };

        }
    }

}
