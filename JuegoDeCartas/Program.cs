using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
namespace JuegoDeCartas {
    class Program {
        static void Main(string[] args) {
            Console.SetWindowSize(150, 44);
            Console.SetBufferSize(150, 44);
            Mazo mazo = new Mazo();
            Jugador player = new Jugador();
            Pantalla pantalla = new Pantalla();

            //pantalla.ShowFirstScreen();
            Console.Clear();
            pantalla.InGame();

            mazo.ReadCards();
            mazo.ShuffleCards();
            player.DealCards();
            player.ShowCardsP1();

            Console.ReadLine();
        }
    }
}
