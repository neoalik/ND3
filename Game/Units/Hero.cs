using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Units
{
    class Hero : Unit
    {

        private double _speed = 1.5;

        private double _counter;

        public Hero(int x, int y, string name, char heroMarker) 
            : base(x, y, name, heroMarker)
        {

        }

        public void MoveRight()
        {
            X += CounterStep();
        }

        public void MoveLeft()
        {
            X -= CounterStep();
        }

        public int GetX() {
            return X;
        }

        public int CounterStep()
        {
            double step = 0;

            _counter = _counter + _speed;

            step = _counter;

            if (_counter >= 1)
            {
                _counter = 0;
            }

            return (int)step;
        }
    }
}
