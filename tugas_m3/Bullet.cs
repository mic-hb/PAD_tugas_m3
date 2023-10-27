using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_m3
{
    internal class Bullet : Entity
    {
        private int speed;
        public Label boxBullet { get; set; }
        public int direction { get; set;}
        public int damage { get; set; }
        public Bullet(string name, int x, int y, int direction) : base(name, x, y)
        {
            speed = 8;
            this.direction = direction;
        }

        public Bullet(string name, int x, int y, int direction, Label boxBullet) : base(name, x, y)
        {
            speed = 8;
            this.direction = direction;
            this.boxBullet = boxBullet;
        }

        public Bullet() : base()
        {
            speed = 8;
        }

        public void Move()
        {
            if(direction == 1)
            {
                this.Y -= speed;
            }
            else if(direction == 2)
            {
                this.Y += speed;
            }
            else if(direction == 3)
            {
                this.X -= speed;
            }
            else if(direction == 4)
            {
                this.X += speed;
            }
        }
    }
}
