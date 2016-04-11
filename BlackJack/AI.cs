using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class AI : Player
    {
        public enum riskLevel { brave=50, standard=65, prudent=80 } //Le taux de pourcentage des AI
        
        private riskLevel behavior;
        public riskLevel Behavior { get; set; }

        private int lowestChanceOfHit { get; set; }
        public bool countingCard { get; set; }
        public int id { get; private set; }
        
        public AI(bool countingCard, riskLevel behavior, int id, Cards deck, int nbCards) : base(deck, nbCards)
        {
            this.countingCard = countingCard;
            this.behavior = behavior;
            lowestChanceOfHit = (int)behavior;
            this.id = id;
        }

        public bool play(Player opponent, Cards deck)
        {
            //Met a jour la console tout dependant ce que le AI fait
            if (this.status == statuses.standing)
            {
                addToLog("Standing.");
                return false;
            }
            else if (opponent.score == Program.POINTS_TO_WIN)
            {
                addToLog("Hitting. L'adversaire a un score de " + Program.POINTS_TO_WIN + ".");
                return true;
            }
            else if (this.score <= Program.POINTS_TO_WIN - 10)
            {
                addToLog("Hitting. Score moins élevé que " + (Program.POINTS_TO_WIN - 10).ToString() + ".");
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
            {
                stand();
                return false;
            }
        }

        private decimal chanceToWin(Cards originalDeck)
        {
            List<Card> deck = new List<Card>();
            List<Card> notBusting = new List<Card>();
            
            if (!countingCard)
                deck = new Cards().toList();    //Mets tous les cartes dans une liste
            else
                deck = originalDeck.toList().Select(card => new Card(card.suit, card.rank)).ToList();   //Compte les cartes joues si le AI compte les cartes

            foreach (Card card in deck)
                if (this.score + (card.rank > 10 ? 10 : card.rank) <= Program.POINTS_TO_WIN)    //Calcule les cartes qui peuvent pas le faire depasser 21
                    notBusting.Add(card);

            int goodCards = notBusting.Count;
            int totalCards = deck.Count;
            decimal chanceToWin = Math.Round(Decimal.Divide(goodCards, totalCards) * 100, 2);   //Calcul du taux de propabilites
            
            addToLog(defineLogText(goodCards, totalCards, chanceToWin));

            return chanceToWin;
        }
        
        public string defineLogText(int goodCards, int totalCards, decimal chanceToWin)
        {
            //Affiche a la console le tour de AI lorsqu'il demande une carte
            string status = "Standing";
            string sign = "<";
            string logText = "{0}. " + goodCards.ToString() + "/" + totalCards.ToString() + "(" + chanceToWin.ToString() + "%) {1} " + lowestChanceOfHit.ToString() + "%. {2}";
            bool showScore = true;

            if (chanceToWin >= lowestChanceOfHit)
            {
                status = "Hitting";
                if (chanceToWin > lowestChanceOfHit)
                    sign = ">";
                else
                    sign = "=";

                showScore = false;
            }

            return String.Format(logText, status, sign, showScore ? "Score = " + score.ToString() + "." : "");
        }

        public void addToLog(string text)
        {
            log.Add((id == -1 ? "AI" : "AI #" + id) + ": " + text);
        }
    }
}
