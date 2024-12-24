namespace Lotto
{
    partial class Lotto
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lotto));
            linkLabelInstrukcja = new LinkLabel();
            labelWitaj = new Label();
            tabLosy = new TabControl();
            btnDodajLos = new Button();
            btnUsunLos = new Button();
            pictureBox1 = new PictureBox();
            btnLosuj = new Button();
            btnSzostka = new Button();
            btnSymulacja = new Button();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // linkLabelInstrukcja
            // 
            linkLabelInstrukcja.AutoSize = true;
            linkLabelInstrukcja.LinkColor = SystemColors.ControlLightLight;
            linkLabelInstrukcja.Location = new Point(730, 9);
            linkLabelInstrukcja.Name = "linkLabelInstrukcja";
            linkLabelInstrukcja.Size = new Size(58, 15);
            linkLabelInstrukcja.TabIndex = 2;
            linkLabelInstrukcja.TabStop = true;
            linkLabelInstrukcja.Text = "Instrukcja";
            linkLabelInstrukcja.LinkClicked += linkLabelZasady_LinkClicked;
            // 
            // labelWitaj
            // 
            labelWitaj.AutoSize = true;
            labelWitaj.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelWitaj.ForeColor = SystemColors.ControlLightLight;
            labelWitaj.Location = new Point(221, 36);
            labelWitaj.Name = "labelWitaj";
            labelWitaj.Size = new Size(363, 47);
            labelWitaj.TabIndex = 0;
            labelWitaj.Text = "Witaj w grze LOTTO!";
            // 
            // tabLosy
            // 
            tabLosy.Location = new Point(12, 139);
            tabLosy.Name = "tabLosy";
            tabLosy.SelectedIndex = 0;
            tabLosy.Size = new Size(776, 88);
            tabLosy.TabIndex = 5;
            // 
            // btnDodajLos
            // 
            btnDodajLos.Cursor = Cursors.Hand;
            btnDodajLos.Location = new Point(632, 233);
            btnDodajLos.Name = "btnDodajLos";
            btnDodajLos.Size = new Size(75, 23);
            btnDodajLos.TabIndex = 6;
            btnDodajLos.Text = "Dodaj los";
            btnDodajLos.UseVisualStyleBackColor = true;
            btnDodajLos.Click += btnDodajLos_Click;
            // 
            // btnUsunLos
            // 
            btnUsunLos.Cursor = Cursors.Hand;
            btnUsunLos.Location = new Point(713, 233);
            btnUsunLos.Name = "btnUsunLos";
            btnUsunLos.Size = new Size(75, 23);
            btnUsunLos.TabIndex = 7;
            btnUsunLos.Text = "Usuń los";
            btnUsunLos.UseVisualStyleBackColor = true;
            btnUsunLos.Click += btnUsunLos_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(130, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnLosuj
            // 
            btnLosuj.BackColor = Color.FromArgb(0, 192, 0);
            btnLosuj.Cursor = Cursors.Hand;
            btnLosuj.FlatAppearance.BorderSize = 0;
            btnLosuj.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            btnLosuj.FlatAppearance.MouseOverBackColor = Color.Red;
            btnLosuj.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnLosuj.ForeColor = SystemColors.ControlLightLight;
            btnLosuj.Location = new Point(318, 300);
            btnLosuj.Name = "btnLosuj";
            btnLosuj.Size = new Size(179, 47);
            btnLosuj.TabIndex = 9;
            btnLosuj.Text = "LOSUJ";
            btnLosuj.UseVisualStyleBackColor = false;
            btnLosuj.Click += btnLosuj_Click;
            // 
            // btnSzostka
            // 
            btnSzostka.Cursor = Cursors.Hand;
            btnSzostka.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSzostka.Location = new Point(12, 415);
            btnSzostka.Name = "btnSzostka";
            btnSzostka.Size = new Size(149, 23);
            btnSzostka.TabIndex = 13;
            btnSzostka.Text = "Odkryj szczęśliwą szóstkę";
            btnSzostka.UseVisualStyleBackColor = true;
            btnSzostka.Click += btnSzostka_Click;
            // 
            // btnSymulacja
            // 
            btnSymulacja.Cursor = Cursors.Hand;
            btnSymulacja.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSymulacja.Location = new Point(568, 415);
            btnSymulacja.Name = "btnSymulacja";
            btnSymulacja.Size = new Size(220, 23);
            btnSymulacja.TabIndex = 14;
            btnSymulacja.Text = "Przeprowadź symulację wielu losowań";
            btnSymulacja.UseVisualStyleBackColor = true;
            btnSymulacja.Click += btnSymulacja_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(labelWitaj);
            panel1.Controls.Add(linkLabelInstrukcja);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 134);
            panel1.TabIndex = 15;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(590, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(85, 94);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // Lotto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(btnSymulacja);
            Controls.Add(btnSzostka);
            Controls.Add(btnLosuj);
            Controls.Add(btnUsunLos);
            Controls.Add(btnDodajLos);
            Controls.Add(tabLosy);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Lotto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lotto";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private LinkLabel linkLabelInstrukcja;
        private Label labelWitaj;
        private TabControl tabLosy;
        private Button btnDodajLos;
        private Button btnUsunLos;
        private PictureBox pictureBox1;
        private Button btnLosuj;
        private Button btnSzostka;
        private Button btnSymulacja;
        private Panel panel1;
        private PictureBox pictureBox2;
    }
}
