using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                    Jugador.botHP = DoDamage(Jugador.botHP, playerPower);
                    Jugador.playerHP = DoDamage(Jugador.playerHP, botPower - (playerPower - botPower));//Aquel que tenga la carta con mas poder, recibirá menos daño del que indique la carta del contrincante
                } else if (playerPower < botPower) {
                    Jugador.playerHP = DoDamage(Jugador.playerHP, botPower);
                    Jugador.botHP = DoDamage(Jugador.botHP, playerPower - (botPower - playerPower));//Aquel que tenga la carta con mas poder, recibirá menos daño del que indique la carta del contrincante
                }
            }

            if (pTypeCard.Equals("defensa") && botTypeCard.Equals("defensa")) {

            }

            if (pTypeCard.Equals("curación") && botTypeCard.Equals("curación")) {
                Jugador.playerHP = Heal(Jugador.playerHP, playerPower);
                Jugador.botHP = Heal(Jugador.botHP, botPower);
            }

            if (pTypeCard.Equals("defensa") && botTypeCard.Equals("ataque")) {
                if (playerPower > botPower) {

                } else if (playerPower < botPower) {
                    Jugador.playerHP = DoDamage(Jugador.playerHP, botPower - playerPower);
                } else if (playerPower == botPower) {

                }
            }

            if (pTypeCard.Equals("ataque") && botTypeCard.Equals("defensa")) {
                if (botPower > playerPower) {

                } else if (botPower < playerPower) {
                    Jugador.botHP = DoDamage(Jugador.botHP, playerPower - botPower);
                } else if (playerPower == botPower) {

                }
            }

            if(pTypeCard.Equals("curación") && botTypeCard.Equals("ataque")) {
                Jugador.playerHP = Heal(Jugador.playerHP, playerPower);
                Pantalla.PrintPlayerHP(Jugador.playerHP / 1000 % 10, Jugador.playerHP / 100 % 10, Jugador.playerHP / 10 % 10, Jugador.playerHP % 10);
                Thread.Sleep(1500);
                Jugador.playerHP = DoDamage(Jugador.playerHP, botPower);
            }

            if(pTypeCard.Equals("ataque") && botTypeCard.Equals("curación")) {
                Jugador.botHP = Heal(Jugador.botHP, botPower);
                Pantalla.PrintBotHP(Jugador.botHP / 1000 % 10, Jugador.botHP / 100 % 10, Jugador.botHP / 10 % 10, Jugador.botHP % 10);
                Thread.Sleep(1500);
                Jugador.botHP = DoDamage(Jugador.botHP, playerPower);
            }

            if(pTypeCard.Equals("curación") && botTypeCard.Equals("defensa")) {
                Jugador.playerHP = Heal(Jugador.playerHP, playerPower);
            }

            if(pTypeCard.Equals("defensa") && botTypeCard.Equals("curación")) {
                Jugador.botHP = Heal(Jugador.botHP, botPower);
            }


        }

        int DoDamage(int tower, int damage) {
            tower = tower - damage;
            return tower;
        }

        int Heal(int tower, int heal) {
            tower = tower + heal;
            return tower;
        }
    }
}
