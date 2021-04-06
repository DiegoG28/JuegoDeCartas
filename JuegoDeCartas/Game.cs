using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JuegoDeCartas {
    class Game {
        public static void StartGame(bool secondRound) {
            Mazo mazo = new Mazo();
            Jugador player = new Jugador();
            Pantalla pantalla = new Pantalla();
            Console.CursorVisible = false;

            mazo.ReadCards();//Lee las cartas
            mazo.ShuffleCards();//Barajea las cartas
            player.DealCards();//Reparte las cartas
            Console.SetBufferSize(150, 44);

            if (!secondRound)
                pantalla.SplashScreen();//Activa la pantalla de carga
            Console.Clear();
            pantalla.ShowMenu(secondRound);//Activa el menú del juego
            Console.Clear();

            pantalla.ShowTowers();//Dibuja las torres
            player.ShowCardsP1();//Dibuja las cartas
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
