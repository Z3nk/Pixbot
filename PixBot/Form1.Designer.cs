namespace PixBot
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pixelCoord = new System.Windows.Forms.TextBox();
            this.DisplayPixel = new System.Windows.Forms.Button();
            this.pixLab = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.imageLoad = new System.Windows.Forms.Button();
            this.Frequence = new System.Windows.Forms.TrackBar();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.detectHoure = new System.Windows.Forms.MaskedTextBox();
            this.GO = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorTB = new System.Windows.Forms.TextBox();
            this.pixelAnalyseCoord = new System.Windows.Forms.TextBox();
            this.mouseDL = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.chronoLab = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.FrequenceLab = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frequence)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pixelCoord
            // 
            this.pixelCoord.Location = new System.Drawing.Point(22, 51);
            this.pixelCoord.Name = "pixelCoord";
            this.pixelCoord.Size = new System.Drawing.Size(338, 20);
            this.pixelCoord.TabIndex = 0;
            this.pixelCoord.Text = "Ne pas oublier le ; entre la position X et Y du pixel !!";
            this.pixelCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DisplayPixel
            // 
            this.DisplayPixel.Location = new System.Drawing.Point(119, 149);
            this.DisplayPixel.Name = "DisplayPixel";
            this.DisplayPixel.Size = new System.Drawing.Size(135, 44);
            this.DisplayPixel.TabIndex = 1;
            this.DisplayPixel.Text = "Afficher pixel";
            this.DisplayPixel.UseVisualStyleBackColor = true;
            this.DisplayPixel.Click += new System.EventHandler(this.button1_Click);
            // 
            // pixLab
            // 
            this.pixLab.BackColor = System.Drawing.Color.Crimson;
            this.pixLab.Location = new System.Drawing.Point(381, 15);
            this.pixLab.Name = "pixLab";
            this.pixLab.Size = new System.Drawing.Size(457, 64);
            this.pixLab.TabIndex = 2;
            this.pixLab.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.imageDetection);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(132, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 86);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.Frequence);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.GO);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.mouseDL);
            this.panel2.Controls.Add(this.pixLab);
            this.panel2.Location = new System.Drawing.Point(1, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 554);
            this.panel2.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(648, 501);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(300, 46);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Cocher pour cacher le bot une fois lancé (F12 pour arrêter l\'analyse en cours)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel5.Location = new System.Drawing.Point(1009, 440);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(208, 112);
            this.panel5.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.imageLoad);
            this.panel4.Location = new System.Drawing.Point(422, 99);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(373, 213);
            this.panel4.TabIndex = 10;
            // 
            // imageLoad
            // 
            this.imageLoad.Location = new System.Drawing.Point(132, 141);
            this.imageLoad.Name = "imageLoad";
            this.imageLoad.Size = new System.Drawing.Size(105, 24);
            this.imageLoad.TabIndex = 4;
            this.imageLoad.Text = "imageLoad";
            this.imageLoad.UseVisualStyleBackColor = true;
            this.imageLoad.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Frequence
            // 
            this.Frequence.Location = new System.Drawing.Point(320, 368);
            this.Frequence.Name = "Frequence";
            this.Frequence.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Frequence.Size = new System.Drawing.Size(628, 45);
            this.Frequence.TabIndex = 13;
            this.Frequence.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(499, 318);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(161, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Action par apparition d\'image";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.detectHoure);
            this.panel3.Location = new System.Drawing.Point(844, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 213);
            this.panel3.TabIndex = 9;
            // 
            // detectHoure
            // 
            this.detectHoure.Location = new System.Drawing.Point(164, 95);
            this.detectHoure.Mask = "00:00";
            this.detectHoure.Name = "detectHoure";
            this.detectHoure.Size = new System.Drawing.Size(62, 20);
            this.detectHoure.TabIndex = 0;
            this.detectHoure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.detectHoure.ValidatingType = typeof(System.DateTime);
            // 
            // GO
            // 
            this.GO.Image = ((System.Drawing.Image)(resources.GetObject("GO.Image")));
            this.GO.Location = new System.Drawing.Point(648, 414);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(300, 86);
            this.GO.TabIndex = 12;
            this.GO.Text = "Lancer";
            this.GO.UseVisualStyleBackColor = true;
            this.GO.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(983, 318);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(50, 17);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Autre";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(58, 318);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(174, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Action par changement de pixel";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ColorTB);
            this.panel1.Controls.Add(this.pixelAnalyseCoord);
            this.panel1.Location = new System.Drawing.Point(3, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 213);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(50, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 64);
            this.label1.TabIndex = 3;
            this.label1.Text = "Entrez la position en pixel et la couleur du pixel voulu grâce à l\'outil d\'analys" +
    "e de pixel fournis en haut :)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ColorTB
            // 
            this.ColorTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ColorTB.Location = new System.Drawing.Point(15, 159);
            this.ColorTB.Name = "ColorTB";
            this.ColorTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ColorTB.Size = new System.Drawing.Size(351, 26);
            this.ColorTB.TabIndex = 2;
            this.ColorTB.Text = "Rouge/Vert/Bleu/Alpha";
            this.ColorTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pixelAnalyseCoord
            // 
            this.pixelAnalyseCoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pixelAnalyseCoord.Location = new System.Drawing.Point(15, 109);
            this.pixelAnalyseCoord.Name = "pixelAnalyseCoord";
            this.pixelAnalyseCoord.Size = new System.Drawing.Size(351, 26);
            this.pixelAnalyseCoord.TabIndex = 1;
            this.pixelAnalyseCoord.Text = "Ne pas oublier le ; entre la position X et Y du pixel !!";
            this.pixelAnalyseCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mouseDL
            // 
            this.mouseDL.Location = new System.Drawing.Point(320, 414);
            this.mouseDL.Name = "mouseDL";
            this.mouseDL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mouseDL.Size = new System.Drawing.Size(300, 86);
            this.mouseDL.TabIndex = 5;
            this.mouseDL.Text = "Cliquez pour enregistrez une action (Appuyez sur F11 pour arreter)";
            this.mouseDL.UseVisualStyleBackColor = true;
            this.mouseDL.Click += new System.EventHandler(this.mouseDL_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // chronoLab
            // 
            this.chronoLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chronoLab.Location = new System.Drawing.Point(379, 94);
            this.chronoLab.Name = "chronoLab";
            this.chronoLab.Size = new System.Drawing.Size(629, 77);
            this.chronoLab.TabIndex = 8;
            this.chronoLab.Text = "Position Sourie";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // FrequenceLab
            // 
            this.FrequenceLab.AutoSize = true;
            this.FrequenceLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrequenceLab.Location = new System.Drawing.Point(380, 51);
            this.FrequenceLab.Name = "FrequenceLab";
            this.FrequenceLab.Size = new System.Drawing.Size(163, 33);
            this.FrequenceLab.TabIndex = 9;
            this.FrequenceLab.Text = "Frequence";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(19, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 64);
            this.label2.TabIndex = 10;
            this.label2.Text = "Position du pixel à rentrez pour connaitre ses composantes de couleur";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(49, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Entrez l\'heure pour lequelle, l\'action doit effectuer l\'action";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1220, 767);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FrequenceLab);
            this.Controls.Add(this.chronoLab);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DisplayPixel);
            this.Controls.Add(this.pixelCoord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PixBot";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Frequence)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pixelCoord;
        private System.Windows.Forms.Button DisplayPixel;
        private System.Windows.Forms.Label pixLab;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label chronoLab;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button imageLoad;
        private System.Windows.Forms.Button mouseDL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.TrackBar Frequence;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.TextBox pixelAnalyseCoord;
        private System.Windows.Forms.Label FrequenceLab;
        private System.Windows.Forms.TextBox ColorTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MaskedTextBox detectHoure;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
    }
}

