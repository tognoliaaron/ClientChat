namespace ClientChat
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ipServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portaServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nomeUtente = new System.Windows.Forms.TextBox();
            this.conferma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ip Server";
            // 
            // ipServer
            // 
            this.ipServer.Location = new System.Drawing.Point(12, 30);
            this.ipServer.Name = "ipServer";
            this.ipServer.Size = new System.Drawing.Size(210, 20);
            this.ipServer.TabIndex = 1;
            this.ipServer.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Porta";
            // 
            // portaServer
            // 
            this.portaServer.Location = new System.Drawing.Point(12, 70);
            this.portaServer.Name = "portaServer";
            this.portaServer.Size = new System.Drawing.Size(211, 20);
            this.portaServer.TabIndex = 3;
            this.portaServer.Text = "9000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nome Utente";
            // 
            // nomeUtente
            // 
            this.nomeUtente.Location = new System.Drawing.Point(12, 114);
            this.nomeUtente.Name = "nomeUtente";
            this.nomeUtente.Size = new System.Drawing.Size(211, 20);
            this.nomeUtente.TabIndex = 5;
            // 
            // conferma
            // 
            this.conferma.Location = new System.Drawing.Point(12, 141);
            this.conferma.Name = "conferma";
            this.conferma.Size = new System.Drawing.Size(211, 39);
            this.conferma.TabIndex = 6;
            this.conferma.Text = "CONFERMA";
            this.conferma.UseVisualStyleBackColor = true;
            this.conferma.Click += new System.EventHandler(this.conferma_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 192);
            this.Controls.Add(this.conferma);
            this.Controls.Add(this.nomeUtente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portaServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipServer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Connettiti al server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portaServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nomeUtente;
        private System.Windows.Forms.Button conferma;
    }
}

