using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JogoCorridaWinFormsApp
{
    public partial class FormNivelJogo : Form
    {
        public FormNivelJogo()
        {
            InitializeComponent();

            // Assumindo que você tem os botões btnFacil, btnMedio, btnDificil no Designer
            btnFacil.Click += (s, e) => IniciarJogo(1);
            btnMedio.Click += (s, e) => IniciarJogo(2);
            btnDificil.Click += (s, e) => IniciarJogo(3);
        }

        private void IniciarJogo(int nivel)
        {
            FormJogoCorrida formJogo = new FormJogoCorrida(nivel);
            this.Hide();
            formJogo.ShowDialog();
            this.Close(); // Fecha o menu quando o jogo acabar
        }
    }
}
