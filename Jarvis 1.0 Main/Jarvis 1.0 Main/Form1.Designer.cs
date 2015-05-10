namespace Jarvis_1._0_Main
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.recoTextLabel = new System.Windows.Forms.Label();
            this.afficheLabel = new System.Windows.Forms.Label();
            this.recoText = new System.Windows.Forms.Label();
            this.affiche = new System.Windows.Forms.Label();
            this.helpLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recoTextLabel
            // 
            this.recoTextLabel.AutoSize = true;
            this.recoTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.recoTextLabel.Font = new System.Drawing.Font("Space Ranger", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoTextLabel.ForeColor = System.Drawing.Color.White;
            this.recoTextLabel.Location = new System.Drawing.Point(215, 274);
            this.recoTextLabel.Name = "recoTextLabel";
            this.recoTextLabel.Size = new System.Drawing.Size(110, 12);
            this.recoTextLabel.TabIndex = 3;
            this.recoTextLabel.Text = "Texte reconnu : ";
            // 
            // afficheLabel
            // 
            this.afficheLabel.AutoSize = true;
            this.afficheLabel.BackColor = System.Drawing.Color.Transparent;
            this.afficheLabel.Font = new System.Drawing.Font("Space Ranger", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afficheLabel.ForeColor = System.Drawing.Color.White;
            this.afficheLabel.Location = new System.Drawing.Point(215, 313);
            this.afficheLabel.Name = "afficheLabel";
            this.afficheLabel.Size = new System.Drawing.Size(129, 12);
            this.afficheLabel.TabIndex = 5;
            this.afficheLabel.Text = "Réponse de Jarvis :";
            // 
            // recoText
            // 
            this.recoText.AutoSize = true;
            this.recoText.BackColor = System.Drawing.Color.Transparent;
            this.recoText.Font = new System.Drawing.Font("Space Ranger", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoText.ForeColor = System.Drawing.Color.White;
            this.recoText.Location = new System.Drawing.Point(415, 274);
            this.recoText.Name = "recoText";
            this.recoText.Size = new System.Drawing.Size(31, 12);
            this.recoText.TabIndex = 7;
            this.recoText.Text = "vide";
            // 
            // affiche
            // 
            this.affiche.AutoSize = true;
            this.affiche.BackColor = System.Drawing.Color.Transparent;
            this.affiche.Font = new System.Drawing.Font("Space Ranger", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affiche.ForeColor = System.Drawing.Color.White;
            this.affiche.Location = new System.Drawing.Point(415, 311);
            this.affiche.Name = "affiche";
            this.affiche.Size = new System.Drawing.Size(31, 12);
            this.affiche.TabIndex = 8;
            this.affiche.Text = "vide";
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.BackColor = System.Drawing.Color.Transparent;
            this.helpLabel.Font = new System.Drawing.Font("Space Ranger", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.helpLabel.Location = new System.Drawing.Point(215, 240);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.helpLabel.Size = new System.Drawing.Size(473, 15);
            this.helpLabel.TabIndex = 14;
            this.helpLabel.Text = "Pressez la touche espace pour commencer l\'interaction";
            this.helpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(884, 525);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.affiche);
            this.Controls.Add(this.recoText);
            this.Controls.Add(this.afficheLabel);
            this.Controls.Add(this.recoTextLabel);
            this.Location = new System.Drawing.Point(15, 30);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "                                                          ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label recoTextLabel;
        public System.Windows.Forms.Label afficheLabel;
        public System.Windows.Forms.Label recoText;
        public System.Windows.Forms.Label affiche;
        public System.Windows.Forms.Label helpLabel;
    }
}