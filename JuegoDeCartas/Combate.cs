using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Media;

namespace JuegoDeCartas {
    class Combate : Carta {
        SoundPlayer atkSound = new SoundPlayer("..\\..\\..\\sounds\\SoundAtack.wav");
        SoundPlayer defSound = new SoundPlayer("..\\..\\..\\sounds\\SoundDef.wav");
        SoundPlayer healSound = new SoundPlayer("..\\..\\..\\sounds\\SoundHp.wav");

        public Combate(int playerCard, int botCard) {

            StartBattle(playerCard, botCard);
        }

        void StartBattle(int pCard, int bCard) {
            string botTypeCard = base.GetType(bCard);
            string pTypeCard = base.GetType(pCard);
            int botPower = base.GetPower(bCard);
            int playerPower = base.GetPower(pCard);
            string battleType = GetBattletType(pTypeCard, botTypeCard);

            switch(battleType){
                case "ataque-ataque":
                    atkSound.Play();
                    if (playerPower > botPower) {
                        Jugador.botHP = DoDamage(Jugador.botHP, playerPower);
                        Jugador.playerHP = DoDamage(Jugador.playerHP, botPower/2);//Aquel que tenga la carta con mas poder, recibirá menos daño del que indique la carta del contrincante
                    } else if (playerPower < botPower) {
                        Jugador.playerHP = DoDamage(Jugador.playerHP, botPower);
                        Jugador.botHP = DoDamage(Jugador.botHP, playerPower/2);//Aquel que tenga la carta con mas poder, recibirá menos daño del que indique la carta del contrincante
                    }
                    break;

                case "defensa-defensa":
                    defSound.Play();
                    break;

                case "curación-curación":
                    healSound.Play();
                    Jugador.playerHP = Heal(Jugador.playerHP, playerPower);
                    Jugador.botHP = Heal(Jugador.botHP, botPower);
                    break;

                case "defensa-ataque":
                    if (playerPower > botPower) {
                        defSound.Play();
                    } else if (playerPower < botPower) {
                        atkSound.Play();
                        Jugador.playerHP = DoDamage(Jugador.playerHP, botPower - playerPower);
                    } else if (playerPower == botPower) {
                        defSound.Play();
                    }
                    break;

                case "ataque-defensa":
                    if (botPower > playerPower) {
                        defSound.Play();
                    } else if (botPower < playerPower) {
                        atkSound.Play();
                        Jugador.botHP = DoDamage(Jugador.botHP, playerPower - botPower);
                    } else if (playerPower == botPower) {
                        defSound.Play();
                    }
                    break;

                case "curación-ataque":
                    Jugador.playerHP = Heal(Jugador.playerHP, playerPower);
                    Pantalla.PrintPlayerHP(Jugador.playerHP / 1000 % 10, Jugador.playerHP / 100 % 10, Jugador.playerHP / 10 % 10, Jugador.playerHP % 10);
                    healSound.Play();
                    Thread.Sleep(2500);
                    atkSound.Play();
                    Jugador.playerHP = DoDamage(Jugador.playerHP, botPower);
                    break;

                case "ataque-curación":
                    Jugador.botHP = Heal(Jugador.botHP, botPower);
                    Pantalla.PrintBotHP(Jugador.botHP / 1000 % 10, Jugador.botHP / 100 % 10, Jugador.botHP / 10 % 10, Jugador.botHP % 10);
                    healSound.Play();
                    Thread.Sleep(2500);
                    atkSound.Play();
                    Jugador.botHP = DoDamage(Jugador.botHP, playerPower);
                    break;

                case "curación-defensa":
                    Jugador.playerHP = Heal(Jugador.playerHP, playerPower);
                    Pantalla.PrintPlayerHP(Jugador.playerHP / 1000 % 10, Jugador.playerHP / 100 % 10, Jugador.playerHP / 10 % 10, Jugador.playerHP % 10);
                    healSound.Play();
                    break;

                case "defensa-curación":
                    Jugador.botHP = Heal(Jugador.botHP, botPower);
                    Pantalla.PrintBotHP(Jugador.botHP / 1000 % 10, Jugador.botHP / 100 % 10, Jugador.botHP / 10 % 10, Jugador.botHP % 10);
                    healSound.Play();
                    break;
            }
        }

        public static bool CheckHP() {
            bool endGame = false;
            Pantalla finalScreen = new Pantalla();
            if (Jugador.playerHP <= 0 || Jugador.deckP1.Count==0) {
                finalScreen.ShowLoseScreen();
                endGame = true;
            }else if (Jugador.botHP <= 0 || Jugador.deckP1.Count==0) {
                finalScreen.ShowWinScreen();
                endGame = true;
            }
            return endGame;
        }

        string GetBattletType(string pTyCard, string bTyCard) {
            string battleType = "";
            if (pTyCard.Equals("ataque") && bTyCard.Equals("ataque")) {
                battleType = "ataque-ataque";
            }

            if (pTyCard.Equals("defensa") && bTyCard.Equals("defensa")) {
                battleType = "defensa-defensa";
            }

            if (pTyCard.Equals("curación") && bTyCard.Equals("curación")) {
                battleType = "curación-curación";
            }

            if (pTyCard.Equals("defensa") && bTyCard.Equals("ataque")) {
                battleType = "defensa-ataque";
            }

            if (pTyCard.Equals("ataque") && bTyCard.Equals("defensa")) {
                battleType = "ataque-defensa";
            }

            if (pTyCard.Equals("curación") && bTyCard.Equals("ataque")) {
                battleType = "curación-ataque";
            }

            if (pTyCard.Equals("ataque") && bTyCard.Equals("curación")) {
                battleType = "ataque-curación";
            }

            if (pTyCard.Equals("curación") && bTyCard.Equals("defensa")) {
                battleType = "curación-defensa";
            }

            if (pTyCard.Equals("defensa") && bTyCard.Equals("curación")) {
                battleType = "defensa-curación";
            }
            return battleType;
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
