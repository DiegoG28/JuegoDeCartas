using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoDeCartas {
    class Game {
        public static void StartGame() {
            Mazo mazo = new Mazo();
            Jugador player = new Jugador();
            Pantalla pantalla = new Pantalla();
            mazo.ReadCards();//Lee las cartas
            mazo.ShuffleCards();//Barajea las cartas
            player.DealCards();//Reparte las cartas

            pantalla.SplashScreen();//Activa la pantalla de carga
            Console.Clear();
            pantalla.ShowMenu();//Activa el menú del juego
            Console.Clear();
            pantalla.ShowTowers();//Dibuja las torres
            player.ShowCardsP1();//Dibuja las cartas

            Console.ReadLine();
        }
    }
}
