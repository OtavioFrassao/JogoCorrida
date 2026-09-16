using JogoCorrida;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks; // Para o efeito visual de espera
using System.Windows.Forms;

namespace JogoCorridaWinFormsApp
{
    public partial class FormJogoCorrida : Form
    {
        Jogo jogo;
        DateTime tempoUltimaMovimentacao = DateTime.Now;
        DateTime tempoUltimoTick = DateTime.Now; // Para calcular pontuação por tempo

        List<PictureBox> pictureBoxesObstaculos = new List<PictureBox>();
        List<PictureBox> pictureBoxesMoedas = new List<PictureBox>();

        public FormJogoCorrida(int nivelSelecionado)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            jogo = new Jogo
            {
                Faixa1Inicio = 2,
                Faixa1Fim = 198,
                Faixa2Inicio = 202,
                Faixa2Fim = 398
            };

            jogo.ConfigurarNivel(nivelSelecionado); // Define a velocidade e os pontos
            jogo.YMaximo = 550;
            jogo.IniciaJogo();

            CarregarGraficos();
            picCarro.Location = new Point(jogo.Carro.PosicaoX, jogo.Carro.PosicaoY);

            tempoUltimaMovimentacao = DateTime.Now;
            tempoUltimoTick = DateTime.Now;
            timerJogo.Enabled = true;
        }

        private void CarregarGraficos()
        {
            foreach (var ob in jogo.Obstaculos)
            {
                var picOb = new PictureBox();
                picOb.BackColor = Color.Transparent;
                picOb.BackgroundImageLayout = ImageLayout.Stretch;
                picOb.Size = new Size(50, 80);

                // Puxa a imagem exata do Resources baseada no tipo sorteado
                if (ob.Tipo == TipoElemento.Bomba)
                    picOb.BackgroundImage = Properties.Resources.imagembomba;
                else if (ob.Tipo == TipoElemento.Galinha)
                    picOb.BackgroundImage = Properties.Resources.imagemgalinha;
                else
                    picOb.BackgroundImage = Properties.Resources.picObjeto; // Obstáculo normal

                pictureBoxesObstaculos.Add(picOb);
                this.Controls.Add(picOb);
            }

            // Criar imagens das moedas
            foreach (var moeda in jogo.Moedas)
            {
                var picMoeda = new PictureBox();
                picMoeda.BackColor = Color.Transparent; // Tira o fundo amarelo sólido
                picMoeda.BackgroundImage = Properties.Resources.imagemmoeda; // Coloca a imagem da moeda
                picMoeda.Size = new Size(30, 30);
                picMoeda.BackgroundImageLayout = ImageLayout.Stretch;

                pictureBoxesMoedas.Add(picMoeda);
                this.Controls.Add(picMoeda);
            }
        }

        private void FormJogoCorrida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) jogo.Carro.PosicaoX = jogo.PosicionaObjeto(2);
            if (e.KeyCode == Keys.Left) jogo.Carro.PosicaoX = jogo.PosicionaObjeto(1);
        }

        private async void timerJogo_Tick(object sender, EventArgs e)
        {
            picCarro.Location = new Point(jogo.Carro.PosicaoX, jogo.Carro.PosicaoY);

            // Atualiza tempo e pontuação por tempo
            var tempoPassado = (DateTime.Now - tempoUltimoTick).TotalMilliseconds;
            jogo.AtualizarPontuacaoPorTempo(tempoPassado);
            tempoUltimoTick = DateTime.Now;

            // Desenha obstáculos
            for (int i = 0; i < jogo.Obstaculos.Count; i++)
            {
                pictureBoxesObstaculos[i].Location = new Point(jogo.Obstaculos[i].PosicaoX, jogo.Obstaculos[i].PosicaoY);
            }

            // Desenha moedas
            for (int i = 0; i < jogo.Moedas.Count; i++)
            {
                pictureBoxesMoedas[i].Location = new Point(jogo.Moedas[i].PosicaoX, jogo.Moedas[i].PosicaoY);
            }

            if ((DateTime.Now - tempoUltimaMovimentacao).Milliseconds > jogo.Velocidade)
            {
                tempoUltimaMovimentacao = DateTime.Now;
                jogo.MovimentaElementos(); // Move obstáculos e moedas
                jogo.ChecarColetaMoedas(); // Verifica se pegou moeda
            }

            // Aqui você pode atualizar as labels de UI se tiver no designer
            // lblPontos.Text = "Pontos: " + jogo.Pontuacao;

            if (jogo.ChecarColisao())
            {
                timerJogo.Stop();
                await EfeitoBatida(); // Chama o efeito visual

                FormFinalJogo formFinal = new FormFinalJogo(jogo.Pontuacao, jogo.TempoJogandoSegundos, jogo.ObstaculosSuperados, jogo.MoedasColetadas);
                this.Hide();
                formFinal.ShowDialog();
                this.Close();
            }
        }

        private async Task EfeitoBatida()
        {
            // Efeito 1: Muda a cor de fundo da rua simulando uma tela de dano
            this.BackColor = Color.Red;
            
            // Efeito 2: Muda a imagem do seu carro para a explosão que você colocou no Resources
            picCarro.BackgroundImage = Properties.Resources.imagemexplosao;

            // Aguarda meio segundo para o jogador processar que bateu antes de fechar a tela
            await Task.Delay(500);
        }

        private void FormJogoCorrida_Load(object sender, EventArgs e)
        {
        }
    }
}