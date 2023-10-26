using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public ZCOM()
        {
            InitializeComponent();
            player = new Player();
            list_barriers = new List<Label>();
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
        }

        private void ZCOM_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;
            Point inital = new Point(player.X, player.Y);

            if (e.KeyCode == Keys.W)
            {
                if (player.Y - speed > 0) player.Move(0, -speed);
            }

            if (e.KeyCode == Keys.S)
            {
                if (player.Y + boxPlayer.Size.Height + speed < panelMap.Location.Y + panelMap.Size.Height) player.Move(0, speed);
            }

            if (e.KeyCode == Keys.A)
            {
                if (player.X - speed > 0) player.Move(-speed, 0);
            }

            if (e.KeyCode == Keys.D)
            {
                if (player.X + boxPlayer.Size.Width + speed < panelMap.Location.X + panelMap.Size.Width) player.Move(speed, 0);
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

            if (!isValid)
            {
                player.X = inital.X;
                player.Y = inital.Y;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            boxPlayer.Location = new Point(player.X, player.Y);
            timerRefresh();
            clock++;
        }

        private void timerRefresh()
        {
            string time_shown = (clock / 10).ToString();
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
    }
}
