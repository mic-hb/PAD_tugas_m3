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
        private int tmp = 1;
        private Player player;
        private int clock;
        private List<Label> list_barriers;
        private List<Bullet> list_bullets;
        private List<Zombie> list_zombies;
        private const int inital_speed = 5;
        private int speed;
        private bool moveUp;
        private bool moveDown;
        private bool moveLeft;
        private bool moveRight;
        private bool canFire;
        private bool exitPressed;
        private bool throughWall;

        public ZCOM()
        {
            InitializeComponent();
            player = new Player();
            list_barriers = new List<Label>();
            list_bullets = new List<Bullet>();
            list_zombies = new List<Zombie>();
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
            exitPressed = false;
            throughWall = false;

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
            fireTimer.Interval = (int)(player.Weapon.FireRate * 1000);
            //fireTimer.Interval = 20;
        }

        private void ZCOM_KeyDown(object sender, KeyEventArgs e)
        {
            speedTimer.Start();
            int bullet_dimension = 5;
            int bullet_x = player.X + boxPlayer.Size.Width / 2 - bullet_dimension;
            int bullet_y = player.Y + boxPlayer.Size.Height / 2 - bullet_dimension;

            if (e.KeyCode == Keys.E)
            {
                exitPressed = true;
            }

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

            /*
             * Cheats
             */
            if (e.KeyCode == Keys.Z)
            {
                cheatZombie();
            }

            if (e.KeyCode == Keys.X)
            {
                throughWall = !throughWall;
            }

            if(e.KeyCode == Keys.C)
            {
                boxKey.Visible = true;
                keyTimer.Stop();
            }

            if(e.KeyCode == Keys.V)
            {
                player.Poin += 50;
            }
        }

        private void cheatZombie()
        {
            int zombie_dimension = 50;
            Random rnd = new Random();
            int boxDoor = rnd.Next(1, 4);

            int zombie_x = boxDoor1.Location.X + boxDoor1.Width / 2 - zombie_dimension / 2;
            int zombie_y = boxDoor1.Location.Y + boxDoor1.Height / 2 - zombie_dimension / 2;

            foreach (Label door in panelMap.Controls)
            {
                if (door.Name == "boxDoor" + boxDoor.ToString())
                {
                    zombie_x = door.Location.X + door.Width / 2 - zombie_dimension / 2;
                    zombie_y = door.Location.Y + door.Height / 2 - zombie_dimension / 2;
                    break;
                }
            }

            Label boxZombie = new Label();
            boxZombie.Name = "zombie";
            boxZombie.Size = new Size(zombie_dimension, zombie_dimension);
            boxZombie.AutoSize = false;
            boxZombie.Location = new Point(zombie_x, zombie_y);
            boxZombie.BackColor = Color.White;
            boxZombie.Text = "Z";
            boxZombie.TextAlign = ContentAlignment.MiddleCenter;
            boxZombie.BringToFront();
            panelMap.Controls.Add(boxZombie);

            Zombie zombie = new Zombie("zombie", zombie_x, zombie_y, boxZombie);
            list_zombies.Add(zombie);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            /*
             * Poin
             */
            labelPoin.Text = player.Poin.ToString();


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
            if (!throughWall)
            {
                foreach (Label barrier in list_barriers)
                {
                    if (tmp.Bounds.IntersectsWith(barrier.Bounds))
                    {
                        isValid = false;
                        break;
                    }
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

            bool isDead = false;
            foreach (Zombie zombie in list_zombies)
            {
                foreach (Bullet bullet in list_bullets)
                {
                    if (bullet.boxBullet.Bounds.IntersectsWith(zombie.boxZombie.Bounds))
                    {
                        panelMap.Controls.Remove(bullet.boxBullet);
                        list_bullets.Remove(bullet);

                        if (zombie.HP > 1)
                        {
                            zombie.HP -= player.Weapon.Damage;
                        }
                        else
                        {
                            panelMap.Controls.Remove(zombie.boxZombie);
                            list_zombies.Remove(zombie);
                            isDead = true;
                        }
                        break;
                    }

                }
                if (isDead) break;
            }

            /* 
             * Safe Zone
             */
            if (boxPlayer.Bounds.IntersectsWith(boxSafeZone.Bounds))
            {
                btnPause.Enabled = true;
            }
            else
            {
                btnPause.Enabled = false;
            }

            /*
             * Key
             */
            if (boxPlayer.Bounds.IntersectsWith(boxKey.Bounds))
            {
                if (boxKey.Visible == true)
                {
                    boxKey.Visible = false;
                    boxPlayer.BackColor = Color.Yellow;
                }
            }

            /*
             * Exit
             */
            if (boxPlayer.Bounds.IntersectsWith(boxExit.Bounds))
            {
                if (boxPlayer.BackColor == Color.Yellow)
                {
                    if (exitPressed)
                    {
                        gameTimer.Stop();
                        clockTimer.Stop();
                        spawnTimer.Stop();
                        zombieTimer.Stop();
                        keyTimer.Stop();
                        MessageBox.Show("Congratulation!");
                        this.Close();
                    }
                }
            }
        }

        private void timerRefresh()
        {
            string time_shown = clock.ToString();
            labelTimer.Text = time_shown;
        }

        private void ZCOM_Shown(object sender, EventArgs e)
        {
            gameTimer.Start();
            clockTimer.Start();
            spawnTimer.Start();
            zombieTimer.Start();
            keyTimer.Start();
        }

        private void ZCOM_Load(object sender, EventArgs e)
        {
            gameInit();
            playerInit();
            zombieInit();
        }

        private void zombieInit()
        {
            int zombie_dimension = 50;
            int zombie_x = boxDoor1.Location.X + boxDoor1.Width / 2 - zombie_dimension / 2;
            int zombie_y = boxDoor1.Location.Y + boxDoor1.Height / 2 - zombie_dimension / 2;
            //int zombie_x = boxDoor1.Location.X;
            //int zombie_y = boxDoor1.Location.Y;

            Label boxZombie = new Label();
            boxZombie.Name = "zombie";
            boxZombie.Size = new Size(zombie_dimension, zombie_dimension);
            boxZombie.AutoSize = false;
            boxZombie.Location = new Point(zombie_x, zombie_y);
            boxZombie.BackColor = Color.White;
            boxZombie.Text = "Z";
            boxZombie.TextAlign = ContentAlignment.MiddleCenter;
            boxZombie.BringToFront();
            panelMap.Controls.Add(boxZombie);

            Zombie zombie = new Zombie("zombie", zombie_x, zombie_y, boxZombie);
            list_zombies.Add(zombie);
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

            if (e.KeyCode == Keys.E)
            {
                exitPressed = false;
            }

            speedTimer.Stop();
            speed = inital_speed;
        }

        private void fireTimer_Tick(object sender, EventArgs e)
        {
            canFire = true;
            fireTimer.Stop();
        }

        private void timerZombie_Tick(object sender, EventArgs e)
        {
            foreach (Zombie zombie in list_zombies)
            {
                bool through = false;
                Point initial_zombie = new Point(zombie.X, zombie.Y);

                do
                {
                    through = false;
                    zombie.X = initial_zombie.X;
                    zombie.Y = initial_zombie.Y;
                    Random rnd = new Random();
                    //zombie.direction = rnd.Next(1, 5);
                    double up = 0;
                    double down = 0;
                    double left = 0;
                    double right = 0;
                    int preffered_direction = 0;

                    for (int i = 1; i <= 4; i++)
                    {
                        zombie.direction = i;
                        zombie.Move(false);

                        if (i == 1) up = Math.Sqrt(Math.Pow(zombie.X - player.X, 2) + Math.Pow(zombie.Y - player.Y, 2));
                        if (i == 2) down = Math.Sqrt(Math.Pow(zombie.X - player.X, 2) + Math.Pow(zombie.Y - player.Y, 2));
                        if (i == 3) left = Math.Sqrt(Math.Pow(zombie.X - player.X, 2) + Math.Pow(zombie.Y - player.Y, 2));
                        if (i == 4) right = Math.Sqrt(Math.Pow(zombie.X - player.X, 2) + Math.Pow(zombie.Y - player.Y, 2));

                        zombie.X = initial_zombie.X;
                        zombie.Y = initial_zombie.Y;
                    }
                    double min = Math.Min(Math.Min(Math.Min(up, down), left), right);
                    if (min == up) preffered_direction = 1;
                    if (min == down) preffered_direction = 2;
                    if (min == left) preffered_direction = 3;
                    if (min == right) preffered_direction = 4;

                    zombie.direction = preffered_direction;
                    zombie.Move(false);
                    bool change_prefernce = false;
                    foreach (Label barrier in list_barriers)
                    {
                        if (zombie.boxZombie.Bounds.IntersectsWith(barrier.Bounds))
                        {
                            change_prefernce = true;
                        }
                    }

                    if (change_prefernce)
                    {
                        if (preffered_direction == 1 || preffered_direction == 2)
                        {
                            preffered_direction = (rnd.Next(0, 2) == 0) ? 3 : 4;
                        }
                        if (preffered_direction == 3 || preffered_direction == 4)
                        {
                            preffered_direction = (rnd.Next(0, 2) == 0) ? 1 : 2;
                        }
                    }

                    int random = rnd.Next(1, 101);
                    if (random <= 50)
                    {
                        zombie.direction = preffered_direction;
                    }
                    else
                    {
                        zombie.direction = rnd.Next(2, 5);
                    }

                    zombie.X = initial_zombie.X;
                    zombie.Y = initial_zombie.Y;
                    zombie.Move(true);

                    //if (zombie.X < 0 || zombie.X > panelMap.Location.X + panelMap.Size.Width - zombie.boxZombie.Width || zombie.Y < 0 || zombie.Y > panelMap.Location.Y + panelMap.Size.Height - zombie.boxZombie.Height)
                    //{
                    //    through = true;
                    //}

                    if (zombie.X < 0)
                    {
                        zombie.X = 0;
                        zombie.Move(true);
                        through = true;
                        break;
                    }
                    if (zombie.X > panelMap.Location.X + panelMap.Size.Width - zombie.boxZombie.Width)
                    {
                        zombie.X = panelMap.Location.X + panelMap.Size.Width - zombie.boxZombie.Width;
                        zombie.Move(true);
                        through = true;
                        break;
                    }
                    if (zombie.Y < 0)
                    {
                        zombie.Y = 0;
                        zombie.Move(true);
                        through = true;
                        break;
                    }
                    if (zombie.Y > panelMap.Location.Y + panelMap.Size.Height - zombie.boxZombie.Height)
                    {
                        zombie.Y = panelMap.Location.Y + panelMap.Size.Height - zombie.boxZombie.Height;
                        zombie.Move(true);
                        through = true;
                        break;
                    }

                    foreach (Label barrier in list_barriers)
                    {
                        if (zombie.boxZombie.Bounds.IntersectsWith(barrier.Bounds))
                        {
                            through = true;
                            //break;
                        }
                    }

                    if (zombie.boxZombie.Bounds.IntersectsWith(boxSafeZone.Bounds))
                    {
                        through = true;
                    }

                    //foreach (Label boxZombie in panelMap.Controls)
                    //{
                    //    if (boxZombie == zombie.boxZombie)
                    //    {
                    //        //boxZombie.Location = new Point(zombie.X, zombie.Y);
                    //        //boxZombie.BringToFront();
                    //    }
                    //}
                } while (through);
            }
        }

        private void spawnTimer_Tick(object sender, EventArgs e)
        {
            int jumlah_zombie = clock / 60 + 1;
            txtStatus.Text = "Jumlah zombie : " + jumlah_zombie.ToString() + "\n " + tmp;

            for (int i = 0; i < jumlah_zombie; i++)
            {
                int zombie_dimension = 50;
                Random rnd = new Random();
                int boxDoor = rnd.Next(1, 4);

                int zombie_x = boxDoor1.Location.X + boxDoor1.Width / 2 - zombie_dimension / 2;
                int zombie_y = boxDoor1.Location.Y + boxDoor1.Height / 2 - zombie_dimension / 2;

                foreach (Label door in panelMap.Controls)
                {
                    if (door.Name == "boxDoor" + boxDoor.ToString())
                    {
                        zombie_x = door.Location.X + door.Width / 2 - zombie_dimension / 2;
                        zombie_y = door.Location.Y + door.Height / 2 - zombie_dimension / 2;
                        break;
                    }
                }

                Label boxZombie = new Label();
                boxZombie.Name = "zombie";
                boxZombie.Size = new Size(zombie_dimension, zombie_dimension);
                boxZombie.AutoSize = false;
                boxZombie.Location = new Point(zombie_x, zombie_y);
                boxZombie.BackColor = Color.White;
                boxZombie.Text = "Z";
                boxZombie.TextAlign = ContentAlignment.MiddleCenter;
                boxZombie.BringToFront();
                panelMap.Controls.Add(boxZombie);

                Zombie zombie = new Zombie("zombie", zombie_x, zombie_y, boxZombie);
                list_zombies.Add(zombie);
            }

            tmp++;
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            timerRefresh();
            clock++;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                // Game Paused
                gameTimer.Stop();
                clockTimer.Stop();
                spawnTimer.Stop();
                zombieTimer.Stop();
                btnPause.Text = "Resume";

                Label paused = new Label();
                paused.Name = "paused";
                paused.Size = new Size(100, 50);
                paused.AutoSize = false;
                paused.Location = new Point(panelMap.Location.X + panelMap.Width / 2 - paused.Width / 2, panelMap.Location.Y + panelMap.Height / 2 - paused.Height / 2);
                paused.BackColor = Color.Yellow;
                paused.Text = "Paused";
                paused.TextAlign = ContentAlignment.MiddleCenter;
                panelMap.Controls.Add(paused);
                paused.BringToFront();
            }
            else
            {
                // Game Resumed
                gameTimer.Start();
                clockTimer.Start();
                spawnTimer.Start();
                zombieTimer.Start();
                btnPause.Text = "Pause";

                foreach (Label paused in panelMap.Controls)
                {
                    if (paused.Name == "paused")
                    {
                        panelMap.Controls.Remove(paused);
                        break;
                    }
                }
            }
        }

        private void keyTimer_Tick(object sender, EventArgs e)
        {
            boxKey.Visible = true;
            keyTimer.Stop();
        }
    }
}
