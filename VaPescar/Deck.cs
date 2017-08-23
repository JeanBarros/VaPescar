using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaPescar
{
    public class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Card((Card.Suits)suit, (Card.Values)value));
        }

        public Deck(Card[] initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count { get { return cards.Count; } }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal(int index)
        {
            Card cardToDeal = cards[index];
            cards.RemoveAt(index);
            return cardToDeal;
        }

        /// <summary>
        /// Dá a carta do topo do baralho.
        /// </summary>
        /// <returns></returns>
        public Card Deal()
        { return Deal(0); }

        public void Shuffle()
        {
            List<Card> newCards = new List<Card>();
            while (cards.Count > 0)
            {
                int cardToMove = random.Next(cards.Count);
                newCards.Add(cards[cardToMove]);
                cards.RemoveAt(cardToMove);
            }
            cards = newCards;
        }

        public string[] GetCardNames()
        {
            string[] cardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
                cardNames[i] = cards[i].Name;
            return cardNames;
        }

        public void Sort()
        { cards.Sort(new CardComparer_byValue()); }

        /// <summary>
        /// Permite espiar uma carta do baralho sem ter que pegá-la.
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public Card Peek(int cardNumber)
        { return cards[cardNumber]; }

        /// <summary>
        /// Procura por todo o baralho o valor passado como parâmetro e retorna true se for encontrado.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(Card.Values value)
        {
            foreach (Card card in cards)
                if (card.Value == value)
                    return true;
            return false;
        }

        /// <summary>
        /// Procura pela carta com o valor passado pelo parâmetro, tira-a do baralho
        /// e retorna um baralho novo se essa carta.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Deck PullOutValues(Card.Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].Value == value)
                    deckToReturn.Add(Deal(i));
            return deckToReturn;
        }

        /// <summary>
        /// Checa se um baralho tem um livro com quatro cartas de qualquer valor
        /// passado como parâmetro. Retorna true se existir um livro no baralho.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasBook(Card.Values value)
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
                if (card.Value == value)
                    NumberOfCards++;
            if (NumberOfCards == 4)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ordena o baralho usando a classe CardComparer_byValue
        /// </summary>
        public void SortByValue()
        { cards.Sort(new CardComparer_byValue()); }
    }
}
