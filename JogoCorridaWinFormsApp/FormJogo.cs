using JogoCorrida;
using JogoCorridaWinFormsApp.Properties;
using System.Resources;

namespace JogoCorridaWinFormsApp
{
    public partial class FormJogoCorrida : Form
    {
        Jogo jogo;
        DateTime tempoUltimaMovimentacao = DateTime.Now;
        List<PictureBox> pictureBoxes = [];

        public FormJogoCorrida()
        {
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJogoCorrida));
            jogo = new Jogo
            {
                Faixa1Inicio = 2,
                Faixa1Fim = 198,
                Faixa2Inicio = 13,
                Faixa2Fim = 398
            };

            jogo.YMaximo = 550;
            jogo.IniciaJogo();
            jogo.Carro.PosicaoX = jogo.PosicionaObjeto(1);
            jogo.Velocidade = 100;


            foreach (var ob in jogo.Obstaculos) // criação das imagens dos obstaculos
            {
                var picOb = new PictureBox();
                picOb.BackColor = Color.Transparent;
                picOb.BackgroundImage = Properties.Resources.picObjeto;
                picOb.BackgroundImageLayout = ImageLayout.Stretch;
                //picObjeto.BackgroundImage = (Image)resources.GetObject("picObjeto.BackgroundImage");
                //picOb.BackgroundImageLayout = ImageLayout.Stretch;
                picOb.Size = new Size(50, 80);
                pictureBoxes.Add(picOb); // adicona a imagem na lista interna
                this.Controls.Add(picOb); // adiciona a imagem no formulario
            }
            timerJogo.Enabled = true;

        }



        public static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
        }

        static void TocarSom()
        {
            Console.Beep();
        }


        private void FormJogoCorrida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                jogo.Carro.PosicaoX = jogo.PosicionaObjeto(2);
            }
            if (e.KeyCode == Keys.Left)
            {
                jogo.Carro.PosicaoX = jogo.PosicionaObjeto(1);
            }

        }

        private void timerJogo_Tick(object sender, EventArgs e)
        {
            picCarro.Location = new Point(jogo.Carro.PosicaoX, jogo.Carro.PosicaoY);
            var i = 0;
            foreach (var ob in jogo.Obstaculos)
            {
                if (ob.PosicaoY >= 0)
                {
                    pictureBoxes[i].Location = new Point(ob.PosicaoX, ob.PosicaoY);
                }
                i++;
            }


            if ((DateTime.Now - tempoUltimaMovimentacao).Milliseconds > jogo.Velocidade)
            {
                tempoUltimaMovimentacao = DateTime.Now;
                jogo.MovimentaObstaculos();
            }

            if (jogo.ChecarColisao())
            {
                //GameOver();
                //TocarSom();
                //break;
                Application.Exit();
            }
            Application.DoEvents();

        }

        private void FormJogoCorrida_Load(object sender, EventArgs e)
        {

        }
    }
}
