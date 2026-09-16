

using System.Data.Common;

namespace JogoCorrida
{
    public class Elemento
    {
        // Atributos da classe
        public TipoElemento Tipo { get; set; }

        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }

        public int Altura { get; set; }
        public int Largura { get; set; }

        public void Movimentar(int X, int Y)
        {
            PosicaoX = X;
            PosicaoY = Y;
        }
    }
}