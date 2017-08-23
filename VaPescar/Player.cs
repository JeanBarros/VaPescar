using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaPescar
{
    public class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;
        public int CardCount { get { return cards.Count; } }

        public Player(string name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            this.cards = new Deck(new Card[] { });
            textBoxOnForm.Text += name + " has just joined the game \r\n";
        }

        public List<Card.Values> PullOutBooks()
        {
            List<Card.Values> Books = new List<Card.Values>();
            for (int i = 1; i <= 13; i++)
            {
                Card.Values value = (Card.Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                    if (cards.Peek(card).Value == value)
                        howMany++;
                if (howMany == 4)
                {
                    Books.Add(value);
                    for (int card = cards.Count - 1; card >= 0; card--)
                        cards.Deal(card);
                }
            }
            return Books;
        }

        /// <summary>
        /// Retorna um valor aleatório dentre os existentes no baralho.
        /// Usa o método "Peek()" para olhar uma carta aleatória na mão do jogador.
        /// </summary>
        /// <returns></returns>
        public Card.Values GetRandomValue()
        {
            Card randomCard = cards.Peek(random.Next(cards.Count));
            return randomCard.Value;
        }

        /// <summary>
        /// Pergunta se um oponente tem cartas de certo valor.
        /// Usa o método "PullOutValues() para retirar e retornar cartas equivalentes ao parâmetro".
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Deck DoYouHaveAny(Card.Values value)
        {
            Deck cardsIhave = cards.PullOutValues(value);
            textBoxOnForm.Text += Name + " has " + cardsIhave.Count + " "
                + Card.Plural(value) + "\r\n";
            return cardsIhave;
        }

        /// <summary>
        /// Usado pelos oponentes. Pega uma de suas cartas aleatoriamente e chama o
        /// outro método sobrecarregado.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="myIndex"></param>
        /// <param name="stock"></param>
        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            Card.Values randomValue = GetRandomValue();
            AskForACard(players, myIndex, stock, randomValue);
        }

        /// <summary>
        /// Itera por todos os jogadores, exceto aquele que está perguntando, chamando
        /// o método "DoYouHaveAny()" e adiciona qualquer carta que seja entregue
        /// na mão do jogador que pergunta.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="myIndex"></param>
        /// <param name="stock"></param>
        /// <param name="value"></param>
        public void AskForACard(List<Player> players, int myIndex, Deck stock, Card.Values value)
        {
            textBoxOnForm.Text += Name + " asks if anyone has a " + value + "\r\n";
            int totalCardsGiven = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (i != myIndex)
                {
                    Player player = players[i];
                    Deck CardsGiven = player.DoYouHaveAny(value);
                    totalCardsGiven += CardsGiven.Count;
                    while (CardsGiven.Count > 0)
                        cards.Add(CardsGiven.Deal());
                }
            }
            if (totalCardsGiven == 0)
                textBoxOnForm.Text += Name + " must draw from the stock. \r\n";
            cards.Add(stock.Deal());
        }

        public void TakeCard(Card card)
        { cards.Add(card); }

        public string[] GetCardNames() { return cards.GetCardNames(); }

        public Card Peek(int cardNumebr) { return cards.Peek(cardNumebr); }

        public void SortHand() { cards.SortByValue(); }
    }
}
