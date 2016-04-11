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

        private int currentPlayer = -1; // Joueur courant
        private const int STARTING_CARDS = 1; // Nombre de cartes par joueur au départ
        private bool winnerShowed = false; // Un gagnant à été affiché

        public Form_main()
        {
            Program.createNewGame = false; // Réouvrir une fenêtre de jeu après avoir gagner
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

            setStartingCards(); // Attribuer les cartes que les joueurs ont obtenues au départ de la partie
            setButtons(); // Afficher les boutons de jeu
            updatePlayerLabels(); // Update le label d'information des joueurs
            
            playFirstAI(); // Faire jouer le premier joueur si c'est un AI
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
            string name = ((TextBox)Controls["PNL_main"].Controls["TB_name" + i.ToString()]).Text; // Nom du joueur
            int minLength = 3; // Longueur du nom minimale

            // Si le nom du joueur n'est pas assez long
            if (name.Length < minLength)
            {
                // Afficher un message d'erreur
                MessageBox.Show("Le nom du joueur #" + i.ToString() + " doit comporter au moins " + minLength.ToString() + " lettres.");
                players.Clear(); // Supprimer tout les joueurs
                return; // Quitter la méthode
            }
            
            players.Add(new User(name, deck, STARTING_CARDS)); // Ajouter un humain
        }
        private void addAI(int i)
        {
            // Difficulté de l'AI
            int difficulty = ((ComboBox)Controls["PNL_main"].Controls["CB_difficulty" + i.ToString()]).SelectedIndex;
            // L'AI est un compteur de carte ?
            bool cardCounter = ((Button)Controls["PNL_main"].Controls["BT_cardCounter" + i.ToString()]).Tag.ToString() == "yes";
            // Niveau de risque de l'AI
            AI.riskLevel risk = difficulty == 0 ? AI.riskLevel.prudent : difficulty == 1 ? AI.riskLevel.standard : AI.riskLevel.brave;

            players.Add(new AI(cardCounter, risk, i, deck, STARTING_CARDS)); // Ajouter l'AI
        }

        private void initComboBoxDifficulty()
        {
            // Pour tout les niveaux de risques disponibles de l'AI
            foreach (AI.riskLevel risk in Enum.GetValues(typeof(AI.riskLevel)))
            {
                // Trouver le nom de la difficulté
                string riskName = Enum.GetName(typeof(AI.riskLevel), risk); 
                riskName = riskName.Substring(0, 1).ToUpper() + riskName.Substring(1);

                // Ajouter le nom de la difficulté comme choix
                for (int i = 1; i <= 2; i++)
                    ((ComboBox)Controls["PNL_main"].Controls["CB_difficulty" + i.ToString()]).Items.Add(riskName);
            }

            // La valeur par défaut est 'prudent'
            for (int i = 1; i <= 2; i++)
                ((ComboBox)Controls["PNL_main"].Controls["CB_difficulty" + i.ToString()]).SelectedIndex = Enum.GetValues(typeof(AI.riskLevel)).Length - 1;
        }
        private void showLabelCardCounter()
        {
            // Trouve s'il y a au moins un joueur en jeu
            bool oneAI = false; 
            for (int i = 1; i <= 2; i++)
            {
                // Si la valeur sélectionnée du combobox d'un joueur est AI 
                if (((ComboBox)Controls["PNL_main"].Controls["CB_player" + i.ToString()]).SelectedIndex == 1)
                    oneAI = true; // Il y a un AI
            }
            LB_cardCounter.Visible = oneAI; // S'il y en a un, afficher le label de 'Compter les cartes'
        }

        private bool playersAreSelected()
        {
            // Vérifie si deux joueurs(types) ont été sélectionnés.
            for (int i = 1; i <= 2; i++)
            {
                ComboBox CB = (ComboBox)Controls["PNL_main"].Controls["CB_player" + i.ToString()];

                // Si un des deux types de joueurs n'a pas été sélectionné, afficher un message d'erreur.
                if (CB.SelectedIndex != 0 && CB.SelectedIndex != 1)
                {
                    MessageBox.Show("Veuillez sélectionner un joueur #" + i.ToString() + ".");
                    return false; // Les deux joueurs n'ont pas été sélectionnés
                }
            }

            return true; // Les deux joueurs ont été sélectionnés
        }
        private void resetAiSettings(string numPlayer)
        {
            // Cacher le combobox de difficultés d'un AI
            Controls["PNL_main"].Controls["CB_difficulty" + numPlayer].Hide();

            Control BT_cardCounter = Controls["PNL_main"].Controls["BT_cardCounter" + numPlayer];
            BT_cardCounter.Hide(); // Cacher le bouton 'Compter les cartes'

            // Réinitialiser la difficulté par défaut à 'prudent'
            ((ComboBox)Controls["PNL_main"].Controls["CB_difficulty" + numPlayer]).SelectedIndex = Enum.GetValues(typeof(AI.riskLevel)).Length - 1;

            // Réinitialiser le bouton 'Compter les cartes' à non
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

            // Si le joueur d'après est un AI
            if (players[currentPlayer] is AI)
                hit(); // Hit
        }
        private void BT_hit_Click(object sender, EventArgs e)
        {
            hit(); // Hit
        }
        private void BT_pause_Click(object sender, EventArgs e)
        {
            // Si le bouton pause est visible, le cacher. Vice-versa.
            BT_pause.Visible = !BT_pause.Visible;
            hit(); // Hit
        }

        private void BT_restart_Click(object sender, EventArgs e)
        {
            restart(); // Redémarrer
        }
        private void BT_toMain_Click(object sender, EventArgs e)
        {
            toMain(); // Retourner au menu principal
        }

        private void setButtons()
        {
            // Déterminer si le jeu ne comporte que des AI
            bool allAi = true;
            foreach (Player p in players)
                if (p is User)
                    allAi = false;

            // Si le jeu ne comporte pas que des AI
            if (!allAi)
            {
                BT_hit.Show(); // Afficher le bouton pour 'Hit'
                BT_stand.Show(); // Afficher le bouton pour 'Stand'
                BT_pause.Hide(); // Cacher le bouton pour 'Pause'
            }
            else
            {
                BT_hit.Hide(); // Cacher le bouton pour 'Hit'
                BT_stand.Hide();// Cacher le bouton pour 'Stand'
                BT_pause.Show(); // Afficher le bouton pour 'Pause'
            }
        }

        private void showCards()
        {
            // Créer et afficher les cartes sur le jeu
            for (int i = deck.toList().Count; i > 0; i--)
            {
                Controls["PNL_game"].Controls.Add(createCard(i)); // Ajoute une carte à l'interface
                Controls["PNL_game"].Controls["PB_card" + i.ToString()].BringToFront(); // En-avant de tout
            }
            Update(); // Update l'interface du jeu
        }
        private PictureBox createCard(int cardNum)
        {
            // Crée l'interface d'une nouvelle carte
            PictureBox pb = new PictureBox(); // Nouvelle carte
            pb.Name = "PB_card" + cardNum.ToString(); // Nom
            pb.Size = new Size(121, 173); // Grosseur
            pb.Location = new Point(945 + cardNum, 48); // Position
            pb.BackgroundImage = Properties.Resources.back; // Image
            pb.BackgroundImageLayout = ImageLayout.Zoom; // 'Position de l'image
            pb.BackColor = Color.Transparent; // Couleur de fond
            pb.Visible = true; // Visible
            pb.Tag = "deck"; // La carte est dans le 'deck'

            return pb; // Retourner la nouvelle carte
        }
        
        public bool cardsRotated = false; // Les cartes sont retournées
        public void rotateCards()
        {
            // Pour chaque carte
            for (int i = 52; i > 0; i--)
            {
                PictureBox pb = (PictureBox)Controls["PNL_game"].Controls["PB_card" + i.ToString()];

                // Si les cartes n'ont pas été tournées
                if (!cardsRotated)
                    pb.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone); // Les tourner
                else
                    pb.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone); // Sinon, les replacer
            }
            Update(); // Update l'interface du jeu
            Refresh(); // Rafraichir l'interface du jeu
        }
        
        #endregion

        #region Player Operations

        private void hit()
        {
            BT_hit.Enabled = false; // Désactiver le bouton pour 'hit'
            Player current = players[currentPlayer]; // Joueur courant
            Card newCard = new Card(-1, -1); // Carte pigée
            int oldScore = current.score; // Score du joueur courant avant le tour

            // Si le joueur est un AI
            if (current is AI)
            {
                // Déterminer si l'AI doit jouer (s'il a assez de chance de ne pas 'bust')
                if (((AI)current).play(players[currentPlayer == 0 ? 1 : 0], deck))
                {
                    console.showLog(current); // Afficher dans la console
                    newCard = current.hit(deck); // Tirer une nouvelle carte

                    // Si l'ancien score est plus petit ou égal au score avec la nouvelle carte
                    if (oldScore >= current.score)
                    {
                        ((AI)current).addToLog("Le pointage d'un As à été réduit à 1. Score -10."); // Ajouter dans les log du joueur
                        console.showLog(current); // Afficher dans la console
                    }

                    // Déplacer la carte pigée dans la main du joueur
                    updateHitCard(deck.toList().Count, currentPlayer, current.cards.Count);
                    setHitLog(current, newCard, oldScore); // Update les log du joueur (Ajouter la carte tirée)
                    console.showLog(current); // Afficher dans la console

                    LB_playerScore.Text = "Score: " + current.score.ToString(); // Update le score du joueur
                }
                else
                    console.showLog(current); // Afficher dans la console

                updatePlayerLabels(); // Update le label d'information des joueurs

                Player opponent = players[currentPlayer == 0 ? 1 : 0]; // Adversaire
                // Si l'adversaire est un AI, OU qu'il est un humain ET qu'il est en état 'Standing'
                if (opponent is AI || (opponent is User && opponent.status == Player.statuses.standing))
                {
                    // Déterminer s'il y a un gagnant, s'il en a pas
                    if (getWinner() == 0)
                    {
                        changePlayer(); // Changer de joueur
                        hit(); // Hit
                    }
                    else
                        return; // Sinon, quitter la méthode
                }
            }
            else
            {
                newCard = current.hit(deck); // Tirer une nouvelle carte

                // Déplacer la carte pigée dans la main du joueur
                updateHitCard(deck.toList().Count, currentPlayer, current.cards.Count);
                setHitLog(current, newCard, oldScore); // Update les log du joueur (Ajouter la carte tirée)
                console.showLog(current); // Afficher dans la console
            }
             
            LB_playerScore.Text = "Score: " + current.score.ToString(); // Update le score du joueur
            changePlayer(); // Changer de joueur

            updatePlayerLabels(); // Update le label d'information des joueurs

            // Déterminer s'il y a un gagnant, s'il en a pas
            if (getWinner() == 0)
            {
                // Si le joueur courant est un AI
                if (players[currentPlayer] is AI)
                    hit(); // Hit
            }
            else
                return; // Sinon, quitter la méthode

            BT_hit.Enabled = true; // Activer le bouton pour 'hit'
        }
        private void updateHitCard(int cards, int player, int playerCards)
        {
            // Déplacer la carte pigée dans la main du joueur
            PictureBox card = (PictureBox)Controls["PNL_game"].Controls["PB_card" + (52 - cards).ToString()]; // Carte pigée
            card.Tag = "player" + (player + 1).ToString(); // Tag
            card.BackgroundImage = players[player].cards[playerCards - 1].img; // Image
            card.BringToFront(); // Emmener en-avant de tout

            int maxCards = 6; // Cartes maximales dans une rangée
            int x = (164 * (player == 0 ? 1 : 4) + ((playerCards > maxCards ? playerCards % maxCards : playerCards) + 1) * 30); // Pos en X
            int y = 335 + (int)(playerCards > maxCards ? Decimal.Floor(playerCards / maxCards) * 60 : 0); // Pos en Y
            card.Location = new Point(x, y); // Position de la carte

            // Si les cartes sont tournées
            if (cardsRotated)
                card.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone); // Tourner l'image

            Update(); // Update l'interface du jeu
            Refresh(); // Rafraichir l'interface du jeu
        }
        private void setHitLog(Player player, Card card, int oldScore)
        {
            // Définir le texte à ajouter dans le log lorsqu'un joueur 'hit'
            string[] cardNames = { "As", "Valet", "Dame", "Roi" }; // Nom des cartes spéciales

            string text = "Pige un{0} {1} de {2}, score +{3}. Score = {4}. {5}."; // Texte à formater
            string genre = card.rank == 12 ? "e" : ""; // Genre de la carte (Dame est féminin)
            string rank = card.rank == 1 ? cardNames[card.rank - 1] : card.rank > 10 ? cardNames[card.rank - 10] : card.rank.ToString(); // Rang de la carte
            string suit = Enum.GetName(typeof(Card.suits), card.suit); // Couleur de la carte
            suit = suit.Substring(0, 1).ToUpper() + suit.Substring(1);
            string score = card.rank == 1 ? player.score - oldScore == 1 ? "1" : "11" : card.rank > 10 ? "10" : card.rank.ToString(); // Score de la carte
            string status = Enum.GetName(typeof(Player.statuses), player.status); // Status du joueur courant après avoir 'hit'
            status = status.Substring(0, 1).ToUpper() + status.Substring(1);

            text = string.Format(text, genre, rank, suit, score, player.score.ToString(), status); // Ajouter les informations au texte à formater

            // Ajouter au log dépendemment que le joueur est un AI ou un User
            if (player is AI)
                ((AI)player).addToLog(text); // AI
            else
                ((User)player).addToLog(text); // User
        }
        private void setStartingCards()
        {
            // Déplace les cartes données au départ dans la main des joueurs
            int cardsToGive = players.Count * STARTING_CARDS; // Nombre de cartes totales à donner

            // Pour chaque joueur
            for (int i = players.Count; i > 0; i--)
                // Lui donner le nombre de carte de départ
                for (int j = 1; j <= STARTING_CARDS; j++)
                    updateHitCard((deck.toList().Count - cardsToGive / i + j) + (STARTING_CARDS * 2 - 1), i - 1, j);
        }

        private void changePlayer()
        {
            // Changer le joueur courant
            currentPlayer = currentPlayer == players.Count - 1 ? 0 : currentPlayer + 1;
            Player current = players[currentPlayer]; // Joueur courant

            // Si le joueur courant peut encore jouer
            if (current.status == Player.statuses.playing)
            {
                // Update le label du nom du joueur courant
                if (current is AI)
                    LB_playerName.Text = "AI #" + ((AI)current).id.ToString(); // AI
                else
                    LB_playerName.Text = ((User)current).name; // User

                LB_playerScore.Text = "Score: " + current.score.ToString(); // Update le du score du joueur courant
            }
            else
                currentPlayer = currentPlayer == players.Count - 1 ? 0 : currentPlayer + 1; // Sinon, changer de joueur

            updatePlayerLabels(); // Update le label d'information des joueurs
        }
        private void updatePlayerLabels()
        {
            // Pour chaque joueur
            for (int i = 0; i < players.Count; i++)
            {
                // Trouver son nom
                string name = players[i] is AI ? "AI #" + ((AI)players[i]).id.ToString() : ((User)players[i]).name;
                string status = Enum.GetName(typeof(Player.statuses), players[i].status); // Déterminer son status
                status = status.Substring(0, 1).ToUpper() + status.Substring(1);

                // Update le nom, le status et le score du joueur dans le label d'information au-dessus des cartes
                Controls["PNL_game"].Controls["LB_details" + (i + 1).ToString()].Text = name + " : " + status + "(" + players[i].score + ")";
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
                hit(); // Hit
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
                    Control[] c = Controls["PNL_game"].Controls.Find("PB_card" + i.ToString(), true);

                    if (c.Length > 0)
                        if (c[0].Tag.ToString().StartsWith("player"))
                            c[0].BringToFront();
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

            closeConsole();
            console = new Form_console(this);
            console.Show();

            updatePlayerLabels();
            setButtons();
            playFirstAI(); // Faire jouer le premier joueur si c'est un AI
        }
        public void toMain()
        {
            Program.createNewGame = true;
            this.Close();
        }

        private void closeConsole()
        {
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
        }

        #endregion
    }
}