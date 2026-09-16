namespace JogoCorridaWinFormsApp
{
    partial class FormNivelJogo
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
            btnFacil = new Button();
            btnMedio = new Button();
            btnDificil = new Button();
            SuspendLayout();
            // 
            // btnFacil
            // 
            btnFacil.BackColor = Color.Lime;
            btnFacil.Font = new Font("Segoe UI", 40F);
            btnFacil.ForeColor = SystemColors.ActiveCaptionText;
            btnFacil.Location = new Point(12, 196);
            btnFacil.Name = "btnFacil";
            btnFacil.Size = new Size(250, 106);
            btnFacil.TabIndex = 0;
            btnFacil.Text = "FACIL";
            btnFacil.UseVisualStyleBackColor = false;
            // 
            // btnMedio
            // 
            btnMedio.BackColor = Color.Yellow;
            btnMedio.Font = new Font("Segoe UI", 40F);
            btnMedio.ForeColor = SystemColors.ActiveCaptionText;
            btnMedio.Location = new Point(309, 196);
            btnMedio.Name = "btnMedio";
            btnMedio.Size = new Size(270, 106);
            btnMedio.TabIndex = 1;
            btnMedio.Text = "MEDIO";
            btnMedio.UseVisualStyleBackColor = false;
            // 
            // btnDificil
            // 
            btnDificil.BackColor = Color.Red;
            btnDificil.Font = new Font("Segoe UI", 40F);
            btnDificil.ForeColor = SystemColors.ActiveCaptionText;
            btnDificil.Location = new Point(626, 196);
            btnDificil.Name = "btnDificil";
            btnDificil.Size = new Size(263, 106);
            btnDificil.TabIndex = 2;
            btnDificil.Text = "DIFICIL";
            btnDificil.UseVisualStyleBackColor = false;
            // 
            // FormNivelJogo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 450);
            Controls.Add(btnDificil);
            Controls.Add(btnMedio);
            Controls.Add(btnFacil);
            Name = "FormNivelJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormNivelJogo";
            ResumeLayout(false);
        }

        #endregion
        private Label lblMedi;
        private Button btnFacil;
        private Button btnMedio;
        private Button btnDificil;
    }
}