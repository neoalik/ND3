using ConsoleGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    class Bullet : Unit
    {
        private int _id;

        public Bullet(int id, int x, int y, string name, char marker = '.') : base(x, y, name, marker)
        {
            this._id = id;
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public void MoveUp()
        {
            Y--;
        }

        public int GetId()
        {
            return _id;
        }
    }
}
