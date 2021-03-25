using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoDeCartas {
    class Carta : Mazo {
        string type;
        int power;
        public int GetPower(int card) {
            power = int.Parse(deck[1, card]);
            return power;
        }
        public string GetType(int card) {
            type = deck[14, card];
            return type;
        }
    }
}
