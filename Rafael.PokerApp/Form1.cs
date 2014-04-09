using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rafael.ValueObject;
using Rafael.ValueObject.Enum;
using Rafael.Engine;
using Rafael.BusinessObjects;

namespace Rafael.PokerApp
{
    public partial class frmAppPoker : Form
    {

        Player PlayerOne = new Player();
        Player PlayerTwo = new Player();
        CardBO cardBO = new CardBO();

        private string[] cardsPlayerOne;
        private string[] cardsPlayerTwo;

        public frmAppPoker()
        {
            InitializeComponent();

        }

        //Assigns the name of each player
        private void setPlayers()
        {
            try
            {
                PlayerOne.Name = "Black";
                PlayerTwo.Name = "White";
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Separates the cards of each player
        private void setCardsForPlayers(string cartas)
        {
            try
            {
                cardsPlayerOne = txtInput.Text.ToString().Substring(0, 14).ToString().Split(' ');

                List<Card> listCardsP1 = new List<Card>();
                foreach (string cardsP1 in cardsPlayerOne)
                {
                    Card cartasP1 = new Card();
                    cartasP1.Value = CardMatriz.Values[cardsP1.Substring(0, 1).ToString()];
                    cartasP1.Nipe = (EnumNipe)Enum.Parse(typeof(EnumNipe), cardsP1.Substring(1).ToString());
                    cartasP1.Sequence = CardMatriz.Sequence[cardsP1.Substring(0, 1).ToString()];

                    listCardsP1.Add(cartasP1);
                }
                PlayerOne.Cards = listCardsP1;

                cardsPlayerTwo = txtInput.Text.ToString().Substring(15).ToString().Split(' ');

                List<Card> listCardsP2 = new List<Card>();
                foreach (string cardsP2 in cardsPlayerTwo)
                {
                    Card cartasP2 = new Card();

                    cartasP2.Value = CardMatriz.Values[cardsP2.Substring(0, 1).ToString()];
                    cartasP2.Nipe = (EnumNipe)Enum.Parse(typeof(EnumNipe), cardsP2.Substring(1).ToString());
                    cartasP2.Sequence = CardMatriz.Sequence[cardsP2.Substring(0, 1).ToString()];

                    listCardsP2.Add(cartasP2);
                }
                PlayerTwo.Cards = listCardsP2;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool cardsValidation(string cards)
        {
            //checks the number of cards
            if (cards.Length != 29)
            {
                MessageBox.Show("Number of cards is invalid");
                return false;
            }
            return true;
        }

        private string getWinnerRule(int rule)
        {
            switch (rule)
            {
                case 0:
                    return "Tie";
                case 1:
                    return "High Card";
                case 2:
                    return "Pair";
                case 3:
                    return "Double Pair";
                case 4:
                    return "Three of a kind";
                case 5:
                    return "Straight";
                case 6:
                    return "Flush";
                case 7:
                    return "Full House";
                case 8:
                    return "Four of a Kind";
                case 9:
                    return "Straight Flush";
                default:
                    return "";
            }
        }


        private void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutput.Text = "";
                if (cardsValidation(txtInput.Text.ToString()))
                {
                    setPlayers();
                    setCardsForPlayers(txtInput.Text.ToString());

                    List<Player> winnerPlayer = new List<Player>();

                    winnerPlayer = cardBO.GetTotalPoints(PlayerOne, PlayerTwo);

                    //If 2 players returning is because there was a tie.
                    if (winnerPlayer.Count == 2 )
                    {
                        txtOutput.Text = getWinnerRule(0);
                    }
                    else
                    {
                        txtOutput.Text = winnerPlayer[0].Name + " Wins - " + getWinnerRule(winnerPlayer[0].Rules);
                    }
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

    }
}
