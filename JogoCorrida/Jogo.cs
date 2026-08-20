
namespace JogoCorrida
{
    public class Jogo
    {

        public Elemento Carro { get; set; }
        public List<Elemento> Obstaculos { get; set; }
        public int Velocidade { get; set; }
        public int Pontuacao { get; set; }
        public int Tempo { get; set; }
        public int MelhorPontuacao { get; set; }
        public int ColisoesPermitidas { get; set; }
        public int Faixa1Inicio { get; set; }
        public int Faixa1Fim { get; set; }
        public int Faixa2Inicio { get; set; }
        public int Faixa2Fim { get; set; }
        public int YMaximo { get; set; } = 50;

        public void IniciaJogo()
        {
            Carro = new Elemento();
            Carro.Tipo = TipoElemento.Carro;
            Carro.PosicaoX = PosicionaObjeto(1);
            Carro.PosicaoY = YMaximo - 100;

            Obstaculos = FabricaObstaculos(5, 120, 200);
        }
        public List<Elemento> FabricaObstaculos(int qtd, int dmin, int dmax)
        {
            var y_incial = 0;
            var obstaculos = new List<Elemento>();
            var rnd = new Random();

            for(int i = 0; i < qtd; i++)
            {
                if (i != 0) 
                    y_incial -= rnd.Next(dmin, dmax);
                var ob = new Elemento()
                {
                    Tipo = TipoElemento.Obstaculo
                };
                var faixa = rnd.Next(1, 3);
                ob.PosicaoX = PosicionaObjeto(faixa);
                ob.PosicaoY = y_incial;
                obstaculos.Add(ob);
                
            }
            return obstaculos;

        }
        public int PosicionaObjeto(int faixa)
        {
            if(faixa == 1)
            {
                return Faixa1Inicio + ((Faixa1Fim - Faixa1Inicio) / 2);
            }
            else
            {
                return Faixa2Inicio + ((Faixa2Fim - Faixa2Inicio) / 2);
            }
        }
        public void Acelerar(int incremento)
        {
            Velocidade += incremento;
        }
        private int ChecaFaixaElemento(Elemento elemento)
        {
            if(elemento.PosicaoX >= Faixa1Inicio && 
                elemento.PosicaoX <= Faixa1Fim)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public bool ChecarColisao()
        {
            foreach(var ob in Obstaculos)
            {
                if(ChecaFaixaElemento(Carro) == ChecaFaixaElemento(ob))
                {
                    if(Math.Abs(Carro.PosicaoY - ob.PosicaoY) < 60){
                        return true;
                    }
                }
            }
            return false;
        }

        public void MovimentaObstaculos()
        {
            foreach (var ob in Obstaculos)
            {
                ob.PosicaoY += 10;
                if(ob.PosicaoY > YMaximo)
                {
                    ob.PosicaoY = 0;
                }
            }
        }
        public bool VerificaFimJogo()
        {
            return true;
        }

    }
}
