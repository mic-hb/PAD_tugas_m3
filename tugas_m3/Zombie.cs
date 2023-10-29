using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_m3
{
    internal class Zombie : Entity
    {
        private int speed;
        public int direction { get; set; }
        public int HP { get; set; }
        public Label boxZombie { get; set; }
        public Zombie(string name, int x, int y, Label boxZombie) : base(name, x, y)
        {
            speed = 20;
            this.HP = 5;
            this.boxZombie = boxZombie;
        }

        public Zombie() : base()
        {
            speed = 10;
            this.HP = 5;
        }

        public void Move(bool isMoving)
        {
            if (direction == 1)
            {
                this.Y -= speed;
            }
            else if (direction == 2)
            {
                this.Y += speed;
            }
            else if (direction == 3)
            {
                this.X -= speed;
            }
            else if (direction == 4)
            {
                this.X += speed;
            }

            if (isMoving)
            {
                this.boxZombie.Location = new System.Drawing.Point(this.X, this.Y);
                this.boxZombie.BringToFront();
            }
        }
    }
}
