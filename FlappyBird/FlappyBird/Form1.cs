using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int playerScore = 0;
        int playerSpeed = 15;
        int playerGravity = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs eventArgs)
        {
            flappyBird.Top += playerGravity;
            pipeUp.Left -= playerSpeed;
            pipeDown.Left -= playerSpeed;

            if(pipeUp.Left < -50)
            {
                pipeUp.Left = 600;
            }

            if (pipeDown.Left < -25)
            {
                pipeDown.Left= 600;
                playerScore++;
            }

            if (flappyBird.Top < -25 || flappyBird.Bounds.IntersectsWith(pipeDown.Bounds) || flappyBird.Bounds.IntersectsWith(pipeUp.Bounds) || flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
        }

        private void keyDownEvent(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.Space)
            {
                playerGravity = -10;
            }
        }

        private void keyUpEvent(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.Space)
            {
                playerGravity = +5;
            }
        }

        private void endGame()
        {
            scoreText.Text = "Reached Score: " + playerScore;

            gameTimer.Stop();
            gameOverText.Visible = true;
            scoreText.Visible = true;
            infoButton.Visible = true;
        }

        private void infoButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by Eruscha \n" +
               "Version: 1.0");
        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }

        private void gameOverText_Click(object sender, EventArgs e)
        {

        }
    }
}
