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

        bool jumping = false;
        int pipeSpeed = 4;
        int gravity = 5;
        int Inscore = 0;
        public Form1()
        {
            InitializeComponent();

            scoreText.Visible = true;
            endText1.Visible = false;
            endText2.Visible = false;
            gameDesigner.Visible = false;
            btnreset.Visible = false;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappybird.Top += gravity;
            scoreText.Text = "" +Inscore;

            if (flappybird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
            else if (flappybird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }
            else if (flappybird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }

            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 1000;
                Inscore += 1;
            }
            else if (pipeTop.Left < -95)
            {
                pipeTop.Left = 1100;
                Inscore += 1;
            }
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -5;
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 5;
            }
        }

        private void endGame()
        {
            scoreText.Visible = false;
            endText1.Text = "Game Over";
            endText2.Text = "Final Score is: " + Inscore;
            gameDesigner.Text = "Designed by ErnestoVM";
            gameTimer.Stop();
            endText1.Visible = true;
            endText2.Visible = true;
            //gameDesigner.Visible = true;
            btnreset.Enabled = true;
            btnreset.Visible = true;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            scoreText.Visible = true;
            endText1.Visible = false;
            endText2.Visible = false;
            gameDesigner.Visible = false;

            flappybird.Top = 50;
            pipeTop.Left = 800;
            pipeBottom.Left = 1000;
            Inscore = 0;
            btnreset.Visible = false;
            btnreset.Enabled = false;
            btnPlay.Enabled = false; 
            btnPlay.Visible = false;
            gameTimer.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnreset_Click(this, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
