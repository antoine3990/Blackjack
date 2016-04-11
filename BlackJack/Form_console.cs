using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form_console: Form
    {
        Form_main game;
        int prevTextLength = 0;
        public Form_console(Form_main game)
        {
            InitializeComponent(); // Initialiser les contrôles
            this.game = game; // Pointeur vers la fenêtre de jeu
            showLogs(); // Afficher les log des joueurs
        }

        private void showLogs()
        {
            // Ajouter des lignes dans la textbox de logs
            appendText("Tappez /help pour afficher les commandes disponibles.");
            appendText("Début de la partie.");

            // Pour chaque log
            for (int i = 0; i < game.players[0].log.Count; i++)
            {
                // De chaque joueur
                foreach (Player player in game.players)
                    if (i < player.log.Count)
                        appendText(player.log[i]); // Afficher le log à la textbox
            }
        }

        private void BT_execute_Click(object sender, EventArgs e)
        {
            // S'il y a une commande d'entrée
            if (TB_command.Text.Length > 0)
            {
                appendText(null); // Ajouter une ligne vide
                appendText("> " + TB_command.Text.ToUpper()); // Afficher la commande
                executeCommand(TB_command.Text); // Exécuter la commande
            }
            TB_command.Clear(); // Effacer la textbox de commandes
        }

        private void executeCommand(string command)
        {
            command = command.ToLower(); // la commande est en minuscule

            // Si la commande commence par un '/'
            if (command[0] == '/')
                command = command.Substring(1); // Enlever le '/'

            // Trouver la commande à exécuter
            switch (command)
            {
                case "help":
                    showHelp(); // Afficher l'aide
                    break;
                case "info":
                    showInfo(); // Afficher les informations
                    break;
                case "restart":
                    game.restart(); // Recommencer la partie
                    TB_console.Clear(); // Effacer les logs
                    appendText("Le jeu à été réinitialisé.");
                    break;
                case "mainmenu":
                    game.toMain(); // Aller au menu principal
                    this.Close(); // Fermer la console
                    break;
                case "clear":
                    TB_console.Clear(); // Effacer les logs
                    break;
                case "quit":
                    Application.Exit(); // Fermer l'application
                    break;
                case "cl_righthand":
                    game.cardsRotated = game.cardsRotated ? false : true;
                    game.rotateCards();
                    break;
                default:
                    // La commande n'est pas reconnue
                    appendText("'" + command + "' n'est pas une commande. Tappez HELP pour afficher la liste de commandes.");
                    break;
            }
        }

        private void appendText(string line)
        {
            // Ajoute une ligne à la textbox de logs
            if (line != null && line.Length > 0)
                TB_console.AppendText(line);
            TB_console.AppendText(Environment.NewLine);
        }

        private void showHelp()
        {
            // Affiche l'aide
            appendText("HELP" + "                         " + "Affiche la fenêtre d'aide ci-contre");
            appendText("INFO" + "                          " + "Affiche les informations des joueurs");
            appendText("RESTART" + "                 " + "Réinitialise la partie");
            appendText("MAINMENU" + "             " + "Réinitialise la partie et retourne au menu principal");
            appendText("CL_RIGHTHAND" + "    " + "???");
            appendText("CLEAR" + "                      " + "Efface le contenu de la console");
            appendText("QUIT" + "                          " + "Ferme l'application");
        }

        private void showInfo()
        {
            // Pour chaque joueur
            for (int i = 0; i < game.players.Count; i++)
            {
                // Trouver le status du joueur
                string status = Enum.GetName(typeof(Player.statuses), game.players[i].status);

                // Si le joueur est un AI
                if (game.players[i] is AI)
                {
                    // Trouver sa personnalité (difficulté)
                    string personnality = Enum.GetName(typeof(AI.riskLevel), ((AI)game.players[i]).Behavior);

                    // Ajouter son information à la console
                    appendText("Joueur #" + (i + 1).ToString() + ": Intelligence artificielle");
                    appendText("    Personnalité: " + personnality.Substring(0, 1).ToUpper() + personnality.Substring(1));
                    appendText("    Compte les cartes: " + (((AI)game.players[i]).countingCard ? "Oui" : "Non"));
                }
                else
                {
                    // S'il est un humain, ajouter son information à la console directement
                    appendText("Joueur #" + (i + 1).ToString() + ": Utilisateur");
                    appendText("    Nom: " + ((User)game.players[i]).name);
                }

                appendText("    État: " + status.Substring(0, 1).ToUpper() + status.Substring(1));
                appendText("    Score: " + game.players[i].score.ToString());

                if (i != game.players.Count - 1)
                    appendText(null);
            }
        }

        public void showLog(Player player)
        {
            // Affiche le dernier log du joueur passé en paramètre
            if (TB_console.Text.IndexOf("FIN DE LA PARTIE.") == -1)
                appendText(player.getLastLog());
        }

        public void showLog(string text)
        {
            // Affiche la ligne passée en paramètre à la console
            if (TB_console.Text.IndexOf("FIN DE LA PARTIE.") == -1)
                appendText(text);
        }

        private void TB_command_TextChanged(object sender, EventArgs e)
        {
            int textLength = TB_command.TextLength; // Longeur de la commande

            // S'il y a une commande d'entrée et qu'elle commence par '/'
            if (textLength > 0 && TB_command.Text[0] == '/' && textLength > prevTextLength)
            {
                // Essayer de trouver une commande correspondante
                string command = getCommandTyped(TB_command.Text.Substring(1).ToLower());

                // Si le début de commande correspond à une commande
                if (command != null)
                {
                    // Compléter la commande
                    TB_command.Text = '/' + command;
                    TB_command.SelectionStart = textLength;
                    TB_command.SelectionLength = TB_command.TextLength - textLength;
                    Update(); // Update l'interface de la console
                }
            }
            prevTextLength = textLength;
        }

        private string getCommandTyped(string text)
        {
            string command = null;

            // S'il y a une commande d'entrée
            if (text.Length > 0)
            {
                // Liste de commandes disponibles
                List<string> commandList = new List<string>() { "help", "info", "restart", "mainmenu", "cl_righthand", "clear", "pause", "quit", "undo" };
                commandList.Sort(); // La trier en ordre alphabétique

                // Essayer de trouver une commande correspondante
                for (int i = 0; i < commandList.Count(); i++)
                {
                    // Si elle correspond
                    if (commandList[i].StartsWith(text))
                    {
                        command = commandList[i]; // La commande est trouvée
                        break; // Quitter la boucle
                    }
                }
            }
            
            return command; // Retourner la commande
        }
    }
}
