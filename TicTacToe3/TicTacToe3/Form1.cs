using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe3
{
    public partial class Form1 : Form
    {
        string currentPlayer;
        string AI_PlayingMode = "";
        public Form1()
        {
            InitializeComponent();
        }

        //this will reset the game and set everything to empty
        private void buttonNewGame_Click_1(object sender, EventArgs e)
        {
            //Resets the Game by resetting the boxes to empty quotes("") and Enables all of the boxes to click.
            cleanButtons();

            // now that the game is resetted, I made a randomizer so that the person(or AI) is choosen to have their first move.
            if (AI_PlayingMode == "Human")
            {
                var rand = new Random();
                if (rand.Next(0, 2) == 0)
                {
                    currentPlayer = "Player1";

                    labelMessage.Text = "Player 1's Turn";
                }
                else
                {
                    currentPlayer = "Player2";
                    labelMessage.Text = "Player 2's Turn";
                }
            }
            else if (AI_PlayingMode == "Simple AI")
            {
                var rand = new Random();
                if (rand.Next(0, 2) == 0)
                {
                    currentPlayer = "Human";

                    labelMessage.Text = "Your Turn";
                }
                else
                {
                    currentPlayer = "SimpleAI";
                    labelMessage.Text = "Simple A.I's Turn";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                    AIPlaySimple();
                    currentPlayer = "Human";
                    labelMessage.Text = "Your Turn";


                }
            }
            else if (AI_PlayingMode == "Deep AI")
            {

                Currentstep = 1;
                currentPlayer = "DeepAI";
                    labelMessage.Text = "Deep A.I's Turn";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                    InitialFillOfspotsFillCondition();
                    AIPlayDeep();
                    currentPlayer = "Human";
                    labelMessage.Text = "Your Turn";


                

            }
        }

        // clears all of the buttons
        private void cleanButtons()
        {
            panel2.Enabled = true;
            button11.Text = "";
            button11.Enabled = true;
            button12.Text = "";
            button12.Enabled = true;
            button13.Text = "";
            button13.Enabled = true;
            button21.Text = "";
            button21.Enabled = true;
            button22.Text = "";
            button22.Enabled = true;
            button23.Text = "";
            button23.Enabled = true;
            button31.Text = "";
            button31.Enabled = true;
            button32.Text = "";
            button32.Enabled = true;
            button33.Text = "";
            button33.Enabled = true;

            panelSimpleAI.Enabled = true;
            button11s.Text = "";
            button11s.Enabled = true;
            button12s.Text = "";
            button12s.Enabled = true;
            button13s.Text = "";
            button13s.Enabled = true;
            button21s.Text = "";
            button21s.Enabled = true;
            button22s.Text = "";
            button22s.Enabled = true;
            button23s.Text = "";
            button23s.Enabled = true;
            button31s.Text = "";
            button31s.Enabled = true;
            button32s.Text = "";
            button32s.Enabled = true;
            button33s.Text = "";
            button33s.Enabled = true;

            panelDeepAI.Enabled = true;
            button11d.Text = "";
            button11d.Enabled = true;
            button12d.Text = "";
            button12d.Enabled = true;
            button13d.Text = "";
            button13d.Enabled = true;
            button21d.Text = "";
            button21d.Enabled = true;
            button22d.Text = "";
            button22d.Enabled = true;
            button23d.Text = "";
            button23d.Enabled = true;
            button31d.Text = "";
            button31d.Enabled = true;
            button32d.Text = "";
            button32d.Enabled = true;
            button33d.Text = "";
            button33d.Enabled = true;

        }
        //the Ai simple mode
        private void AIPlaySimple()
        {
            Random r = new Random();
            int location;
            while (true)
            {
                location = r.Next(1, 10);
                if (location == 1 && button11s.Text == "")
                {
                    button11s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (location == 2 && button12s.Text == "")
                {
                    button12s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (location == 3 && button13s.Text == "")
                {
                    button13s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (location == 4 && button21s.Text == "")
                {
                    button21s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (location == 5 && button22s.Text == "")
                {
                    button22s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (location == 6 && button23s.Text == "")
                {
                    button23s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (location == 7 && button31s.Text == "")
                {
                    button31s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (location == 8 && button32s.Text == "")
                {
                    button32s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (location == 9 && button33s.Text == "")
                {
                    button33s.Text = "O";
                    currentPlayer = "Human";
                    return;
                }
                else if (button11s.Text != "" && button12s.Text != "" && button13s.Text != "" && button21s.Text != "" && button22s.Text != "" 
                    && button23s.Text != "" && button31s.Text != "" && button32s.Text != "" && button33s.Text != "")
                {
                    return;
                }

            }
        }

        // human vs human buttons
        private void button11_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Player2")
            {
                button11.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button11.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button11.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }


        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (currentPlayer == "Player2")
            {
                button12.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button12.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button12.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (currentPlayer == "Player2")
            {
                button13.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button13.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button13.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {

            if (currentPlayer == "Player2")
            {
                button21.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button21.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button21.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {

            if (currentPlayer == "Player2")
            {
                button22.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button22.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button22.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }

        }

        private void button23_Click(object sender, EventArgs e)
        {

            if (currentPlayer == "Player2")
            {
                button23.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button23.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button23.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }

        }

        private void button31_Click(object sender, EventArgs e)
        {

            if (currentPlayer == "Player2")
            {
                button31.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button31.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button31.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }

        }

        private void button32_Click(object sender, EventArgs e)
        {

            if (currentPlayer == "Player2")
            {
                button32.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button32.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button32.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }

        }

        private void button33_Click(object sender, EventArgs e)
        {

            if (currentPlayer == "Player2")
            {
                button33.Text = "O";
                labelMessage.Text = "Player 1's Turn";
                currentPlayer = "Player1";
            }
            else
            {
                button33.Text = "X";
                labelMessage.Text = "Player 2's Turn";
                currentPlayer = "Player2";
            }
            button33.Enabled = false;
            if (CheckWhoWon() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }

        }
        //my next step was to make sure that whenever the player or the AI wins the game, it will tell you that AI won or you won in the Message box. 
        private string CheckWhoWon()
        {
            if (button11.Text != "" && button12.Text != "" && button13.Text != "" && button21.Text != "" && button22.Text != ""
                    && button23.Text != "" && button31.Text != "" && button32.Text != "" && button33.Text != "")
            {
                MessageBox.Show("Its a Draw");
                return "Draw";
            }

            if (button11.Text == "O" && button12.Text == "O" && button13.Text == "O")
            {
                MessageBox.Show(" Player 2 Won!");
                return "AI";
            }
            else if (button21.Text == "O" && button22.Text == "O" && button23.Text == "O")
            {
                MessageBox.Show(" Player 2 Won!");
                return "AI";
            }
            else if (button31.Text == "O" && button32.Text == "O" && button33.Text == "O")
            {
                MessageBox.Show(" Player 2 Won!");
                return "AI";
            }
            else if (button11.Text == "O" && button22.Text == "O" && button33.Text == "O")
            {
                MessageBox.Show(" Player 2 Won!");
                return "AI";
            }
            else if (button31.Text == "O" && button22.Text == "O" && button13.Text == "O")
            {
                MessageBox.Show(" Player 2 Won!");
                return "AI";
            }
            else if (button11.Text == "O" && button21.Text == "O" && button31.Text == "O")
            {
                MessageBox.Show(" Player 2 Won!");
                return "AI";
            }
            else if (button12.Text == "O" && button22.Text == "O" && button32.Text == "O")
            {
                MessageBox.Show(" Player 2 Won!");
                return "AI";
            }
            else if (button13.Text == "O" && button23.Text == "O" && button33.Text == "O")
            {
                MessageBox.Show(" Player 2 Won!");
                return "AI";
            }
            else if (button11.Text == "X" && button12.Text == "X" && button13.Text == "X")
            {
                MessageBox.Show(" Player 1 Won!");
                return "Human";
            }
            else if (button21.Text == "X" && button22.Text == "X" && button23.Text == "X")
            {
                MessageBox.Show(" Player 1 Won!");
                return "Human";
            }
            else if (button31.Text == "X" && button32.Text == "X" && button33.Text == "X")
            {
                MessageBox.Show(" Player 1 Won!");
                return "Human";
            }
            else if (button11.Text == "X" && button22.Text == "X" && button33.Text == "X")
            {
                MessageBox.Show(" Player 1 Won!");
                return "Human";
            }
            else if (button31.Text == "X" && button22.Text == "X" && button13.Text == "X")
            {
                MessageBox.Show(" Player 1 Won!");
                return "Human";
            }
            else if (button11.Text == "X" && button21.Text == "X" && button31.Text == "X")
            {
                MessageBox.Show(" Player 1 Won!");
                return "Human";
            }
            else if (button12.Text == "X" && button22.Text == "X" && button32.Text == "X")
            {
                MessageBox.Show(" Player 1 Won!");
                return "Human";
            }
            else if (button13.Text == "X" && button23.Text == "X" && button33.Text == "X")
            {
                MessageBox.Show(" Player 1 Won!");
                return "Human";
            }

            return "None";


        }
        private string CheckWhoWonSimpleAI()
        {
            
            if (button11s.Text == "O" && button12s.Text == "O" && button13s.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button21s.Text == "O" && button22s.Text == "O" && button23s.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button31s.Text == "O" && button32s.Text == "O" && button33s.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button11s.Text == "O" && button22s.Text == "O" && button33s.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button31s.Text == "O" && button22s.Text == "O" && button13s.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button11s.Text == "O" && button21s.Text == "O" && button31s.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button12s.Text == "O" && button22s.Text == "O" && button32s.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button13s.Text == "O" && button23s.Text == "O" && button33s.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button11s.Text == "X" && button12s.Text == "X" && button13s.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button21s.Text == "X" && button22s.Text == "X" && button23s.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button31s.Text == "X" && button32s.Text == "X" && button33s.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button11s.Text == "X" && button22s.Text == "X" && button33s.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button31s.Text == "X" && button22s.Text == "X" && button13s.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button11s.Text == "X" && button21s.Text == "X" && button31s.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button12s.Text == "X" && button22s.Text == "X" && button32s.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button13s.Text == "X" && button23s.Text == "X" && button33s.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button11s.Text != "" && button12s.Text != "" && button13s.Text != "" && button21s.Text != "" && button22s.Text != ""
                    && button23s.Text != "" && button31s.Text != "" && button32s.Text != "" && button33s.Text != "")
            {
                MessageBox.Show("Its a Draw");
                return "Draw";
            }

            return "None";


        }
        private string CheckWhoWonDeepAI()
        {
            if (button11d.Text == "O" && button12d.Text == "O" && button13d.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button21d.Text == "O" && button22d.Text == "O" && button23d.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button31d.Text == "O" && button32d.Text == "O" && button33d.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button11d.Text == "O" && button22d.Text == "O" && button33d.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button31d.Text == "O" && button22d.Text == "O" && button13d.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            if (button11d.Text == "O" && button21d.Text == "O" && button31d.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            if (button12d.Text == "O" && button22d.Text == "O" && button32d.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            if (button13d.Text == "O" && button23d.Text == "O" && button33d.Text == "O")
            {
                MessageBox.Show(" AI Won!");
                return "AI";
            }
            else if (button11d.Text == "X" && button12d.Text == "X" && button13d.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button21d.Text == "X" && button22d.Text == "X" && button23d.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            //from here
            else if (button31d.Text == "X" && button32d.Text == "X" && button33d.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button11d.Text == "X" && button22d.Text == "X" && button33d.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            else if (button31d.Text == "X" && button22d.Text == "X" && button13d.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            if (button11d.Text == "X" && button21d.Text == "X" && button31d.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            if (button12d.Text == "X" && button22d.Text == "X" && button32d.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            if (button13d.Text == "X" && button23d.Text == "X" && button33d.Text == "X")
            {
                MessageBox.Show(" You Won!");
                return "Human";
            }
            if (button11d.Text != "" && button12d.Text != "" && button13d.Text != "" && button21d.Text != "" && button22d.Text != ""
                    && button23d.Text != "" && button31d.Text != "" && button32d.Text != "" && button33d.Text != "")
            {
                MessageBox.Show("Its a Draw");
                return "Draw";
            }

            return "None";


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 1252;
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Visible = false;
            }
            panelStart.Visible = true;
            panelStart.Dock = DockStyle.Fill;


        }
        // changes the modes
        private void buttonHumanMode_Click(object sender, EventArgs e)
        {
            AI_PlayingMode = "Human";

            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Visible = true;
            }
            panelStart.Visible = false;
            panel2.Visible = true;
            panelSimpleAI.Visible = false;
            panelDeepAI.Visible = false;

            labelMode.Text = "Human Vs Human";
            pictureBoxMode.BackgroundImage = Image.FromFile(Application.StartupPath + "\\player.jpg");
        }

        private void buttonAIMode_Click(object sender, EventArgs e)
        {
            AI_PlayingMode = "Simple AI";

            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Visible = true;
            }
            panelStart.Visible = false;
            panelDeepAI.Visible = false;
      
  
            labelMode.Text = "Human Vs Simple A.I.";
            pictureBoxMode.BackgroundImage = Image.FromFile(Application.StartupPath + "\\AI.jpg");
            panel2.Visible = false;
            panelSimpleAI.Visible = true;
            panelSimpleAI.Top = panel2.Top;
            panelSimpleAI.Left = panel2.Left;
        }

        private void buttonChangeMode_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Visible = false;
            }
            panelStart.Visible = true;
            panel2.Visible = false;
            panelSimpleAI.Visible = false;
            panelDeepAI.Visible = false;

            cleanButtons();

        }
        // simple AI buttons
        private void button11s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button11s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button11s.Enabled = false;
            if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button12s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button12s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button12s.Enabled = false;
             if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button13s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button13s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button13s.Enabled = false;
             if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button21s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button21s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button21s.Enabled = false;
             if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button22s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button22s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button22s.Enabled = false;
             if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button23s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button23s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button23s.Enabled = false;
             if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button31s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button31s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button31s.Enabled = false;
             if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button32s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button32s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button32s.Enabled = false;
             if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button33s_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button33s.Text = "X";
                labelMessage.Text = "A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Simple AI";
                AIPlaySimple();
            }
            button33s.Enabled = false;
             if (CheckWhoWonSimpleAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }


        private void buttonSmartAI_Click(object sender, EventArgs e)
        {
            AI_PlayingMode = "Deep AI";

            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Visible = true;
            }
            panelStart.Visible = false;
            panelSimpleAI.Visible = false;

            labelMode.Text = "Human Vs Deep A.I.";
            pictureBoxMode.BackgroundImage = Image.FromFile(Application.StartupPath + "\\AIthinking.jpg");
            panel2.Visible = false;
            panelDeepAI.Visible = true;
            panelDeepAI.Top = panel2.Top;
            panelDeepAI.Left = panel2.Left;
        }

        //deep ai buttons
        private void button11d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button11d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[0] = "X";
                AIPlayDeep();
            }
            button11d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }



        private void button12d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button12d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[1] = "X";
                AIPlayDeep();
            }
            button12d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button13d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button13d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[2] = "X";
                AIPlayDeep();
            }
            button13d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button21d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button21d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[3] = "X";
                AIPlayDeep();
            }
            button21d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button22d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button22d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[4] = "X";
                AIPlayDeep();
            }
            button22d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button23d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button23d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[5] = "X";
                AIPlayDeep();
            }
            button23d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button31d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button31d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[6] = "X";
                AIPlayDeep();
            }
            button31d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button32d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button32d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[7] = "X";
                AIPlayDeep();
            }
            button32d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }

        private void button33d_Click(object sender, EventArgs e)
        {
            if (currentPlayer == "Human")
            {
                button33d.Text = "X";
                labelMessage.Text = "Deep A.I's Turn";
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                currentPlayer = "Deep AI";
                spotsFillCondition[8] = "X";
                AIPlayDeep();
            }
            button33d.Enabled = false;
            if (CheckWhoWonDeepAI() != "None")
            {
                if (MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewGame_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Thanks for playing");
                    Application.Exit();
                }
            }
        }
        int Currentstep = 1;
        List<string> spotsFillCondition = new List<string>();
        //AI deep moves
        private void InitialFillOfspotsFillCondition()
        {
            spotsFillCondition.Clear();
            for (int i = 0; i < 9; i++)
            {
                spotsFillCondition.Add("");
            }
        }
        private void AIPlayDeep()
        {
            if(Currentstep == 1)
            {
                Random rnd = new Random();
                int i = rnd.Next(1, 5);
                if (i == 1) { spotsFillCondition[0] = "O"; }
                else if (i == 2) { spotsFillCondition[2] = "O"; }
                else if (i == 3) { spotsFillCondition[6] = "O"; }
                else if (i == 4) { spotsFillCondition[8] = "O"; }
                UpdateScreenLooks();
                Currentstep = 2;
                currentPlayer = "Human";
                labelMessage.Text = "Your Turn";
                return;
            }
           
            else if (Currentstep==2)
            {
                if (spotsFillCondition[0] == "O")
                {
                    TopLeftPlay();
                }
                else if (spotsFillCondition[2] == "O")
                {
                    TopRightPlay();
                }
                else if (spotsFillCondition[6] == "O")
                {
                    BottomLeftPlay();
                }
                else if (spotsFillCondition[8] == "O")
                {
                    BottomRightPlay();
                }

                UpdateScreenLooks();
                Currentstep = 3;
                currentPlayer = "Human";
                labelMessage.Text = "Your Turn";
                CheckWhoWon();
                return;
            }
            else if (Currentstep == 3)
            {
                CompPlayStep3();

                UpdateScreenLooks();
                Currentstep = 4;
                currentPlayer = "Human";
                labelMessage.Text = "Your Turn";
                CheckWhoWon();
                return;
            }
            else if (Currentstep == 4)
            {
                CompPlayStep4();

                UpdateScreenLooks();
                Currentstep = 5;
                currentPlayer = "Human";
                labelMessage.Text = "Your Turn";
                CheckWhoWon();
                return;
            }
            else if (Currentstep == 5)
            {
                CompPlayStep5();

                UpdateScreenLooks();
                Currentstep = 5;
                currentPlayer = "Human";
                labelMessage.Text = "Your Turn";
                CheckWhoWon();
                return;
            }







            UpdateScreenLooks();
            currentPlayer = "Human";
            labelMessage.Text = "Your Turn";




        }
        private void TopLeftPlay()
        {
            if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            //
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            //
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            //
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
        }
        private void TopRightPlay()
        {
            if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            //-------------------------
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
    spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
        }
        private void BottomLeftPlay()
        {
            if (
    spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
    )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            //-------------------------
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
    spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == ""
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                    )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
        }
        private void BottomRightPlay()
        {
            if (
    spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
    )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }

            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
        }

        private void CompPlayStep3()
        {
            if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            ////Extras top left gameplan
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = ""; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "X"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "X";
            }
            //Winning
            if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }

            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            //DEFENDING
            else if (
               spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
               spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
               spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
               )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }

            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }


            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "";
            }


            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }

            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = ""; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = ""; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                    spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                    spotsFillCondition[3] == "" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                    spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                    )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = ""; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }

            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[4] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[4] == "O" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[4] == "O" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }


            else if (
                spotsFillCondition[2] == "O" && spotsFillCondition[4] == "" && spotsFillCondition[6] == "O" 
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[2] == "O" && spotsFillCondition[4] == "O" && spotsFillCondition[6] == ""
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[2] == "" && spotsFillCondition[4] == "O" && spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }

        }
        private void CompPlayStep4()
        {
            if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "O" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "O" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "O" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "O" &&
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "O" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "O" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = ""; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = ""; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = ""; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }


            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "O" && spotsFillCondition[2] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "O" && spotsFillCondition[2] == ""
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
            }


            else if (
                spotsFillCondition[3] == "O" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "O"
                )
            {
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "O";
            }
            else if (
                spotsFillCondition[3] == "O" && spotsFillCondition[4] == "O" && spotsFillCondition[5] == ""
                )
            {
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "O";
            }
            else if (
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "O" && spotsFillCondition[5] == "O"
                )
            {
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "O";
            }


            else if (
                spotsFillCondition[0] == "O" &&
                spotsFillCondition[3] == "" &&
                spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[0] = "O";
                spotsFillCondition[3] = "O";
                spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" &&
                spotsFillCondition[3] == "O" &&
                spotsFillCondition[6] == ""
                )
            {
                spotsFillCondition[0] = "O";
                spotsFillCondition[3] = "O";
                spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[0] == "" &&
                spotsFillCondition[3] == "O" &&
                spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[0] = "O";
                spotsFillCondition[3] = "O";
                spotsFillCondition[6] = "O";
            }


            else if (
                spotsFillCondition[1] == "O" &&
                spotsFillCondition[4] == "" &&
                spotsFillCondition[7] == "O"
                )
            {
                spotsFillCondition[1] = "O";
                spotsFillCondition[4] = "O";
                spotsFillCondition[7] = "O";
            }
            else if (
                spotsFillCondition[1] == "O" &&
                spotsFillCondition[4] == "O" &&
                spotsFillCondition[7] == ""
                )
            {
                spotsFillCondition[1] = "O";
                spotsFillCondition[4] = "O";
                spotsFillCondition[7] = "O";
            }
            else if (
                spotsFillCondition[1] == "" &&
                spotsFillCondition[4] == "O" &&
                spotsFillCondition[7] == "O"
                )
            {
                spotsFillCondition[1] = "O";
                spotsFillCondition[4] = "O";
                spotsFillCondition[7] = "O";
            }

            else if (
                spotsFillCondition[2] == "O" &&
                spotsFillCondition[5] == "" &&
                spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[2] = "O";
                spotsFillCondition[5] = "O";
                spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[2] == "O" &&
                spotsFillCondition[5] == "O" &&
                spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[2] = "O";
                spotsFillCondition[5] = "O";
                spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[2] == "" &&
                spotsFillCondition[5] == "O" &&
                spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[2] = "O";
                spotsFillCondition[5] = "O";
                spotsFillCondition[8] = "O";
            }


            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[4] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[4] == "O" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[4] == "O" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }


            else if (
                spotsFillCondition[2] == "O" && spotsFillCondition[4] == "" && spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[2] == "O" && spotsFillCondition[4] == "O" && spotsFillCondition[6] == ""
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[2] == "" && spotsFillCondition[4] == "O" && spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }

        }
        private void CompPlayStep5()
        {
            if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "O" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "O" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "O" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "O" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "X" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "X"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "O" && spotsFillCondition[2] == "X" &&
                spotsFillCondition[3] == "X" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "X";
                spotsFillCondition[3] = "X"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "O";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "X" && spotsFillCondition[1] == "O" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "X" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "X"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "X"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "X" && spotsFillCondition[2] == "O" &&
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "X" && spotsFillCondition[5] == "X" &&
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == "X"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "X"; spotsFillCondition[2] = "O";
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "X"; spotsFillCondition[5] = "X";
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "X";
            }
            else if (
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[6] == "O" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[6] == "" && spotsFillCondition[7] == "O" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[6] = "O"; spotsFillCondition[7] = "O"; spotsFillCondition[8] = "O";
            }


            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "" && spotsFillCondition[2] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[1] == "O" && spotsFillCondition[2] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[1] == "O" && spotsFillCondition[2] == ""
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[1] = "O"; spotsFillCondition[2] = "O";
            }


            else if (
                spotsFillCondition[3] == "O" && spotsFillCondition[4] == "" && spotsFillCondition[5] == "O"
                )
            {
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "O";
            }
            else if (
                spotsFillCondition[3] == "O" && spotsFillCondition[4] == "O" && spotsFillCondition[5] == ""
                )
            {
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "O";
            }
            else if (
                spotsFillCondition[3] == "" && spotsFillCondition[4] == "O" && spotsFillCondition[5] == "O"
                )
            {
                spotsFillCondition[3] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[5] = "O";
            }


            else if (
                spotsFillCondition[0] == "O" &&
                spotsFillCondition[3] == "" &&
                spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[0] = "O";
                spotsFillCondition[3] = "O";
                spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" &&
                spotsFillCondition[3] == "O" &&
                spotsFillCondition[6] == ""
                )
            {
                spotsFillCondition[0] = "O";
                spotsFillCondition[3] = "O";
                spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[0] == "" &&
                spotsFillCondition[3] == "O" &&
                spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[0] = "O";
                spotsFillCondition[3] = "O";
                spotsFillCondition[6] = "O";
            }


            else if (
                spotsFillCondition[1] == "O" &&
                spotsFillCondition[4] == "" &&
                spotsFillCondition[7] == "O"
                )
            {
                spotsFillCondition[1] = "O";
                spotsFillCondition[4] = "O";
                spotsFillCondition[7] = "O";
            }
            else if (
                spotsFillCondition[1] == "O" &&
                spotsFillCondition[4] == "O" &&
                spotsFillCondition[7] == ""
                )
            {
                spotsFillCondition[1] = "O";
                spotsFillCondition[4] = "O";
                spotsFillCondition[7] = "O";
            }
            else if (
                spotsFillCondition[1] == "" &&
                spotsFillCondition[4] == "O" &&
                spotsFillCondition[7] == "O"
                )
            {
                spotsFillCondition[1] = "O";
                spotsFillCondition[4] = "O";
                spotsFillCondition[7] = "O";
            }

            else if (
                spotsFillCondition[2] == "O" &&
                spotsFillCondition[5] == "" &&
                spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[2] = "O";
                spotsFillCondition[5] = "O";
                spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[2] == "O" &&
                spotsFillCondition[5] == "O" &&
                spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[2] = "O";
                spotsFillCondition[5] = "O";
                spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[2] == "" &&
                spotsFillCondition[5] == "O" &&
                spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[2] = "O";
                spotsFillCondition[5] = "O";
                spotsFillCondition[8] = "O";
            }


            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[4] == "" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "O" && spotsFillCondition[4] == "O" && spotsFillCondition[8] == ""
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }
            else if (
                spotsFillCondition[0] == "" && spotsFillCondition[4] == "O" && spotsFillCondition[8] == "O"
                )
            {
                spotsFillCondition[0] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[8] = "O";
            }


            else if (
                spotsFillCondition[2] == "O" && spotsFillCondition[4] == "" && spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[2] == "O" && spotsFillCondition[4] == "O" && spotsFillCondition[6] == ""
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }
            else if (
                spotsFillCondition[2] == "" && spotsFillCondition[4] == "O" && spotsFillCondition[6] == "O"
                )
            {
                spotsFillCondition[2] = "O"; spotsFillCondition[4] = "O"; spotsFillCondition[6] = "O";
            }


        }
        private void UpdateScreenLooks()
        {
            button11d.Text = spotsFillCondition[0];

            button12d.Text = spotsFillCondition[1];

            button13d.Text = spotsFillCondition[2];

            button21d.Text = spotsFillCondition[3];

            button22d.Text = spotsFillCondition[4];

            button23d.Text = spotsFillCondition[5];

            button31d.Text = spotsFillCondition[6];
            
            button32d.Text = spotsFillCondition[7];

            button33d.Text = spotsFillCondition[8];

            for (int i = 0; i < panelDeepAI.Controls.Count; i++)
            {
                if (panelDeepAI.Controls[i].Text!="")
                {
                    panelDeepAI.Controls[i].Enabled = false;
                }
            }

        }
    }
    }