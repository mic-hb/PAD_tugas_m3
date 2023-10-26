using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tugas_m3
{
    internal class Entity
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Entity(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public Entity()
        {
            this.Name = null;
            this.X = 0;
            this.Y = 0;
        }

        public void Move(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }
    }
}
