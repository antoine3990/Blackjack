using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public enum suits { carreau = 1, trèfle = 2, coeur = 3, pique = 4 }

        public int suit { get; private set; }
        public int rank { get; private set; }
        public Image img { get; private set; }

        public Card(int suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
            setImg();
        }

        public Card(Card newCard)
        {
            this.suit = newCard.suit;   //Affecte la couleur de la carte
            this.rank = newCard.rank;   //Affecte la valeur de la carte
            setImg();
        }

        private void setImg()
        {
            img = (Image)Properties.Resources.ResourceManager.GetObject("_" + suit.ToString() + rank.ToString());   //Affecte l'image correspondant a la carte
        }
    }

    public class Cards
    {
        private const int decks = 1;
        private const int cardsPerDeck = 13;

        private List<Card> cards { get; set; }

        public Cards()
        {
            fill();
        }

        private void fill()
        {
            cards = new List<Card>();

            foreach (Card.suits suit in Enum.GetValues(typeof(Card.suits))) //Ajoute toutes les cartes a une liste
            {
                for (int i = 1; i <= cardsPerDeck; i++)
                    cards.Add(new Card((int)suit, i));
            }

            Dealer.shuffle(cards);
        }

        public Card get()
        {
            Card toReturn = new Card(cards[0]);
            cards.RemoveAt(0);

            if (cards.Count == 0)   //Si le paquet est vide, remplir le paquet
                fill();

            return toReturn;
        }

        public List<Card> toList()
        {
            return cards;   //Retourne la liste de cartes
        }
    }
}
