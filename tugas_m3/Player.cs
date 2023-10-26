using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_m3
{
    internal class Player : Entity
    {
        public Player(string name, int x, int y) : base(name, x, y)
        {
        }

        public Player() : base()
        {
        }
    }
}
