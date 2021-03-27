﻿using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
namespace JuegoDeCartas {
    class Program {
        static void Main(string[] args) {
            Console.SetWindowSize(150, 44);
            Mazo mazo = new Mazo();
            Jugador player = new Jugador();
            Pantalla pantalla = new Pantalla();

            Console.SetBufferSize(150, 44);
            //pantalla.SplashScreen();
            Console.Clear();
            //pantalla.ShowFirstScreen();
            Console.Clear();

            mazo.ReadCards();
            mazo.ShuffleCards();
            player.DealCards();
            pantalla.InGame();
            player.ShowCardsP1();

            Console.ReadLine();
        }
    }
}
