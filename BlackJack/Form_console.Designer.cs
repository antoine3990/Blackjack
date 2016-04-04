namespace BlackJack
{
    partial class Form_console
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
            this.TB_console = new System.Windows.Forms.TextBox();
            this.TB_command = new System.Windows.Forms.TextBox();
            this.BT_execute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_console
            // 
            this.TB_console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_console.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_console.Location = new System.Drawing.Point(12, 12);
            this.TB_console.Multiline = true;
            this.TB_console.Name = "TB_console";
            this.TB_console.ReadOnly = true;
            this.TB_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_console.Size = new System.Drawing.Size(410, 339);
            this.TB_console.TabIndex = 0;
            this.TB_console.TabStop = false;
            // 
            // TB_command
            // 
            this.TB_command.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_command.Location = new System.Drawing.Point(13, 358);
            this.TB_command.Name = "TB_command";
            this.TB_command.Size = new System.Drawing.Size(301, 21);
            this.TB_command.TabIndex = 0;
            this.TB_command.TextChanged += new System.EventHandler(this.TB_command_TextChanged);
            // 
            // BT_execute
            // 
            this.BT_execute.Location = new System.Drawing.Point(320, 357);
            this.BT_execute.Name = "BT_execute";
            this.BT_execute.Size = new System.Drawing.Size(102, 23);
            this.BT_execute.TabIndex = 1;
            this.BT_execute.Text = "Exécuter";
            this.BT_execute.UseVisualStyleBackColor = true;
            this.BT_execute.Click += new System.EventHandler(this.BT_execute_Click);
            // 
            // Form_console
            // 
            this.AcceptButton = this.BT_execute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 389);
            this.Controls.Add(this.BT_execute);
            this.Controls.Add(this.TB_command);
            this.Controls.Add(this.TB_console);
            this.MaximumSize = new System.Drawing.Size(450, 428);
            this.MinimumSize = new System.Drawing.Size(450, 428);
            this.Name = "Form_console";
            this.ShowIcon = false;
            this.Text = "Console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_console;
        private System.Windows.Forms.TextBox TB_command;
        private System.Windows.Forms.Button BT_execute;
    }
}