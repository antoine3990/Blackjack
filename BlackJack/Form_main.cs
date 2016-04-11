using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form_main : Form
    {
        public List<Player> players = new List<Player>(); // Joueurs
        private Cards deck; // Jeu de cartes
        private Form_console console; // Console de jeu (log)

        private int currentPlayer = -1; // Joueur courrant
        private const int STARTING_CARDS = 1; // Nombre de cartes par joueur au départ
        private bool winnerShowed = false; // Un gagnant à été affiché

        public Form_main()
        {
            deck = new Cards(); // Créer un nouveau jeu de carte

            InitializeComponent(); // Initialiser les contrôles
            initComboBoxDifficulty(); // Initialiser le combobox de difficulté des AI
            showCards(); // Afficher les cartes sur le jeu
        }

        #region Player selection

        // Lorsque le bouton de 'Compte les cartes' est cliqué
        private void BT_cardCounter_Click(object send, EventArgs e)
        {
            Button sender = (Button)send;

            // Si le bouton est activé, le désactiver et changer son background. Vice-versa.
            if (sender.Tag.ToString() == "yes")
            {
                sender.BackgroundImage = Properties.Resources.incorrect_small;
                sender.Tag = "no";
            }
            else
            {
                sender.BackgroundImage = Properties.Resources.correct_small;
                sender.Tag = "yes";
            }
        }
        private void BT_start_Click(object sender, EventArgs e)
        {
            // Vérifier si deux joueurs(types) ont été sélectionnés.
            if (!playersAreSelected())
                return;

            // Ajouter les joueurs
            for (int i = 1; i <= 2; i++)
            {
                ComboBox CB = (ComboBox)Controls["PNL_main"].Controls["CB_player" + i.ToString()];
                
                if (CB.SelectedIndex == 0)
                    addUser(i); // Ajoute un Humain
                else
                    addAI(i); // Ajoute un AI

                // S'il y a eu une erreur lors de la création d'un joueur, quitter la méthode.
                if (players.Count < i)
                    return;
            }

            // Afficher le panel de jeu
            PNL_game.Show();
            PNL_game.BringToFront();
            changePlayer(); // Commencer le jeu par le joueur 1
            
            console = new Form_console(this);
            console.Show(); // Afficher la console

            setStartingCards(); // Afficher les cartes que les joueurs ont obtenues au départ de la partie
            setButtons(); // Afficher les boutons de jeu

            // Faire jouer le premier joueur si c'est un AI
            playFirstAI();
        }
        private void CB_player_SelectedIndexChanged(object send, EventArgs e)
        {
            ComboBox sender = (ComboBox)send;
            string numPlayer = sender.Name.Substring(9, 1); // Numéro du joueur (0|1)

            // Si 'Humain' est sélectionné, afficher la textbox du nom
            if (sender.SelectedIndex == 0)
            {
                Controls["PNL_main"].Controls["TB_name" + numPlayer].Show();
                resetAiSettings(numPlayer);
            }
            // Sinon, afficher le combobox de difficulté des AI + le bouton de 'Compter les cartes'
            else if (sender.SelectedIndex == 1)
            {
                Controls["PNL_main"].Controls["TB_name" + numPlayer].Hide();
                Controls["PNL_main"].Controls["CB_difficulty" + numPlayer].Show();
                Controls["PNL_main"].Controls["BT_cardCounter" + numPlayer].Show();
            }

            // Afficher le label 'Compte les cartes'
            showLabelCardCounter();
        }
        
        private void addUser(int i)
        {
            string name = ((TextBox)Controls["PNL_main"].Controls["TB_name" + i.ToString()]).Text;
            int minLength = 3;
            if (name.Length < minLength)
            {
                MessageBox.Show("Le nom du joueur #" + i.ToString() + " doit comporter au moins " + minLength.ToString() + " lettres.");
                players.Clear();
                return;
            }

            players.Add(new User(name, deck, STARTING_CARDS));
        }
        private void addAI(int i)
        {
            int difficulty = ((ComboBox)Controls["PNL_main"].Controls["CB_difficulty" + i.ToString()]).SelectedIndex;
            bool cardCounter = ((Button)Controls["PNL_main"].Controls["BT_cardCounter" + i.ToString()]).Tag.ToString() == "yes";
            AI.riskLevel risk = difficulty == 0 ? AI.riskLevel.prudent : difficulty == 1 ? AI.riskLevel.standard : AI.riskLevel.brave;

            players.Add(new AI(cardCounter, risk, i, deck, STARTING_CARDS));
        }

        private void initComboBoxDifficulty()
        {
            foreach (AI.riskLevel risk in Enum.GetValues(typeof(AI.riskLevel)))
            {
                string riskName = Enum.GetName(typeof(AI.riskLevel), risk);
                riskName = riskName.Substring(0, 1).ToUpper() + riskName.Substring(1);

                for (int i = 1; i <= 2; i++)
                    ((ComboBox)Controls["PNL_main"].Controls["CB_difficulty" + i.ToString()]).Items.Add(riskName);
            }

            for (int i = 1; i <= 2; i++)
                ((ComboBox)Controls["PNL_main"].Controls["CB_difficulty" + i.ToString()]).SelectedIndex = 0;
        }
        private void showLabelCardCounter()
        {
            bool oneAI = false;
            for (int i = 1; i <= 2; i++)
            {
                if (((ComboBox)Controls["PNL_main"].Controls["CB_player" + i.ToString()]).SelectedIndex == 1)
                    oneAI = true;
            }
            LB_cardCounter.Visible = oneAI;
        }

        private bool playersAreSelected()
        {
            // Vérifier si deux joueurs(types) ont été sélectionnés.
            for (int i = 1; i <= 2; i++)
            {
                ComboBox CB = (ComboBox)Controls["PNL_main"].Controls["CB_player" + i.ToString()];
                if (CB.SelectedIndex != 0 && CB.SelectedIndex != 1)
                {
                    MessageBox.Show("Veuillez sélectionner un joueur #" + i.ToString() + ".");
                    return false;
                }
            }

            return true;
        }
        private void resetAiSettings(string numPlayer)
        {
            Controls["PNL_main"].Controls["CB_difficulty" + numPlayer].Hide();

            Control BT_cardCounter = Controls["PNL_main"].Controls["BT_cardCounter" + numPlayer];
            BT_cardCounter.Hide();

            ((ComboBox)Controls["PNL_main"].Controls["CB_difficulty" + numPlayer]).SelectedIndex = 0;

            if (BT_cardCounter.Tag.ToString() == "yes")
                BT_cardCounter_Click(BT_cardCounter, new EventArgs());
        }

        #endregion

        #region Game panel
        
        private void BT_stand_Click(object sender, EventArgs e)
        {
            Player current = players[currentPlayer]; // joueur courant
            current.stand(); // Stand
            
            ((User)current).addToLog("Standing."); // Ajouter un texte à la console
            console.showLog(current); // Afficher dans la console
            
            updatePlayerLabels(); // Update le label d'informations des joueurs 
            
            changePlayer(); // Changer de joueur
            getWinner(); // Afficher le gagnant, s'il y en a.

            if (players[currentPlayer] is AI)
                hit();
        }
        private void BT_hit_Click(object sender, EventArgs e)
        {
            hit();
        }
        private void BT_pause_Click(object sender, EventArgs e)
        {
            BT_pause.Visible = !BT_pause.Visible;
            hit();
        }

        private void BT_restart_Click(object sender, EventArgs e)
        {
            restart();
        }
        private void BT_toMain_Click(object sender, EventArgs e)
        {
            toMain();
        }

        private void setButtons()
        {
            bool allAi = true;
            foreach (Player p in players)
                if (p is User)
                    allAi = false;

            if (!allAi)
            {
                BT_hit.Show();
                BT_stand.Show();
                BT_pause.Hide();
            }
            else
            {
                BT_hit.Hide();
                BT_stand.Hide();
                BT_pause.Show();
            }
        }

        private void showCards()
        {
            for (int i = deck.toList().Count; i > 0; i--)
            {
                Controls["PNL_game"].Controls.Add(createCard(i));
                Controls["PNL_game"].Controls["PB_card" + i.ToString()].BringToFront();
            }
            Update();
        }
        private PictureBox createCard(int cardNum)
        {
            PictureBox pb = new PictureBox();
            pb.Name = "PB_card" + cardNum.ToString();
            pb.Size = new Size(121, 173);
            pb.Location = new Point(945 + cardNum, 48);
            pb.BackgroundImage = Properties.Resources.back;
            pb.BackgroundImageLayout = ImageLayout.Zoom;
            pb.BackColor = Color.Transparent;
            pb.Visible = true;
            pb.Tag = "deck";

            return pb;
        }
        
        public bool cardsRotated = false;
        public void resizeCards()
        {
            for (int i = 52; i > 0; i--)
            {
                PictureBox pb = (PictureBox)Controls["PNL_game"].Controls["PB_card" + i.ToString()];

                if (!cardsRotated)
                    pb.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else
                    pb.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            Update();
            Refresh();
        }
        
        #endregion

        #region Player Operations

        private void hit()
        {
            BT_hit.Enabled = false;
            Player current = players[currentPlayer];
            Card newCard = new Card(-1, -1);
            int oldScore = current.score;

            if (current is AI)
            {
                if (((AI)current).play(players[currentPlayer == 0 ? 1 : 0], deck))
                {
                    console.showLog(current);
                    newCard = current.hit(deck);

                    if (oldScore >= current.score)
                        ((AI)current).addToLog("Le pointage d'un As à été réduit à 1. Score -10.");

                    updateHitCard(deck.toList().Count, currentPlayer, current.cards.Count);
                    setHitLog(current, newCard, oldScore);
                    console.showLog(current);

                    LB_playerScore.Text = "Score: " + current.score.ToString();
                }
                else
                    console.showLog(current);

                updatePlayerLabels();

                Player opponent = players[currentPlayer == 0 ? 1 : 0];
                if (opponent is AI || (opponent is User && opponent.status == Player.statuses.standing))
                {
                    if (getWinner() == 0)
                    {
                        changePlayer();
                        hit();
                    }
                    else
                        return;
                }
            }
            else
            {
                newCard = current.hit(deck);
                
                updateHitCard(deck.toList().Count, currentPlayer, current.cards.Count);
                setHitLog(current, newCard, oldScore);
                console.showLog(current);
            }

            LB_playerScore.Text = "Score: " + current.score.ToString();
            changePlayer();

            updatePlayerLabels();

            if (getWinner() == 0)
            {
                if (players[currentPlayer] is AI)
                    hit();
            }
            else
                return;

            BT_hit.Enabled = true;
        }
        private void updateHitCard(int cards, int player, int playerCards)
        {
            PictureBox card = (PictureBox)Controls["PNL_game"].Controls["PB_card" + (52 - cards).ToString()];
            card.Tag = "player" + (player + 1).ToString();
            card.BackgroundImage = players[player].cards[playerCards - 1].img;
            card.BringToFront();

            int maxCards = 6;
            int x = (164 * (player == 0 ? 1 : 4) + ((playerCards > maxCards ? playerCards % maxCards : playerCards) + 1) * 30);
            int y = 335 + (int)(playerCards > maxCards ? Decimal.Floor(playerCards / maxCards) * 60 : 0);
            card.Location = new Point(x, y);

            if (cardsRotated)
                card.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);

            Update();
            Refresh();
        }
        private void setHitLog(Player player, Card card, int oldScore)
        {
            string[] cardNames = { "As", "Valet", "Dame", "Roi" };

            string text = "Pige un{0} {1} de {2}, score +{3}. Score = {4}. {5}.";
            string genre = card.rank == 12 ? "e" : "";
            string rank = card.rank == 1 ? cardNames[card.rank - 1] : card.rank > 10 ? cardNames[card.rank - 10] : card.rank.ToString();
            string suit = Enum.GetName(typeof(Card.suits), card.suit);
            suit = suit.Substring(0, 1).ToUpper() + suit.Substring(1);
            string score = card.rank == 1 ? player.score - oldScore == 1 ? "1" : "11" : card.rank > 10 ? "10" : card.rank.ToString();
            string status = Enum.GetName(typeof(Player.statuses), player.status);
            status = status.Substring(0, 1).ToUpper() + status.Substring(1);

            text = string.Format(text, genre, rank, suit, score, player.score.ToString(), status);

            if (player is AI)
                ((AI)player).addToLog(text);
            else
                ((User)player).addToLog(text);
        }
        private void setStartingCards()
        {
            int cardsToGive = players.Count * STARTING_CARDS;
            for (int i = players.Count; i > 0; i--)
                for (int j = 1; j <= STARTING_CARDS; j++)
                    updateHitCard((deck.toList().Count - cardsToGive / i + j) + (STARTING_CARDS * 2 - 1), i - 1, j);
        }

        private void changePlayer()
        {
            currentPlayer = currentPlayer == players.Count - 1 ? 0 : currentPlayer + 1;
            Player current = players[currentPlayer];

            if (current.status == Player.statuses.playing)
            {
                if (current is AI)
                    LB_playerName.Text = "AI #" + ((AI)current).id.ToString();
                else
                    LB_playerName.Text = ((User)current).name;

                LB_playerScore.Text = "Score: " + current.score.ToString();
            }
            else
                currentPlayer = currentPlayer == players.Count - 1 ? 0 : currentPlayer + 1;

            updatePlayerLabels();
        }
        private void updatePlayerLabels()
        {
            for (int i = 0; i < players.Count; i++)
            {
                string name = players[i] is AI ? "AI #" + ((AI)players[i]).id.ToString() : ((User)players[i]).name;
                string status = Enum.GetName(typeof(Player.statuses), players[i].status);
                status = status.Substring(0, 1).ToUpper() + status.Substring(1);

                Controls["PNL_game"].Controls["LB_details" + (i + 1).ToString()].Text = name + " : " + status;
            }
        }

        private void playFirstAI()
        {
            // Vérifie si tout les joueurs sont des Humain
            bool allAI = true;
            foreach (Player p in players)
                if (p is User)
                    allAI = false;

            // S'il y a au moins un AI et que c'est le premier joueur, il hit.
            if (!allAI && players[0] is AI)
                hit();
        }

        private int getWinner()
        {
            bool endGame = players[0].status == Player.statuses.standing && players[1].status == Player.statuses.standing;
            List<Player> winners = Dealer.getWinner(players[0], players[1], endGame);

            if (winners.Count > 0)
            {
                if (winners.Count == 1 && !winnerShowed)
                    showWinner(winners[0]);
                else
                    showWinner(null);
            }

            return winners.Count();
        }
        private void showWinner(Player winner)
        {
            if (!winnerShowed)
            {
                winnerShowed = true;

                string endText = "FIN DE LA PARTIE. {0}.";
                if (winner == null)
                    endText = String.Format(endText, "La partie est nulle");
                else
                {
                    string name = (winner is AI ? "AI #" + ((AI)winner).id : ((User)winner).name).ToUpper();
                    string winnerText = "Le gagnant est {0} avec un score de {1} (vs {2})";
                    string opponentScore = (winner == players[0] ? players[1].score : players[0].score).ToString();

                    endText = String.Format(endText, String.Format(winnerText, name, winner.score, opponentScore));
                }

                PNL_victory.Show();
                PNL_victory.BringToFront();

                for (int i = 1; i <= 52; i++)
                {
                    Control c = Controls["PNL_game"].Controls.Find("PB_card" + i.ToString(), true)[0];
                    if (c.Tag.ToString().StartsWith("player"))
                        c.BringToFront();
                }

                for (int i = 1; i <= players.Count; i++)
                    Controls["PNL_game"].Controls["LB_details" + i.ToString()].BringToFront();

                Update();

                LB_winner.Text = endText.Substring(endText.IndexOf(".") + 1);

                console.showLog(endText);
            }
        }

        #endregion

        #region Game Operations

        public void reset()
        {
            BT_hit.Enabled = true;
            winnerShowed = false;
            setButtons();

            currentPlayer = 0;
            LB_playerScore.Text = "Score: ";
            LB_playerName.Text = players[currentPlayer] is AI ? "AI #" + ((AI)players[currentPlayer]).id : ((User)players[currentPlayer]).name;

            PNL_victory.Hide();

            for (int i = 1; i <= 52; i++)
                Controls["PNL_game"].Controls.Remove(Controls["PNL_game"].Controls.Find("PB_card" + i.ToString(), true)[0]);
            
            Update();
            Refresh();
        }
        public void restart()
        {
            deck = new Cards();
            reset();
            showCards();

            foreach (Player p in players)
                p.reset(deck, STARTING_CARDS);

            setStartingCards();

            Form toClose = null;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "Form_console")
                {
                    toClose = form;
                    break;
                }
            }

            if (toClose != null)
                toClose.Close();

            console = new Form_console(this);
            console.Show();

            updatePlayerLabels();

            setButtons();

            // Faire jouer le premier joueur si c'est un AI
            playFirstAI();
        }
        public void toMain()
        {
            reset();

            for (int i = 1; i <= players.Count; i++)
            {
                ((ComboBox)Controls["PNL_main"].Controls["CB_player" + i.ToString()]).SelectedIndex = 0;
                Controls["PNL_main"].Controls["TB_name" + i.ToString()].Text = "";
                resetAiSettings(i.ToString());
            }
            players.Clear();

            PNL_main.Show();
            PNL_main.BringToFront();
        }

        #endregion
    }
}