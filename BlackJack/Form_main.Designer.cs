namespace BlackJack
{
    partial class Form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PNL_game = new System.Windows.Forms.Panel();
            this.PNL_victory = new System.Windows.Forms.Panel();
            this.BT_toMain = new System.Windows.Forms.Button();
            this.BT_restart = new System.Windows.Forms.Button();
            this.LB_winner = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LB_details2 = new System.Windows.Forms.Label();
            this.LB_details1 = new System.Windows.Forms.Label();
            this.LB_playerScore = new System.Windows.Forms.Label();
            this.LB_playerName = new System.Windows.Forms.Label();
            this.BT_hit = new System.Windows.Forms.Button();
            this.BT_stand = new System.Windows.Forms.Button();
            this.BT_pause = new System.Windows.Forms.Button();
            this.PNL_main = new System.Windows.Forms.Panel();
            this.BT_cardCounter1 = new System.Windows.Forms.Button();
            this.BT_cardCounter2 = new System.Windows.Forms.Button();
            this.LB_cardCounter = new System.Windows.Forms.Label();
            this.CB_difficulty2 = new System.Windows.Forms.ComboBox();
            this.CB_difficulty1 = new System.Windows.Forms.ComboBox();
            this.TB_name2 = new System.Windows.Forms.TextBox();
            this.TB_name1 = new System.Windows.Forms.TextBox();
            this.CB_player1 = new System.Windows.Forms.ComboBox();
            this.BT_start = new System.Windows.Forms.Button();
            this.CB_player2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PNL_game.SuspendLayout();
            this.PNL_victory.SuspendLayout();
            this.PNL_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // PNL_game
            // 
            this.PNL_game.BackgroundImage = global::BlackJack.Properties.Resources.table;
            this.PNL_game.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PNL_game.Controls.Add(this.PNL_victory);
            this.PNL_game.Controls.Add(this.LB_details2);
            this.PNL_game.Controls.Add(this.LB_details1);
            this.PNL_game.Controls.Add(this.LB_playerScore);
            this.PNL_game.Controls.Add(this.LB_playerName);
            this.PNL_game.Controls.Add(this.BT_hit);
            this.PNL_game.Controls.Add(this.BT_stand);
            this.PNL_game.Controls.Add(this.BT_pause);
            this.PNL_game.Location = new System.Drawing.Point(0, 0);
            this.PNL_game.MaximumSize = new System.Drawing.Size(1280, 776);
            this.PNL_game.MinimumSize = new System.Drawing.Size(1280, 776);
            this.PNL_game.Name = "PNL_game";
            this.PNL_game.Size = new System.Drawing.Size(1280, 776);
            this.PNL_game.TabIndex = 1;
            this.PNL_game.Visible = false;
            // 
            // PNL_victory
            // 
            this.PNL_victory.BackColor = System.Drawing.Color.Transparent;
            this.PNL_victory.Controls.Add(this.BT_toMain);
            this.PNL_victory.Controls.Add(this.BT_restart);
            this.PNL_victory.Controls.Add(this.LB_winner);
            this.PNL_victory.Controls.Add(this.label3);
            this.PNL_victory.Location = new System.Drawing.Point(0, 0);
            this.PNL_victory.Name = "PNL_victory";
            this.PNL_victory.Size = new System.Drawing.Size(1277, 774);
            this.PNL_victory.TabIndex = 2;
            this.PNL_victory.Visible = false;
            // 
            // BT_toMain
            // 
            this.BT_toMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_toMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_toMain.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.BT_toMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_toMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BT_toMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_toMain.Font = new System.Drawing.Font("Calibri Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_toMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.BT_toMain.Location = new System.Drawing.Point(324, 586);
            this.BT_toMain.Name = "BT_toMain";
            this.BT_toMain.Size = new System.Drawing.Size(285, 103);
            this.BT_toMain.TabIndex = 3;
            this.BT_toMain.Text = "Menu principal";
            this.BT_toMain.UseVisualStyleBackColor = false;
            this.BT_toMain.Click += new System.EventHandler(this.BT_toMain_Click);
            // 
            // BT_restart
            // 
            this.BT_restart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_restart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_restart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.BT_restart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_restart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BT_restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_restart.Font = new System.Drawing.Font("Calibri Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_restart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.BT_restart.Location = new System.Drawing.Point(641, 586);
            this.BT_restart.Name = "BT_restart";
            this.BT_restart.Size = new System.Drawing.Size(285, 103);
            this.BT_restart.TabIndex = 2;
            this.BT_restart.Text = "Rejouer";
            this.BT_restart.UseVisualStyleBackColor = false;
            this.BT_restart.Click += new System.EventHandler(this.BT_restart_Click);
            // 
            // LB_winner
            // 
            this.LB_winner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.LB_winner.Font = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_winner.ForeColor = System.Drawing.Color.White;
            this.LB_winner.Location = new System.Drawing.Point(0, 179);
            this.LB_winner.Name = "LB_winner";
            this.LB_winner.Size = new System.Drawing.Size(1277, 50);
            this.LB_winner.TabIndex = 1;
            this.LB_winner.Text = "Le gagnant est {0}, avec un score de {1}.";
            this.LB_winner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label3.Font = new System.Drawing.Font("Calibri Light", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1274, 240);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fin de la partie!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_details2
            // 
            this.LB_details2.BackColor = System.Drawing.Color.Transparent;
            this.LB_details2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_details2.ForeColor = System.Drawing.Color.White;
            this.LB_details2.Location = new System.Drawing.Point(722, 297);
            this.LB_details2.Name = "LB_details2";
            this.LB_details2.Size = new System.Drawing.Size(260, 23);
            this.LB_details2.TabIndex = 6;
            this.LB_details2.Text = "Player_Name : Player_Status";
            this.LB_details2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_details1
            // 
            this.LB_details1.BackColor = System.Drawing.Color.Transparent;
            this.LB_details1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_details1.ForeColor = System.Drawing.Color.White;
            this.LB_details1.Location = new System.Drawing.Point(230, 297);
            this.LB_details1.Name = "LB_details1";
            this.LB_details1.Size = new System.Drawing.Size(260, 23);
            this.LB_details1.TabIndex = 5;
            this.LB_details1.Text = "Player_Name : Player_Status";
            this.LB_details1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_playerScore
            // 
            this.LB_playerScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.LB_playerScore.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_playerScore.ForeColor = System.Drawing.Color.White;
            this.LB_playerScore.Location = new System.Drawing.Point(160, 0);
            this.LB_playerScore.Name = "LB_playerScore";
            this.LB_playerScore.Size = new System.Drawing.Size(98, 33);
            this.LB_playerScore.TabIndex = 3;
            this.LB_playerScore.Text = "Score: ";
            this.LB_playerScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LB_playerName
            // 
            this.LB_playerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.LB_playerName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_playerName.ForeColor = System.Drawing.Color.White;
            this.LB_playerName.Location = new System.Drawing.Point(0, 0);
            this.LB_playerName.Name = "LB_playerName";
            this.LB_playerName.Size = new System.Drawing.Size(158, 33);
            this.LB_playerName.TabIndex = 2;
            this.LB_playerName.Text = "Player_Name";
            this.LB_playerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_hit
            // 
            this.BT_hit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.BT_hit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_hit.FlatAppearance.BorderSize = 0;
            this.BT_hit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(150)))));
            this.BT_hit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.BT_hit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_hit.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.BT_hit.ForeColor = System.Drawing.Color.White;
            this.BT_hit.Location = new System.Drawing.Point(675, 615);
            this.BT_hit.Name = "BT_hit";
            this.BT_hit.Size = new System.Drawing.Size(380, 131);
            this.BT_hit.TabIndex = 1;
            this.BT_hit.Text = "Hit";
            this.BT_hit.UseVisualStyleBackColor = false;
            this.BT_hit.Click += new System.EventHandler(this.BT_hit_Click);
            // 
            // BT_stand
            // 
            this.BT_stand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.BT_stand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_stand.FlatAppearance.BorderSize = 0;
            this.BT_stand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(150)))));
            this.BT_stand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.BT_stand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_stand.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.BT_stand.ForeColor = System.Drawing.Color.White;
            this.BT_stand.Location = new System.Drawing.Point(255, 615);
            this.BT_stand.Name = "BT_stand";
            this.BT_stand.Size = new System.Drawing.Size(380, 131);
            this.BT_stand.TabIndex = 0;
            this.BT_stand.Text = "Stand";
            this.BT_stand.UseVisualStyleBackColor = false;
            this.BT_stand.Click += new System.EventHandler(this.BT_stand_Click);
            // 
            // BT_pause
            // 
            this.BT_pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.BT_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_pause.FlatAppearance.BorderSize = 0;
            this.BT_pause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(150)))));
            this.BT_pause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.BT_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_pause.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.BT_pause.ForeColor = System.Drawing.Color.White;
            this.BT_pause.Location = new System.Drawing.Point(470, 615);
            this.BT_pause.Name = "BT_pause";
            this.BT_pause.Size = new System.Drawing.Size(380, 131);
            this.BT_pause.TabIndex = 4;
            this.BT_pause.Text = "Pause";
            this.BT_pause.UseVisualStyleBackColor = false;
            this.BT_pause.Visible = false;
            this.BT_pause.Click += new System.EventHandler(this.BT_pause_Click);
            // 
            // PNL_main
            // 
            this.PNL_main.BackgroundImage = global::BlackJack.Properties.Resources.table;
            this.PNL_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PNL_main.Controls.Add(this.BT_cardCounter1);
            this.PNL_main.Controls.Add(this.BT_cardCounter2);
            this.PNL_main.Controls.Add(this.LB_cardCounter);
            this.PNL_main.Controls.Add(this.CB_difficulty2);
            this.PNL_main.Controls.Add(this.CB_difficulty1);
            this.PNL_main.Controls.Add(this.TB_name2);
            this.PNL_main.Controls.Add(this.TB_name1);
            this.PNL_main.Controls.Add(this.CB_player1);
            this.PNL_main.Controls.Add(this.BT_start);
            this.PNL_main.Controls.Add(this.CB_player2);
            this.PNL_main.Controls.Add(this.label1);
            this.PNL_main.Controls.Add(this.label2);
            this.PNL_main.Location = new System.Drawing.Point(0, 0);
            this.PNL_main.MaximumSize = new System.Drawing.Size(1280, 776);
            this.PNL_main.MinimumSize = new System.Drawing.Size(1280, 776);
            this.PNL_main.Name = "PNL_main";
            this.PNL_main.Size = new System.Drawing.Size(1280, 776);
            this.PNL_main.TabIndex = 0;
            // 
            // BT_cardCounter1
            // 
            this.BT_cardCounter1.BackColor = System.Drawing.Color.Transparent;
            this.BT_cardCounter1.BackgroundImage = global::BlackJack.Properties.Resources.incorrect_small;
            this.BT_cardCounter1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_cardCounter1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_cardCounter1.FlatAppearance.BorderSize = 0;
            this.BT_cardCounter1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BT_cardCounter1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BT_cardCounter1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_cardCounter1.Location = new System.Drawing.Point(924, 311);
            this.BT_cardCounter1.Name = "BT_cardCounter1";
            this.BT_cardCounter1.Size = new System.Drawing.Size(68, 68);
            this.BT_cardCounter1.TabIndex = 128;
            this.BT_cardCounter1.Tag = "no";
            this.BT_cardCounter1.UseVisualStyleBackColor = false;
            this.BT_cardCounter1.Visible = false;
            this.BT_cardCounter1.Click += new System.EventHandler(this.BT_cardCounter_Click);
            // 
            // BT_cardCounter2
            // 
            this.BT_cardCounter2.BackColor = System.Drawing.Color.Transparent;
            this.BT_cardCounter2.BackgroundImage = global::BlackJack.Properties.Resources.incorrect_small;
            this.BT_cardCounter2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_cardCounter2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_cardCounter2.FlatAppearance.BorderSize = 0;
            this.BT_cardCounter2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BT_cardCounter2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BT_cardCounter2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_cardCounter2.Location = new System.Drawing.Point(924, 384);
            this.BT_cardCounter2.Name = "BT_cardCounter2";
            this.BT_cardCounter2.Size = new System.Drawing.Size(68, 68);
            this.BT_cardCounter2.TabIndex = 127;
            this.BT_cardCounter2.Tag = "no";
            this.BT_cardCounter2.UseVisualStyleBackColor = false;
            this.BT_cardCounter2.Visible = false;
            this.BT_cardCounter2.Click += new System.EventHandler(this.BT_cardCounter_Click);
            // 
            // LB_cardCounter
            // 
            this.LB_cardCounter.BackColor = System.Drawing.Color.Transparent;
            this.LB_cardCounter.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_cardCounter.ForeColor = System.Drawing.Color.White;
            this.LB_cardCounter.Location = new System.Drawing.Point(905, 264);
            this.LB_cardCounter.Name = "LB_cardCounter";
            this.LB_cardCounter.Size = new System.Drawing.Size(103, 44);
            this.LB_cardCounter.TabIndex = 124;
            this.LB_cardCounter.Text = "Compteur de cartes";
            this.LB_cardCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_cardCounter.Visible = false;
            // 
            // CB_difficulty2
            // 
            this.CB_difficulty2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(69)))), ((int)(((byte)(2)))));
            this.CB_difficulty2.Cursor = System.Windows.Forms.Cursors.Default;
            this.CB_difficulty2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_difficulty2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_difficulty2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_difficulty2.ForeColor = System.Drawing.Color.White;
            this.CB_difficulty2.FormattingEnabled = true;
            this.CB_difficulty2.Location = new System.Drawing.Point(684, 384);
            this.CB_difficulty2.Name = "CB_difficulty2";
            this.CB_difficulty2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_difficulty2.Size = new System.Drawing.Size(231, 67);
            this.CB_difficulty2.TabIndex = 123;
            this.CB_difficulty2.Visible = false;
            // 
            // CB_difficulty1
            // 
            this.CB_difficulty1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(69)))), ((int)(((byte)(2)))));
            this.CB_difficulty1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CB_difficulty1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_difficulty1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_difficulty1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_difficulty1.ForeColor = System.Drawing.Color.White;
            this.CB_difficulty1.FormattingEnabled = true;
            this.CB_difficulty1.Location = new System.Drawing.Point(684, 311);
            this.CB_difficulty1.Name = "CB_difficulty1";
            this.CB_difficulty1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_difficulty1.Size = new System.Drawing.Size(231, 67);
            this.CB_difficulty1.TabIndex = 122;
            this.CB_difficulty1.Visible = false;
            // 
            // TB_name2
            // 
            this.TB_name2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TB_name2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_name2.Font = new System.Drawing.Font("Calibri", 38F, System.Drawing.FontStyle.Bold);
            this.TB_name2.ForeColor = System.Drawing.Color.White;
            this.TB_name2.Location = new System.Drawing.Point(684, 383);
            this.TB_name2.Name = "TB_name2";
            this.TB_name2.Size = new System.Drawing.Size(231, 69);
            this.TB_name2.TabIndex = 121;
            this.TB_name2.Visible = false;
            // 
            // TB_name1
            // 
            this.TB_name1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TB_name1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_name1.Font = new System.Drawing.Font("Calibri", 38F, System.Drawing.FontStyle.Bold);
            this.TB_name1.ForeColor = System.Drawing.Color.White;
            this.TB_name1.Location = new System.Drawing.Point(684, 310);
            this.TB_name1.Name = "TB_name1";
            this.TB_name1.Size = new System.Drawing.Size(231, 69);
            this.TB_name1.TabIndex = 120;
            this.TB_name1.Visible = false;
            // 
            // CB_player1
            // 
            this.CB_player1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(69)))), ((int)(((byte)(2)))));
            this.CB_player1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CB_player1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_player1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_player1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_player1.ForeColor = System.Drawing.Color.White;
            this.CB_player1.FormattingEnabled = true;
            this.CB_player1.Items.AddRange(new object[] {
            "Humain",
            "IA"});
            this.CB_player1.Location = new System.Drawing.Point(475, 311);
            this.CB_player1.Name = "CB_player1";
            this.CB_player1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_player1.Size = new System.Drawing.Size(203, 67);
            this.CB_player1.TabIndex = 115;
            this.CB_player1.SelectedIndexChanged += new System.EventHandler(this.CB_player_SelectedIndexChanged);
            // 
            // BT_start
            // 
            this.BT_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.BT_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_start.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BT_start.FlatAppearance.BorderSize = 0;
            this.BT_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(150)))));
            this.BT_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.BT_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_start.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_start.ForeColor = System.Drawing.Color.White;
            this.BT_start.Location = new System.Drawing.Point(0, 623);
            this.BT_start.Name = "BT_start";
            this.BT_start.Size = new System.Drawing.Size(1280, 151);
            this.BT_start.TabIndex = 119;
            this.BT_start.Text = "Jouer";
            this.BT_start.UseVisualStyleBackColor = false;
            this.BT_start.Click += new System.EventHandler(this.BT_start_Click);
            // 
            // CB_player2
            // 
            this.CB_player2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(69)))), ((int)(((byte)(2)))));
            this.CB_player2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_player2.DropDownWidth = 40;
            this.CB_player2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_player2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_player2.ForeColor = System.Drawing.Color.White;
            this.CB_player2.FormattingEnabled = true;
            this.CB_player2.Items.AddRange(new object[] {
            "Humain",
            "IA"});
            this.CB_player2.Location = new System.Drawing.Point(475, 384);
            this.CB_player2.Name = "CB_player2";
            this.CB_player2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_player2.Size = new System.Drawing.Size(203, 67);
            this.CB_player2.TabIndex = 116;
            this.CB_player2.SelectedIndexChanged += new System.EventHandler(this.CB_player_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(313, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 67);
            this.label1.TabIndex = 118;
            this.label1.Text = "Joueur 2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(313, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 67);
            this.label2.TabIndex = 117;
            this.label2.Text = "Joueur 1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.PNL_game);
            this.Controls.Add(this.PNL_main);
            this.MaximumSize = new System.Drawing.Size(1400, 858);
            this.MinimumSize = new System.Drawing.Size(1278, 768);
            this.Name = "Form_main";
            this.Text = "BlackJack";
            this.PNL_game.ResumeLayout(false);
            this.PNL_victory.ResumeLayout(false);
            this.PNL_main.ResumeLayout(false);
            this.PNL_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_main;
        private System.Windows.Forms.ComboBox CB_player1;
        private System.Windows.Forms.Button BT_start;
        private System.Windows.Forms.ComboBox CB_player2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_name2;
        private System.Windows.Forms.TextBox TB_name1;
        private System.Windows.Forms.ComboBox CB_difficulty2;
        private System.Windows.Forms.ComboBox CB_difficulty1;
        private System.Windows.Forms.Button BT_cardCounter1;
        private System.Windows.Forms.Button BT_cardCounter2;
        private System.Windows.Forms.Label LB_cardCounter;
        private System.Windows.Forms.Panel PNL_game;
        private System.Windows.Forms.Button BT_hit;
        private System.Windows.Forms.Button BT_stand;
        private System.Windows.Forms.Label LB_playerName;
        private System.Windows.Forms.Label LB_playerScore;
        private System.Windows.Forms.Button BT_pause;
        private System.Windows.Forms.Label LB_details2;
        private System.Windows.Forms.Label LB_details1;
        private System.Windows.Forms.Panel PNL_victory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LB_winner;
        private System.Windows.Forms.Button BT_restart;
        private System.Windows.Forms.Button BT_toMain;
    }
}

