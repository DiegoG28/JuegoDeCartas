using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoDeCartas {
    class Combate : Carta {

        public Combate(int playerCard, int botCard) {

            StartBattle(playerCard, botCard);
        }

        void StartBattle(int pCard, int bCard) {
            string botTypeCard = base.GetType(bCard);
            string pTypeCard = base.GetType(pCard);
            int playerPower = base.GetPower(pCard);
            int botPower = base.GetPower(bCard);

            if (pTypeCard.Equals("ataque") && botTypeCard.Equals("ataque")) {
                if (playerPower > botPower) {
                    Jugador.botHP = DoDamage(Jugador.botHP, playerPower - botPower);
                } else if (playerPower < botPower) {
                    Jugador.playerHP = DoDamage(Jugador.playerHP, botPower - playerPower);
                }else if (playerPower == botPower) {
                    Jugador.playerHP = DoDamage(Jugador.playerHP, playerPower);
                    Jugador.botHP = DoDamage(Jugador.botHP, playerPower);
                }
            }
        }

        int DoDamage(int tower, int damage) {
            tower = tower - damage;
            return tower;
        }
    }
}
