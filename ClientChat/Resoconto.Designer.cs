namespace ClientChat
{
    partial class Resoconto
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
            this.chiudi = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // chiudi
            // 
            this.chiudi.Location = new System.Drawing.Point(12, 295);
            this.chiudi.Name = "chiudi";
            this.chiudi.Size = new System.Drawing.Size(336, 23);
            this.chiudi.TabIndex = 0;
            this.chiudi.Text = "Chiudi";
            this.chiudi.UseVisualStyleBackColor = true;
            this.chiudi.Click += new System.EventHandler(this.chiudi_Click);
            // 
            // chat
            // 
            this.chat.Location = new System.Drawing.Point(12, 12);
            this.chat.Name = "chat";
            this.chat.ReadOnly = true;
            this.chat.Size = new System.Drawing.Size(336, 277);
            this.chat.TabIndex = 1;
            this.chat.Text = "";
            // 
            // Resoconto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 328);
            this.ControlBox = false;
            this.Controls.Add(this.chat);
            this.Controls.Add(this.chiudi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Resoconto";
            this.Text = "Resoconto";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chiudi;
        private System.Windows.Forms.RichTextBox chat;
    }
}