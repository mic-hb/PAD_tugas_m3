using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_m3
{
    internal class Player : Entity
    {
        private int speed;
        public Weapon weapon { get; set; }
        public Player(string name, int x, int y) : base(name, x, y)
        {
            speed = 10;
            weapon = new Weapon("Pistol", 1, 0.02);
        }

        public Player() : base()
        {
            speed = 10;
            weapon = new Weapon("Pistol", 1, 1);
        }

        public void Move(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.A:
                    this.X -= speed;
                    break;
                case System.Windows.Forms.Keys.D:
                    this.X += speed;
                    break;
                case System.Windows.Forms.Keys.W:
                    this.Y -= speed;
                    break;
                case System.Windows.Forms.Keys.S:
                    this.Y += speed;
                    break;
            }

            //if (e.KeyCode == Keys.W)
            //{
            //    player.Move(0, -5);
            //}

            //if (e.KeyCode == Keys.S)
            //{
            //    player.Move(0, 5);
            //}

            //if (e.KeyCode == Keys.A)
            //{
            //    player.Move(-5, 0);
            //}

            //if (e.KeyCode == Keys.D)
            //{
            //    player.Move(5, 0);
            //}
        }
    }
}
