namespace JogoCorrida
{
    public class Jogo
    {
        public Elemento Carro { get; set; }
        public List<Elemento> Obstaculos { get; set; }
        public List<Elemento> Moedas { get; set; } // Nova lista para as moedas

        public int Velocidade { get; set; }
        public int YMaximo { get; set; } = 550;

        // --- Sistema de Pontuação e Nível ---
        public double PontuacaoReal { get; private set; } 
        public int Pontuacao => (int)PontuacaoReal;
        public double TempoJogandoSegundos { get; private set; }
        public int ObstaculosSuperados { get; private set; }
        public int MoedasColetadas { get; private set; }

        public int NivelAtual { get; private set; }
        public double PontosPor10Segundos { get; private set; }

        public int Faixa1Inicio { get; set; }
        public int Faixa1Fim { get; set; }
        public int Faixa2Inicio { get; set; }
        public int Faixa2Fim { get; set; }

        public void ConfigurarNivel(int nivel)
        {
            NivelAtual = nivel;
            if (nivel == 1) // Fácil
            {
                Velocidade = 150; 
                PontosPor10Segundos = 1.0;
            }
            else if (nivel == 2) // Médio
            {
                Velocidade = 100;
                PontosPor10Segundos = 1.25;
            }
            else // Difícil
            {
                Velocidade = 50; 
                PontosPor10Segundos = 1.6;
            }
        }

        public void IniciaJogo()
        {
            Carro = new Elemento { Tipo = TipoElemento.Carro, PosicaoX = PosicionaObjeto(1), PosicaoY = YMaximo - 10 };
            PontuacaoReal = 0;
            TempoJogandoSegundos = 0;
            ObstaculosSuperados = 0;
            MoedasColetadas = 0;

            Obstaculos = FabricaObstaculos(4, 150, 250);
            Moedas = FabricaMoedas(2);
        }

        public List<Elemento> FabricaObstaculos(int qtd, int dmin, int dmax)
        {
            var y_inicial = 0;
            var obstaculos = new List<Elemento>();
            var rnd = new Random();

            for (int i = 0; i < qtd; i++)
            {
                if (i != 0) y_inicial -= rnd.Next(dmin, dmax);

                // Sorteia o tipo do obstáculo (0 a 2)
                int tipoSorteado = rnd.Next(0, 3);
                TipoElemento tipoOb = TipoElemento.ObstaculoNormal;
                if (tipoSorteado == 1) tipoOb = TipoElemento.Galinha;
                if (tipoSorteado == 2) tipoOb = TipoElemento.Bomba;

                var ob = new Elemento { Tipo = tipoOb, PosicaoX = PosicionaObjeto(rnd.Next(1, 3)), PosicaoY = y_inicial };
                obstaculos.Add(ob);
            }
            return obstaculos;
        }

        public List<Elemento> FabricaMoedas(int qtd)
        {
            var moedas = new List<Elemento>();
            for (int i = 0; i < qtd; i++)
            {
                var moeda = new Elemento { Tipo = TipoElemento.Moeda };
                ReposicionarElemento(moeda); // Usa a nossa nova regra de segurança
                moedas.Add(moeda);
            }
            return moedas;
        }

        public int PosicionaObjeto(int faixa)
        {
            if (faixa == 1)
            {
                return Faixa1Inicio + ((Faixa1Fim - Faixa1Inicio) / 2) - 25;
            }
            else
            {
                return Faixa2Inicio + ((Faixa2Fim - Faixa2Inicio) / 2) - 25;
            }
        }

        private int ChecaFaixaElemento(Elemento elemento)
        {
            return (elemento.PosicaoX >= Faixa1Inicio && elemento.PosicaoX <= Faixa1Fim) ? 1 : 2;
        }

        public bool ChecarColisao()
        {
            foreach (var ob in Obstaculos)
            {
                if (ChecaFaixaElemento(Carro) == ChecaFaixaElemento(ob) && Math.Abs(Carro.PosicaoY - ob.PosicaoY) < 60)
                {
                    return true; // Bateu no obstáculo
                }
            }
            return false;
        }

        public void ChecarColetaMoedas()
        {
            foreach (var moeda in Moedas)
            {
                if (ChecaFaixaElemento(Carro) == ChecaFaixaElemento(moeda) && Math.Abs(Carro.PosicaoY - moeda.PosicaoY) < 60)
                {
                    MoedasColetadas++;
                    PontuacaoReal += 5; // Cada moeda vale 5 pontos (ajuste como quiser)
                    ReposicionarElemento(moeda); // Faz a moeda sumir e voltar lá em cima
                }
            }
        }

        public void AtualizarPontuacaoPorTempo(double milissegundosPassados)
        {
            double segundos = milissegundosPassados / 1000.0;
            TempoJogandoSegundos += segundos;

            // Regra: Pontos a cada 10 segundos baseados no nível.
            // Para atualizar constantemente, calculamos a fração por segundo.
            double pontosPorSegundo = PontosPor10Segundos / 10.0;
            PontuacaoReal += pontosPorSegundo * segundos;
        }

        public void MovimentaElementos()
        {
            foreach (var ob in Obstaculos)
            {
                ob.PosicaoY += 10;
                if (ob.PosicaoY > YMaximo)
                {
                    ReposicionarElemento(ob);
                    ObstaculosSuperados++;
                    PontuacaoReal += 2; // Pontos por obstáculo superado
                }
            }

            foreach (var moeda in Moedas)
            {
                moeda.PosicaoY += 10;
                if (moeda.PosicaoY > YMaximo) ReposicionarElemento(moeda);
            }
        }

        private void ReposicionarElemento(Elemento el)
        {
            var rnd = new Random();

            if (el.Tipo == TipoElemento.Moeda)
            {
                bool posicaoSegura = false;
                while (!posicaoSegura)
                {
                    el.PosicaoX = PosicionaObjeto(rnd.Next(1, 3));
                    el.PosicaoY = rnd.Next(-800, -150); 

                    posicaoSegura = true;
                    foreach (var ob in Obstaculos)
                    {
                        if (ob.PosicaoX == el.PosicaoX && Math.Abs(ob.PosicaoY - el.PosicaoY) < 120)
                        {
                            posicaoSegura = false; 
                            break;
                        }
                    }
                }
            }
            else
            {
                el.PosicaoX = PosicionaObjeto(rnd.Next(1, 3));
                int topoY = 0;

                foreach (var ob in Obstaculos)
                {
                    if (ob != el && ob.PosicaoY < topoY)
                    {
                        topoY = ob.PosicaoY;
                    }
                }

                el.PosicaoY = topoY - rnd.Next(150, 250);
            }
        }
        public void MovimentaObstaculos()
        {
            MovimentaElementos();
        }
    }
}