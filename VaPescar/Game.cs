using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaPescar
{
    public class Game
    {
        private List<Player> players;
        private Dictionary<Card.Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, string[] opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;

            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));

            foreach (string player in opponentNames)
                players.Add(new Player(player, random, textBoxOnForm));

            books = new Dictionary<Card.Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {
            stock.Shuffle();
            for (int i = 0; i < 5; i++)
                foreach (Player player in players)
                    player.TakeCard(stock.Deal());
            foreach (Player player in players)
                PullOutBooks(player);
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            Card.Values cardToAskFor = players[0].Peek(selectedPlayerCard).Value;
            for (int i = 0; i < players.Count; i++)
            {
                if (i == 0)
                    players[0].AskForACard(players, 0, stock, cardToAskFor);
                else
                    players[i].AskForACard(players, i, stock);
                if (PullOutBooks(players[i]))
                {
                    textBoxOnForm.Text += players[i].Name + " drew a new hand\r\n";
                    int card = 1;
                    while (card <= 5 && stock.Count > 0)
                    {
                        players[i].TakeCard(stock.Deal());
                        card++;
                    }
                }
                players[0].SortHand();
                if (stock.Count == 0)
                {
                    textBoxOnForm.Text = "The stock is out of cards. Game over!\r\n";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica as cartas de um jogador para ver se ele possui quatro do mesmo valor.
        /// Em caso afirmativo, elas são adicionadas ao dicionário de livros
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool PullOutBooks(Player player)
        {
            List<Card.Values> BooksPulled = player.PullOutBooks();
            foreach (Card.Values value in BooksPulled)
                books.Add(value, player);
            if (player.CardCount == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Transforma um dicionário de livros de um jogador em texto e exibe-o na caixa apropriada.
        /// </summary>
        /// <returns></returns>
        public string DescribeBooks()
        {
            string whoHasWichBooks = "";
            foreach (Card.Values value in books.Keys)
                whoHasWichBooks += books[value].Name + " has a book of "
                    + Card.Plural(value) + "\r\n";
            return whoHasWichBooks;
        }

        /// <summary>
        /// Determina quem ganhou o jogo, verificando em seu próprio dicionário quantos
        /// livros cada jogador adicionou no dicionário "Books".
        /// </summary>
        /// <returns></returns>
        public string GetWinnerName()
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();

            foreach (Card.Values value in books.Keys)
            {
                string name = books[value].Name;
                if (winners.ContainsKey(name))
                    winners[name]++;
                else
                    winners.Add(name, 1);
            }

            int mostBooks = 0;
            foreach (string name in winners.Keys)
                if (winners[name] > mostBooks)
                    mostBooks = winners[name];
            bool tie = false;
            string winnerList = "";
            foreach (string name in winners.Keys)
                if(winners[name]==mostBooks)
                {
                    if(!string.IsNullOrEmpty(winnerList))
                    {
                        winnerList += " and ";
                        tie = true;
                    }
                    winnerList += name;
                }
            winnerList += " with " + mostBooks + " books";
            if (tie)
                return "A tie between " + winnerList;
            else
                return winnerList;
        }

        public string[] GetPlayerCardNames()
        { return players[0].GetCardNames(); }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " has " + players[i].CardCount;
                if (players[i].CardCount == 1)
                    description += " card.\r\n";
                else
                    description += " cards.\r\n";
            }
            description += "The stock has " + stock.Count + " cards left.";
            return description;
        }
    }
}
