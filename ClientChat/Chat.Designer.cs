namespace ClientChat
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.inviaMessaggio = new System.Windows.Forms.Button();
            this.inviaMex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aggiornaLista = new System.Windows.Forms.Timer(this.components);
            this.utenti = new System.Windows.Forms.ListBox();
            this.inviaTutti = new System.Windows.Forms.Button();
            this.riceviMex = new System.Windows.Forms.RichTextBox();
            this.resocontoMex = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.online = new System.Windows.Forms.TabPage();
            this.offline = new System.Windows.Forms.TabPage();
            this.utentiOffline = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.online.SuspendLayout();
            this.offline.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista Utenti";
            // 
            // inviaMessaggio
            // 
            this.inviaMessaggio.Location = new System.Drawing.Point(186, 285);
            this.inviaMessaggio.Name = "inviaMessaggio";
            this.inviaMessaggio.Size = new System.Drawing.Size(156, 23);
            this.inviaMessaggio.TabIndex = 2;
            this.inviaMessaggio.Text = "Invia Messaggio";
            this.inviaMessaggio.UseVisualStyleBackColor = true;
            this.inviaMessaggio.Click += new System.EventHandler(this.inviaMessaggio_Click);
            // 
            // inviaMex
            // 
            this.inviaMex.Location = new System.Drawing.Point(183, 30);
            this.inviaMex.Multiline = true;
            this.inviaMex.Name = "inviaMex";
            this.inviaMex.Size = new System.Drawing.Size(333, 251);
            this.inviaMex.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Invia Un Messaggio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chat";
            // 
            // aggiornaLista
            // 
            this.aggiornaLista.Interval = 1000;
            // 
            // utenti
            // 
            this.utenti.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.utenti.FormattingEnabled = true;
            this.utenti.ItemHeight = 32;
            this.utenti.Location = new System.Drawing.Point(1, 3);
            this.utenti.Name = "utenti";
            this.utenti.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.utenti.Size = new System.Drawing.Size(164, 228);
            this.utenti.TabIndex = 7;
            this.utenti.TabStop = false;
            this.utenti.Click += new System.EventHandler(this.utenti_Click);
            this.utenti.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.utenti_DrawItem);
            this.utenti.SelectedIndexChanged += new System.EventHandler(this.utenti_SelectedIndexChanged);
            // 
            // inviaTutti
            // 
            this.inviaTutti.Location = new System.Drawing.Point(348, 285);
            this.inviaTutti.Name = "inviaTutti";
            this.inviaTutti.Size = new System.Drawing.Size(168, 23);
            this.inviaTutti.TabIndex = 8;
            this.inviaTutti.Text = "Invia a tutti";
            this.inviaTutti.UseVisualStyleBackColor = true;
            this.inviaTutti.Click += new System.EventHandler(this.inviaTutti_Click);
            // 
            // riceviMex
            // 
            this.riceviMex.Location = new System.Drawing.Point(522, 30);
            this.riceviMex.Name = "riceviMex";
            this.riceviMex.ReadOnly = true;
            this.riceviMex.Size = new System.Drawing.Size(336, 277);
            this.riceviMex.TabIndex = 9;
            this.riceviMex.Text = "";
            // 
            // resocontoMex
            // 
            this.resocontoMex.Location = new System.Drawing.Point(76, 4);
            this.resocontoMex.Name = "resocontoMex";
            this.resocontoMex.Size = new System.Drawing.Size(101, 23);
            this.resocontoMex.TabIndex = 10;
            this.resocontoMex.Text = "Resoconto";
            this.resocontoMex.UseVisualStyleBackColor = true;
            this.resocontoMex.Click += new System.EventHandler(this.resocontoMex_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.online);
            this.tabControl1.Controls.Add(this.offline);
            this.tabControl1.Location = new System.Drawing.Point(1, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(176, 261);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // online
            // 
            this.online.Controls.Add(this.utenti);
            this.online.Location = new System.Drawing.Point(4, 22);
            this.online.Name = "online";
            this.online.Padding = new System.Windows.Forms.Padding(3);
            this.online.Size = new System.Drawing.Size(168, 235);
            this.online.TabIndex = 0;
            this.online.Text = "Online";
            this.online.UseVisualStyleBackColor = true;
            // 
            // offline
            // 
            this.offline.Controls.Add(this.utentiOffline);
            this.offline.Location = new System.Drawing.Point(4, 22);
            this.offline.Name = "offline";
            this.offline.Padding = new System.Windows.Forms.Padding(3);
            this.offline.Size = new System.Drawing.Size(168, 235);
            this.offline.TabIndex = 1;
            this.offline.Text = "Offline";
            this.offline.UseVisualStyleBackColor = true;
            // 
            // utentiOffline
            // 
            this.utentiOffline.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.utentiOffline.FormattingEnabled = true;
            this.utentiOffline.ItemHeight = 32;
            this.utentiOffline.Location = new System.Drawing.Point(1, 3);
            this.utentiOffline.Name = "utentiOffline";
            this.utentiOffline.Size = new System.Drawing.Size(164, 228);
            this.utentiOffline.TabIndex = 8;
            this.utentiOffline.TabStop = false;
            this.utentiOffline.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.utenti_DrawItem);
            this.utentiOffline.SelectedIndexChanged += new System.EventHandler(this.utenti_SelectedIndexChanged);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 320);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.resocontoMex);
            this.Controls.Add(this.riceviMex);
            this.Controls.Add(this.inviaTutti);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inviaMex);
            this.Controls.Add(this.inviaMessaggio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Chat";
            this.ShowIcon = false;
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chat_FormClosed);
            this.Load += new System.EventHandler(this.Chat_Load);
            this.tabControl1.ResumeLayout(false);
            this.online.ResumeLayout(false);
            this.offline.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button inviaMessaggio;
        private System.Windows.Forms.TextBox inviaMex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer aggiornaLista;
        private System.Windows.Forms.ListBox utenti;
        private System.Windows.Forms.Button inviaTutti;
        private System.Windows.Forms.RichTextBox riceviMex;
        private System.Windows.Forms.Button resocontoMex;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage online;
        private System.Windows.Forms.TabPage offline;
        private System.Windows.Forms.ListBox utentiOffline;
    }
}