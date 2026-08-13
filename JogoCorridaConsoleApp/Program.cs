using JogoCorrida;
class Program
{
    static void Main()
    {
        Jogo jogo = new Jogo
        {
            Faixa1Inicio = 2,
            Faixa1Fim = 11,
            Faixa2Inicio = 13,
            Faixa2Fim = 22
        };
        jogo.IniciaJogo();
        jogo.YMaximo = 11;
        jogo.Carro.PosicaoX = jogo.PosicionaObjeto(1);
        jogo.Carro.PosicaoY = 10;
        jogo.Velocidade = 200;
        var tempoUltimaMovimentacao = DateTime.Now;

        var diferencaTempo = (DateTime.Now - tempoUltimaMovimentacao).Milliseconds;


        for ( ; ; ) {
            Desenha_Cenario();
            Desenha_Elemento(jogo.Carro.PosicaoY, jogo.Carro.PosicaoX, '8');

            foreach (var ob in jogo.Obstaculos)
            {
                if(ob.PosicaoY >= 0)
                {
                    Desenha_Elemento(ob.PosicaoY, ob.PosicaoX, '0');
                }
            }
            

            if((DateTime.Now - tempoUltimaMovimentacao).Milliseconds > jogo.Velocidade)
            {
                tempoUltimaMovimentacao = DateTime.Now;
                jogo.MovimentaObstaculos();
            }
            if (Console.KeyAvailable)
            {
                var tecla = Console.ReadKey();
                Console.WriteLine(tecla.Key.ToString());
                if(tecla.Key == ConsoleKey.LeftArrow)
                {
                    jogo.Carro.PosicaoX = jogo.PosicionaObjeto(1);
                }
                else if(tecla.Key == ConsoleKey.RightArrow)
                {
                    jogo.Carro.PosicaoX = jogo.PosicionaObjeto(2);
                }
                TocarSom();
            }
            if (jogo.ChecarColisao())
            {
                GameOver();
                TocarSom();
                break;
            }
            Thread.Sleep(150);
        }
    }

    public static void Desenha_Elemento(int linha, int coluna, char simbolo)
    {
        var xOriginal = Console.CursorLeft;
        var yOriginal = Console.CursorTop;
        Console.SetCursorPosition(coluna, linha);
        Console.Write(simbolo.ToString());
        Console.SetCursorPosition(xOriginal, yOriginal);
    }

    public static void GameOver()
    {
        Console.Clear();
        Console.WriteLine("Game Over!");
    }
    public static void Desenha_Cenario()
    {
        Console.Clear();
        Console.WriteLine("+----------+----------+");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("|          |          |");
        Console.WriteLine("+----------+----------+");
    }
    static void TocarSom()
    {
        Console.Beep();
    }
}

