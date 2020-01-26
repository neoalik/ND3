using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Units
{
    class Unit
    {
        protected int X;
        protected int Y;

        private int old_X;
        private int old_Y;

        private string name;
        private char marker;

        public Unit(int x, int y, string name, char marker)
        {
            X = old_X = x;
            Y = old_Y = y;
            this.name = name;
            this.marker = marker;
        }

        public void PrintInfo()
        {
            Console.WriteLine($" Unit {name} is at {X}x{Y}");
        }

        public void Render()
        {
            Console.SetCursorPosition(old_X, old_Y);
            Console.Write(" ");

            old_X = X;
            old_Y = Y;

            Console.SetCursorPosition(X, Y);
            Console.Write(marker);
        }

        public void Clear()
        {
            Console.SetCursorPosition(old_X, old_Y);
            Console.Write(" ");
        }
    }
}
