using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public abstract class Player
    {
        public List<Card> cards { get; private set; }
        public int score { get; private set; }
        private int asReduced = 0; // Nombre d'As dont le score a été réduit de 11 à 1.

        public enum statuses { playing, standing, busting, paused }
        public statuses status { get; private set; }
        public List<string> log { get; private set; }

        public Player(Cards deck)
        {
            cards = new List<Card>();
            log = new List<string>();
            status = statuses.playing;

            for (int i = 0; i < 2; i++)
                hit(deck);
        }

        public Card hit(Cards deck)
        {
            Card newCard = deck.get();
            cards.Add(newCard);

            // Si la carte pigée est un As
            if (newCard.rank == 1)
            {
                // Incrémenter de 1 si le score est plus haut que 10, sinon de 11.
                if (score <= 10)
                {
                    score += 11;
                    asReduced++;
                }
                else
                    score += newCard.rank;
            }
            else
            {
                // Incrémenter le score du rang de la carte jusqu'à un maximum de 10.
                score += newCard.rank > 10 ? 10 : newCard.rank;

                // Si le joueur possède un as compté à 11 points, réduire cet as à 1 point.
                if (getAs() > 0 && getAs() > asReduced && score > 21)
                {
                    score -= 10;
                    asReduced++;
                }
            }

            if (score == 21)
                status = statuses.standing;
            else if (score > 21)
                status = statuses.busting;

            return newCard;
        }

        public void reset()
        {
            score = 0;
            cards.Clear();
            log.Clear();
            status = statuses.playing;
        }

        public void stand()
        {
            status = statuses.standing;
        }

        public string getLastLog()
        {
            if (log.Count > 0)
                return log[log.Count - 1];
            else
                return null;
        }

        public int getAs()
        {
            int count = 0;

            foreach (Card c in cards)
                if (c.rank == 1)
                    count++;

            return count;
        }
    }
}
