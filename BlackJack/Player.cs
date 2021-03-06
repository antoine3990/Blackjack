﻿using System;
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

        public enum statuses { playing, standing, busting, paused } //Status possible pour les joueurs
        public statuses status { get; private set; }
        public List<string> log { get; private set; }

        public Player(Cards deck, int nbCards)
        {
            cards = new List<Card>();
            log = new List<string>();
            status = statuses.playing;

            giveCards(deck, nbCards);
        }

        private void giveCards(Cards deck, int nbCards)
        {
            for (int i = 0; i < nbCards; i++)
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
                if (getAs() > 0 && getAs() > asReduced && score > Program.POINTS_TO_WIN)
                {
                    score -= 10;
                    asReduced++;
                }
            }

            if (score == Program.POINTS_TO_WIN) //Modifie le status si le joueur/AI atteint 21
                status = statuses.standing;
            else if (score > Program.POINTS_TO_WIN) //Modifie le status si le joueur/AI depasse 21
                status = statuses.busting;

            return newCard;
        }

        public void reset(Cards deck, int nbCards)
        {
            score = 0;
            cards.Clear();  //Vide la lsite de carte donnee
            log.Clear();    //Vide la console
            status = statuses.playing;  //Mets le status des joueurs a jour

            giveCards(deck, nbCards);   //Distribue les cartes
        }

        public void stand()
        {
            status = statuses.standing; //Affect le status au joueur
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

            foreach (Card c in cards)   //Retourne le nombre d'As
                if (c.rank == 1)
                    count++;

            return count;
        }
    }
}
