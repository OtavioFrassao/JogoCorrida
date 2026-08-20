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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJogoCorrida));
            picCarro = new PictureBox();
            timerJogo = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picCarro).BeginInit();
            SuspendLayout();
            // 
            // picCarro
            // 
            picCarro.BackColor = Color.Transparent;
            picCarro.BackgroundImage = (Image)resources.GetObject("picCarro.BackgroundImage");
            picCarro.BackgroundImageLayout = ImageLayout.Stretch;
            picCarro.Location = new Point(252, 346);
            picCarro.Name = "picCarro";
            picCarro.Size = new Size(95, 103);
            picCarro.TabIndex = 2;
            picCarro.TabStop = false;
            // 
            // timerJogo
            // 
            timerJogo.Tick += timerJogo_Tick;
            // 
            // FormJogoCorrida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(384, 511);
            Controls.Add(picCarro);
            Name = "FormJogoCorrida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JogoCorrida - IFSP";
            Load += FormJogoCorrida_Load;
            KeyDown += FormJogoCorrida_KeyDown;
            ((System.ComponentModel.ISupportInitialize)picCarro).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox2;
        private PictureBox picCarro;
        private System.Windows.Forms.Timer timerJogo;
    }
}
