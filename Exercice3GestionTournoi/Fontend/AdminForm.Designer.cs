namespace Exercice3GestionTournoi.Fontend
{
    partial class AdminForm
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
            labelNomTournoi = new Label();
            textNomTournoi = new TextBox();
            boutonDemarrer = new Button();
            labelEquipesInscrite = new Label();
            listEquipesInscrites = new ListBox();
            labelEquipesEnCours = new Label();
            listEquipesEnCours = new ListBox();
            labelJoueursInscrit = new Label();
            listJoueursInscrits = new ListBox();
            labelTracesActivités = new Label();
            richTextBox = new RichTextBox();
            labelChrono = new Label();
            numericTime = new NumericUpDown();
            labelErreur = new Label();
            ((System.ComponentModel.ISupportInitialize)numericTime).BeginInit();
            SuspendLayout();
            // 
            // labelNomTournoi
            // 
            labelNomTournoi.AutoSize = true;
            labelNomTournoi.Location = new Point(22, 22);
            labelNomTournoi.Name = "labelNomTournoi";
            labelNomTournoi.Size = new Size(117, 20);
            labelNomTournoi.TabIndex = 0;
            labelNomTournoi.Text = "Nom du Tournoi";
            // 
            // textNomTournoi
            // 
            textNomTournoi.Location = new Point(154, 19);
            textNomTournoi.Name = "textNomTournoi";
            textNomTournoi.Size = new Size(353, 27);
            textNomTournoi.TabIndex = 1;
            // 
            // boutonDemarrer
            // 
            boutonDemarrer.BackColor = Color.LimeGreen;
            boutonDemarrer.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            boutonDemarrer.Location = new Point(513, 12);
            boutonDemarrer.Name = "boutonDemarrer";
            boutonDemarrer.Size = new Size(297, 41);
            boutonDemarrer.TabIndex = 2;
            boutonDemarrer.Text = "Démarrer la phase d'inscription";
            boutonDemarrer.UseVisualStyleBackColor = false;
            boutonDemarrer.MouseClick += boutonDemarrer_MouseClick;
            // 
            // labelEquipesInscrite
            // 
            labelEquipesInscrite.AutoSize = true;
            labelEquipesInscrite.Location = new Point(22, 83);
            labelEquipesInscrite.Name = "labelEquipesInscrite";
            labelEquipesInscrite.Size = new Size(143, 20);
            labelEquipesInscrite.TabIndex = 3;
            labelEquipesInscrite.Text = "Les équipes inscrites";
            // 
            // listEquipesInscrites
            // 
            listEquipesInscrites.FormattingEnabled = true;
            listEquipesInscrites.Location = new Point(22, 106);
            listEquipesInscrites.Name = "listEquipesInscrites";
            listEquipesInscrites.Size = new Size(295, 184);
            listEquipesInscrites.TabIndex = 4;
            // 
            // labelEquipesEnCours
            // 
            labelEquipesEnCours.AutoSize = true;
            labelEquipesEnCours.Location = new Point(22, 303);
            labelEquipesEnCours.Name = "labelEquipesEnCours";
            labelEquipesEnCours.Size = new Size(236, 20);
            labelEquipesEnCours.TabIndex = 5;
            labelEquipesEnCours.Text = "Les équipes en cours d'inscriptions";
            // 
            // listEquipesEnCours
            // 
            listEquipesEnCours.FormattingEnabled = true;
            listEquipesEnCours.Location = new Point(22, 326);
            listEquipesEnCours.Name = "listEquipesEnCours";
            listEquipesEnCours.Size = new Size(295, 184);
            listEquipesEnCours.TabIndex = 6;
            // 
            // labelJoueursInscrit
            // 
            labelJoueursInscrit.AutoSize = true;
            labelJoueursInscrit.Location = new Point(340, 83);
            labelJoueursInscrit.Name = "labelJoueursInscrit";
            labelJoueursInscrit.Size = new Size(131, 20);
            labelJoueursInscrit.TabIndex = 7;
            labelJoueursInscrit.Text = "Les joueurs inscrits";
            // 
            // listJoueursInscrits
            // 
            listJoueursInscrits.FormattingEnabled = true;
            listJoueursInscrits.Location = new Point(340, 106);
            listJoueursInscrits.Name = "listJoueursInscrits";
            listJoueursInscrits.Size = new Size(239, 404);
            listJoueursInscrits.TabIndex = 8;
            // 
            // labelTracesActivités
            // 
            labelTracesActivités.AutoSize = true;
            labelTracesActivités.Location = new Point(598, 83);
            labelTracesActivités.Name = "labelTracesActivités";
            labelTracesActivités.Size = new Size(120, 20);
            labelTracesActivités.TabIndex = 9;
            labelTracesActivités.Text = "Traces d'activités";
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(593, 106);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(432, 404);
            richTextBox.TabIndex = 10;
            richTextBox.Text = "";
            // 
            // labelChrono
            // 
            labelChrono.AutoSize = true;
            labelChrono.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelChrono.Location = new Point(825, 12);
            labelChrono.Name = "labelChrono";
            labelChrono.Size = new Size(99, 38);
            labelChrono.TabIndex = 11;
            labelChrono.Text = "05 : 00";
            labelChrono.Click += labelChrono_Click;
            // 
            // numericTime
            // 
            numericTime.Location = new Point(947, 19);
            numericTime.Name = "numericTime";
            numericTime.Size = new Size(50, 27);
            numericTime.TabIndex = 12;
            numericTime.ValueChanged += numericTime_ValueChanged;
            // 
            // labelErreur
            // 
            labelErreur.AutoSize = true;
            labelErreur.Location = new Point(810, 56);
            labelErreur.Name = "labelErreur";
            labelErreur.Size = new Size(0, 20);
            labelErreur.TabIndex = 13;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 536);
            Controls.Add(labelErreur);
            Controls.Add(numericTime);
            Controls.Add(labelChrono);
            Controls.Add(richTextBox);
            Controls.Add(labelTracesActivités);
            Controls.Add(listJoueursInscrits);
            Controls.Add(labelJoueursInscrit);
            Controls.Add(listEquipesEnCours);
            Controls.Add(labelEquipesEnCours);
            Controls.Add(listEquipesInscrites);
            Controls.Add(labelEquipesInscrite);
            Controls.Add(boutonDemarrer);
            Controls.Add(textNomTournoi);
            Controls.Add(labelNomTournoi);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNomTournoi;
        private TextBox textNomTournoi;
        private Button boutonDemarrer;
        private Label labelEquipesInscrite;
        private ListBox listEquipesInscrites;
        private Label labelEquipesEnCours;
        private ListBox listEquipesEnCours;
        private Label labelJoueursInscrit;
        private ListBox listJoueursInscrits;
        private Label labelTracesActivités;
        private RichTextBox richTextBox;
        private Label labelChrono;
        private NumericUpDown numericTime;
        private Label labelErreur;
    }
}