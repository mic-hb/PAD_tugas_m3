using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_m3
{
    public partial class ZCOM : Form
    {
        private Player player;
        private int clock;
        private List<Label> list_barriers;
        private List<Bullet> list_bullets;
        private const int inital_speed = 5;
        private int speed;
        private bool moveUp;
        private bool moveDown;
        private bool moveLeft;
        private bool moveRight;
        private bool canFire;

        public ZCOM()
        {
            InitializeComponent();
            player = new Player();
            list_barriers = new List<Label>();
            list_bullets = new List<Bullet>();
            moveUp = false;
            moveDown = false;
            moveLeft = false;
            moveRight = false;
            canFire = true;
            speed = inital_speed;
        }

        private void gameInit()
        {
            clock = 0;

            for (int i = 1; i <= 16; i++)
            {
                string tmp = "barrier" + i.ToString();
                foreach (Control control in panelMap.Controls)
                {
                    if (control.Name == tmp)
                    {
                        list_barriers.Add((Label)control);
                    }
                }
            }
        }

        private void playerInit()
        {
            // Set the player's initial position
            player.X = 1;
            player.Y = 449;
            boxPlayer.Location = new Point(player.X, player.Y);
            fireTimer.Interval = player.weapon.FireRate * 1000;
        }

        private void ZCOM_KeyDown(object sender, KeyEventArgs e)
        {
            speedTimer.Start();
            int bullet_dimension = 5;
            int bullet_x = player.X + boxPlayer.Size.Width / 2 - bullet_dimension;
            int bullet_y = player.Y + boxPlayer.Size.Height / 2 - bullet_dimension;

            if (e.KeyCode == Keys.W)
            {
                moveUp = true;
            }

            if (e.KeyCode == Keys.S)
            {
                moveDown = true;
            }

            if (e.KeyCode == Keys.A)
            {
                moveLeft = true;
            }

            if (e.KeyCode == Keys.D)
            {
                moveRight = true;
            }

            if (e.KeyCode == Keys.I)
            {
                if (canFire)
                {
                    canFire = false;
                    fireTimer.Start();

                    Label boxBullet = new Label();
                    boxBullet.Name = "bullet";
                    boxBullet.Size = new Size(bullet_dimension, bullet_dimension);
                    boxBullet.AutoSize = false;
                    boxBullet.Location = new Point(bullet_x, bullet_y);
                    boxBullet.BackColor = Color.Red;
                    boxBullet.BringToFront();
                    panelMap.Controls.Add(boxBullet);

                    Bullet bullet = new Bullet("bullet", bullet_x, bullet_y, 1, boxBullet);
                    list_bullets.Add(bullet);
                }

            }

            if (e.KeyCode == Keys.K)
            {
                if (canFire)
                {
                    canFire = false;
                    fireTimer.Start();

                    Label boxBullet = new Label();
                    boxBullet.Name = "bullet";
                    boxBullet.Size = new Size(bullet_dimension, bullet_dimension);
                    boxBullet.AutoSize = false;
                    boxBullet.Location = new Point(bullet_x, bullet_y);
                    boxBullet.BackColor = Color.Red;
                    boxBullet.BringToFront();
                    panelMap.Controls.Add(boxBullet);

                    Bullet bullet = new Bullet("bullet", bullet_x, bullet_y, 2, boxBullet);
                    list_bullets.Add(bullet);
                }
            }

            if (e.KeyCode == Keys.J)
            {
                if (canFire)
                {
                    canFire = false;
                    fireTimer.Start();

                    Label boxBullet = new Label();
                    boxBullet.Name = "bullet";
                    boxBullet.Size = new Size(bullet_dimension, bullet_dimension);
                    boxBullet.AutoSize = false;
                    boxBullet.Location = new Point(bullet_x, bullet_y);
                    boxBullet.BackColor = Color.Red;
                    boxBullet.BringToFront();
                    panelMap.Controls.Add(boxBullet);

                    Bullet bullet = new Bullet("bullet", bullet_x, bullet_y, 3, boxBullet);
                    list_bullets.Add(bullet);
                }
            }

            if (e.KeyCode == Keys.L)
            {
                //Bullet bullet = new Bullet("bullet", bullet_x, bullet_y, 4);
                //list_bullets.Add(bullet);

                //Label boxBullet = new Label();
                //boxBullet.Name = bullet.ToString();
                //boxBullet.Size = new Size(bullet_dimension, bullet_dimension);
                //boxBullet.AutoSize = false;
                //boxBullet.Location = new Point(bullet_x, bullet_y);
                //boxBullet.BackColor = Color.Red;
                //panelMap.Controls.Add(boxBullet);

                if (canFire)
                {
                    canFire = false;
                    fireTimer.Start();

                    Label boxBullet = new Label();
                    boxBullet.Name = "bullet";
                    boxBullet.Size = new Size(bullet_dimension, bullet_dimension);
                    boxBullet.AutoSize = false;
                    boxBullet.Location = new Point(bullet_x, bullet_y);
                    boxBullet.BackColor = Color.Red;
                    boxBullet.BringToFront();
                    panelMap.Controls.Add(boxBullet);

                    Bullet bullet = new Bullet("bullet", bullet_x, bullet_y, 4, boxBullet);
                    list_bullets.Add(bullet);
                }
            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Point initial = new Point(player.X, player.Y);

            if (moveUp)
            {
                player.Move(0, -speed);
            }

            if (moveDown)
            {
                player.Move(0, speed);
            }

            if (moveLeft)
            {
                player.Move(-speed, 0);
            }

            if (moveRight)
            {
                player.Move(speed, 0);
            }

            Label tmp = boxPlayer;
            tmp.Location = new Point(player.X, player.Y);

            bool isValid = true;
            foreach (Label barrier in list_barriers)
            {
                if (tmp.Bounds.IntersectsWith(barrier.Bounds))
                {
                    isValid = false;
                    break;
                }
            }

            bool borderUp = false;
            bool borderDown = false;
            bool borderLeft = false;
            bool borderRight = false;
            if (player.Y < 0) borderUp = true;
            if (player.Y + boxPlayer.Size.Height > panelMap.Location.Y + panelMap.Size.Height) borderDown = true;
            if (player.X < 0) borderLeft = true;
            if (player.X + boxPlayer.Size.Width > panelMap.Location.X + panelMap.Size.Width) borderRight = true;

            if (!isValid)
            {
                player.X = initial.X;
                player.Y = initial.Y;
            }
            if (borderUp) player.Y = 0;
            if (borderDown) player.Y = panelMap.Location.Y + panelMap.Size.Height - boxPlayer.Size.Height;
            if (borderLeft) player.X = 0;
            if (borderRight) player.X = panelMap.Location.X + panelMap.Size.Width - boxPlayer.Size.Height;

            boxPlayer.Location = new Point(player.X, player.Y);

            //foreach (Label boxBullet in panelMap.Controls.OfType<Label>())
            //{
            //    if (boxBullet.Name.Contains("bullet"))
            //    {
            //        panelMap.Controls.Remove(boxBullet);
            //    }
            //}

            foreach (Bullet bullet in list_bullets)
            {
                bullet.Move();

                foreach (Label boxBullet in panelMap.Controls)
                {
                    if (boxBullet == bullet.boxBullet)
                    {
                        boxBullet.Location = new Point(bullet.X, bullet.Y);
                        boxBullet.BringToFront();
                        break;
                    }
                }

                if (bullet.X < 0 || bullet.X > panelMap.Location.X + panelMap.Size.Width || bullet.Y < 0 || bullet.Y > panelMap.Location.Y + panelMap.Size.Height)
                {
                    panelMap.Controls.Remove(bullet.boxBullet);
                    list_bullets.Remove(bullet);
                    break;
                }
            }

            timerRefresh();
            clock++;
        }

        private void timerRefresh()
        {
            string time_shown = (clock / 50).ToString();
            labelTimer.Text = time_shown;
        }

        private void ZCOM_Shown(object sender, EventArgs e)
        {
            gameTimer.Start();
        }

        private void ZCOM_Load(object sender, EventArgs e)
        {
            gameInit();
            playerInit();
        }

        private void speedTimer_Tick(object sender, EventArgs e)
        {
            //speed++;
        }

        private void ZCOM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                moveUp = false;
            }

            if (e.KeyCode == Keys.S)
            {
                moveDown = false;
            }

            if (e.KeyCode == Keys.A)
            {
                moveLeft = false;
            }

            if (e.KeyCode == Keys.D)
            {
                moveRight = false;
            }

            speedTimer.Stop();
            speed = inital_speed;
        }

        private void fireTimer_Tick(object sender, EventArgs e)
        {
            canFire = true;
            fireTimer.Stop();
        }
    }
}
