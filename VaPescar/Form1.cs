using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaPescar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter your name", "Can't start the game yet");
                return;
            }

            game = new Game(txtName.Text, new string[] { "Joe", "Bob" }, textProgress);
            btnStart.Enabled = false;
            txtName.Enabled = false;
            btnAsk.Enabled = true;
            UpdateForm();
        }

        private void UpdateForm()
        {
            listHand.Items.Clear();
            foreach (string cardName in game.GetPlayerCardNames())
                listHand.Items.Add(cardName);
            textBooks.Text = game.DescribeBooks();
            textProgress.Text += game.DescribePlayerHands();
            textProgress.SelectionStart = textProgress.Text.Length;
            textProgress.ScrollToCaret();
        }

        private void btnAsk_Click(object sender, EventArgs e)
        {
            textProgress.Text = "";
            if(listHand.SelectedIndex<0)
            {
                MessageBox.Show("Please select a card");
                return;
            }
            if (game.PlayOneRound(listHand.SelectedIndex))
            {
                textProgress.Text += "The winner is..." + game.GetWinnerName();
                textBooks.Text = game.DescribeBooks();
                btnAsk.Enabled = false;
            }
            else
                UpdateForm();
        }
    }
}
