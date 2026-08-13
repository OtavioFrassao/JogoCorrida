class Program
{
    static void Main()
    {
        //Thread keyThread = new Thread(ListenerForKeys);
        Console.WriteLine("Hello, World!");
        var posicao = "Left";
        for ( ; ; ) {
            Desenha_Cenario();
            Desenha_Elemento(2, 5, '0');
            Desenha_Elemento(4, 17, '0');
            Desenha_Elemento(10, posicao == "Left" ? 5 : 17, '8');
            
            if (Console.KeyAvailable)
            {
                var tecla = Console.ReadKey();
                Console.WriteLine(tecla.Key.ToString());
                if(tecla.Key == ConsoleKey.LeftArrow)
                {
                    posicao = "Left";
                }else if(tecla.Key == ConsoleKey.RightArrow)
                {
                    posicao = "Right";
                }
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
}
