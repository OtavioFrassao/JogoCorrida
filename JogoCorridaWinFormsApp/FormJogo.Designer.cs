namespace JogoCorridaWinFormsApp
{
    partial class FormJogoCorrida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJogoCorrida));
            picCarro = new PictureBox();
            picObstaculo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picCarro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picObstaculo).BeginInit();
            SuspendLayout();
            // 
            // picCarro
            // 
            picCarro.BackColor = Color.Transparent;
            picCarro.Image = (Image)resources.GetObject("picCarro.Image");
            picCarro.Location = new Point(263, 492);
            picCarro.Name = "picCarro";
            picCarro.Size = new Size(127, 122);
            picCarro.SizeMode = PictureBoxSizeMode.StretchImage;
            picCarro.TabIndex = 0;
            picCarro.TabStop = false;
            // 
            // picObstaculo
            // 
            picObstaculo.BackColor = Color.Transparent;
            picObstaculo.BackgroundImage = (Image)resources.GetObject("picObstaculo.BackgroundImage");
            picObstaculo.BackgroundImageLayout = ImageLayout.Stretch;
            picObstaculo.Location = new Point(51, 84);
            picObstaculo.Name = "picObstaculo";
            picObstaculo.Size = new Size(100, 105);
            picObstaculo.TabIndex = 1;
            picObstaculo.TabStop = false;
            // 
            // FormJogoCorrida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(415, 626);
            Controls.Add(picObstaculo);
            Controls.Add(picCarro);
            Name = "FormJogoCorrida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JogoCorrida - IFSP";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picCarro).EndInit();
            ((System.ComponentModel.ISupportInitialize)picObstaculo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox picCarro;
        private PictureBox picObstaculo;
    }
}
