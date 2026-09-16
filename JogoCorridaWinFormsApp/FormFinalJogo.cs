using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JogoCorridaWinFormsApp
{
    public partial class FormFinalJogo : Form
    {
        public FormFinalJogo(int pontos, double tempoTotal, int obstaculosSuperados, int moedasColetadas)
        {
            InitializeComponent();

            // Monta o texto com as estatísticas
            string textoFinal = $"--- FIM DE JOGO ---\n\n" +
                                $"Tempo Total: {tempoTotal:F1} segundos\n" +
                                $"Obstáculos Superados: {obstaculosSuperados}\n" +
                                $"Moedas Coletadas: {moedasColetadas}\n\n" +
                                $"PONTUAÇÃO FINAL: {pontos}";

            // Cria o texto visualmente pelo código
            Label lblEstatisticas = new Label();
            lblEstatisticas.Text = textoFinal;
            lblEstatisticas.Font = new Font("Arial", 16, FontStyle.Bold);

            // --- MODIFICAÇÕES AQUI ---
            // Preenche o formulário inteiro com a Label
            lblEstatisticas.Dock = DockStyle.Fill;
            // Alinha todo o texto no centro da Label (horizontal e vertical)
            lblEstatisticas.TextAlign = ContentAlignment.MiddleCenter;

            // Adiciona o texto no formulário
            this.Controls.Add(lblEstatisticas);
        }
    }
}