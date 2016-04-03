﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class AI : Player
    {
        public enum riskLevel { brave=50, standard=65, prudent=80 }
        
        private riskLevel behavior;
        public riskLevel Behavior
        {
            get { return behavior; }
            set
            {
                behavior = value;
                lowestChanceOfHit = (int)behavior;
            }
        }

        private int lowestChanceOfHit { get; set; }
        public bool countingCard { get; set; }
        public int id { get; private set; }
        
        public AI(bool countingCard, riskLevel behavior, int id = -1)
        {
            this.countingCard = countingCard;
            this.behavior = behavior;
            this.id = id;
        }

        public bool play(Player opponent, Cards deck)
        {
            if (this.status == statuses.standing)
            {
                addToLog("Standing.");
                return false;
            }
            else if (this.score <= 11 || opponent.score == 21)
            {
                addToLog("Hitting. Score moins élevé que 12.");
                return true;
            }
            else if (this.score < opponent.score && opponent.status == statuses.standing)
            {
                addToLog("Hitting. Score moins élevé que l'adversaire qui est en état 'Standing'.");
                return true;
            }

            if (chanceToWin(deck) >= lowestChanceOfHit)
                return true;
            else
                return false;
        }

        private int chanceToWin(Cards deck)
        {
            List<Card> notBusting = new List<Card>();
            
            if (!countingCard)
                deck = new Cards();

            foreach (Card card in deck.toList())
                if (this.score + (card.rank > 10 ? 10 : card.rank) <= 21)
                    notBusting.Add(card);

            int goodCards = notBusting.Count;
            int totalCards = deck.toList().Count;
            int chanceToWin = (goodCards / totalCards) * 100;
            
            addToLog(defineLogText(goodCards, totalCards, chanceToWin));

            return chanceToWin;
        }
        
        public string defineLogText(int goodCards, int totalCards, int chanceToWin)
        {
            string status = "Standing";
            string sign = "<";
            string logText = "{0}. " + goodCards.ToString() + "/" + totalCards.ToString() + "(" + chanceToWin.ToString() + "%) {1} " + lowestChanceOfHit.ToString() + "%.";

            if (chanceToWin >= lowestChanceOfHit)
            {
                status = "Hitting";
                if (chanceToWin > lowestChanceOfHit)
                    sign = ">";
                else
                    sign = "=";
            }

            return String.Format(logText, status, sign);
        }

        public void addToLog(string text)
        {
            log.Add((id == -1 ? "AI" : "AI #" + id) + ": " + text);
        }
    }
}
