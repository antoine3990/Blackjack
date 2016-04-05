using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public static class Dealer
    {
        /// <summary>
        /// Réorganize aléatoirement une liste.
        /// </summary>
        /// <typeparam name="T">Type de la liste</typeparam>
        /// <param name="list">Liste a "randomize"</param>
        public static void shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<Player> getWinner(Player player1, Player player2, bool endGame)
        {
            List<Player> winner = new List<Player>();

            if (player1.status == Player.statuses.busting)
                winner.Add(player2);
            else if (player2.status == Player.statuses.busting)
                winner.Add(player1);
            else if (endGame)
            {
                if (player1.score == player2.score)
                    winner.AddRange(new List<Player> { player1, player2 });
                else
                    winner.Add(player1.score > player2.score ? player1 : player2);
            }

            return winner;
        }
    }
}
