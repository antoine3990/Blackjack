using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form_console: Form
    {
        Form_main game;
        public Form_console(Form_main game)
        {
            InitializeComponent();
            this.game = game;
            showLogs();
        }

        private void showLogs()
        {
            appendText("Début de la partie.");

            for (int i = 0; i < game.players[0].log.Count; i++)
            {
                foreach (Player player in game.players)
                    if (i < player.log.Count)
                        appendText(player.log[i]);
            }
        }

        private void BT_execute_Click(object sender, EventArgs e)
        {
            if (TB_command.Text.Length > 0)
            {
                appendText(null);
                appendText("> " + TB_command.Text.ToUpper());
                executeCommand(TB_command.Text);
            }
            TB_command.Clear();
        }

        private void executeCommand(string command)
        {
            command = command.ToLower();

            if (command[0] == '/')
                command = command.Substring(1);

            switch (command)
            {
                case "help":
                    showHelp();
                    break;
                case "info":
                    showInfo();
                    break;
                case "restart":
                    game.restart();
                    TB_console.Clear();
                    appendText("Le jeu à été réinitialisé.");
                    break;
                case "mainmenu":
                    game.toMain();
                    this.Close();
                    break;
                case "clear":
                    TB_console.Clear();
                    break;
                case "quit":
                    Application.Exit();
                    break;
                case "pause":
                    game.pause();
                    appendText("PAUSE");
                    break;
                case "undo":
                    undoAction();
                    break;
                case "cl_righthand":
                    game.resizeCards();
                    break;
                default:
                    appendText("'" + command + "' n'est pas une commande. Tappez HELP pour afficher la liste de commandes.");
                    break;
            }
        }

        private void appendText(string line)
        {
            if (line != null && line.Length > 0)
                TB_console.AppendText(line);
            TB_console.AppendText(Environment.NewLine);
        }

        private void showHelp()
        {
            appendText("HELP" + "                         " + "Affiche la fenêtre d'aide ci-contre");
            appendText("INFO" + "                          " + "Affiche les informations des joueurs");
            appendText("UNDO" + "                       " + "Annule le tour du dernier joueur");
            appendText("RESTART" + "                 " + "Réinitialise la partie");
            appendText("MAINMENU" + "             " + "Réinitialise la partie et retourne au menu principal");
            appendText("CL_RIGHTHAND" + "    " + "???");
            appendText("CLEAR" + "                      " + "Efface le contenu de la console");
            appendText("PAUSE" + "                      " + "Pause la partie en cours");
            appendText("QUIT" + "                          " + "Ferme l'application");
        }

        private void undoAction()
        {

        }

        private void showInfo()
        {
            for (int i = 0; i < game.players.Count; i++)
            {
                string status = Enum.GetName(typeof(Player.statuses), game.players[i].status);

                if (game.players[i] is AI)
                {
                    string personnality = Enum.GetName(typeof(AI.riskLevel), ((AI)game.players[i]).Behavior);

                    appendText("Joueur #" + (i + 1).ToString() + ": Intelligence artificielle");
                    appendText("    Personnalité: " + personnality.Substring(0, 1).ToUpper() + personnality.Substring(1));
                    appendText("    Compte les cartes: " + (((AI)game.players[i]).countingCard ? "Oui" : "Non"));
                }
                else
                {
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
            appendText(player.getLastLog());
        }

        public void showLog(string text)
        {
            appendText(text);
        }

        private void TB_command_TextChanged(object sender, EventArgs e)
        {
            if (TB_command.TextLength > 0 && TB_command.Text[0] == '/')
            {
                string command = getCommandTyped(TB_command.Text.Substring(1));
                if (command != null)
                {
                    TB_command.Text = '/' + command;
                    TB_command.SelectionStart = 2;
                    TB_command.SelectionLength = TB_command.TextLength - 2;
                    Update();
                }
            }
        }

        private string getCommandTyped(string text)
        {
            string command = null;

            if (text.Length > 0)
            {
                List<string> commandList = new List<string>() { "help", "info", "restart", "mainmenu", "cl_righthand", "clear", "pause", "quit" };
                commandList.Sort();

                for (int i = 0; i < commandList.Count(); i++)
                {
                    if (commandList[i].StartsWith(text))
                    {
                        command = commandList[i];
                        break;
                    }
                }
            }
            
            return command;
        }
    }
}
