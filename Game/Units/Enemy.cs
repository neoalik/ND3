using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Units
{
    class Enemy : Unit
    {
        private int _id;

        private double _speed = 0.02;

        private double _counter;

        public Enemy(int id, int x, int y, string name, char marker, double speed = 0.02) 
            : base(x, y, name, marker)
        {
            this._id = id;
            this._speed = speed;
        }

        public void MoveDown()
        {
            Y += CounterStep();
        }

        public int GetId()
        {
            return _id;
        }

        public int GetY()
        {
            return Y;
        }

        public int GetX()
        {
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
