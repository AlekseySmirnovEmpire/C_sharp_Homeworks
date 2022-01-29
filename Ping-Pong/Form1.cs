using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong
{
    public partial class Form1 : Form
    {
        private int speedVertical = 4;
        private int speedHorizontal = 4;
        private int score = 0;

        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true;

            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true; //Чтоб программа была поверх всех других программ

            this.Bounds = Screen.PrimaryScreen.Bounds; //когда запустится прога, размеры будут по экрану.

            gamePanel.Top = background.Bottom - (background.Bottom / 10);

            looseLabel.Visible = false;
            looseLabel.Left = (background.Width / 2) - (looseLabel.Width / 2);
            looseLabel.Top = (background.Height / 2) - (looseLabel.Height / 2);

            restartLooseLabel.Visible = false;
            restartLooseLabel.Left = (background.Width / 2) - 10 - (restartLooseLabel.Width / 2);
            restartLooseLabel.Top = (background.Height / 2) + 50 - (restartLooseLabel.Height / 2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();

            if(e.KeyCode == Keys.R)
            {
                gameBall.Top = 50;
                gameBall.Left = 70;
                speedHorizontal = 2;
                speedVertical = 2;
                score = 0;
                looseLabel.Visible = false;
                restartLooseLabel.Visible = false;
                timer.Enabled = true;
                result.Text = "Результат: 0";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);

            gameBall.Left += speedHorizontal;
            gameBall.Top += speedVertical;

            if (gameBall.Left <= background.Left || gameBall.Right >= background.Right)
                speedHorizontal *= -1;
            if(gameBall.Top <= background.Top)
                speedVertical *= -1;
            if(gameBall.Bottom >= background.Bottom)
            {
                timer.Enabled = false;
                looseLabel.Visible = true;
                restartLooseLabel.Visible = true;
            }      

            if(gameBall.Bottom >= gamePanel.Top && gameBall.Bottom <= gamePanel.Bottom && gameBall.Left >= gamePanel.Left
                    && gameBall.Right <= gamePanel.Right)
            {
                speedHorizontal += 1;
                speedVertical += 1;
                speedVertical *= -1;
                score += 1;
                result.Text = $"Результат: {score}";


                Random rmColor = new Random();
                background.BackColor = Color.FromArgb(rmColor.Next(150, 255), rmColor.Next(150, 255), rmColor.Next(150, 255));
            }
        }
    }
}
