using System;
using System.Collections;
using System.IO;
using System.Text;

namespace JuegoDeCartas {
    class Program {
        static void Main(string[] args) {
            Mazo mazo = new Mazo();
            Jugador player = new Jugador();
            mazo.ReadCards();
            mazo.ShuffleCards();
            player.DealCards();
            player.ShowCardsP1();

            Console.ReadLine();
        }
    }
}
