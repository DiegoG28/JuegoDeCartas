using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace JuegoDeCartas {
    class Bot : Jugador {
        static int botCard;
        public static int UseBotCard() {
            int y = 5;
            for (int row = 2; row < 14; row++) {
                Console.SetCursorPosition(100, y);
                Console.WriteLine(deck[row, (int)deckP2[botCard]]);
                y++;
            }
            botCard++;
            return botCard - 1;
        }
    }
}
