using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
using System.Media;

namespace JuegoDeCartas {
    class Jugador : Mazo {
        public static ArrayList deckP1 = new ArrayList();
        public static ArrayList deckP2 = new ArrayList();
        public static int playerHP;
        public static int botHP;

        public Jugador() {
            Console.CursorVisible = false;
            playerHP = 1500;
            botHP = 1000;
            shuffledDeck.Clear();
        }
        public void DealCards() {
            bool dealP1 = true;
            foreach (int idCard in shuffledDeck) {
                if (dealP1) {
                    deckP1.Add(idCard);
                    dealP1 = false;
                } else {
                    deckP2.Add(idCard);
                    dealP1 = true;
                }
            }
        }
        public void ShowCardsP1() {
            Console.ForegroundColor = ConsoleColor.Blue;
            int x = 7;
            int y = 31;//posiciones iniciales en las que se dibujará la baraja, estos valores los seguiremos usando después.
            int cardsDisplayed = 7;
            if (deckP1.Count != 0) {
                foreach (int idCard in deckP1) {
                    if (cardsDisplayed > 0) {
                        for (int row = 2; row < 14; row++) {
                            if (cardsDisplayed == 7) {//La primera carta siempre estará seleccionada al principio, por lo tanto la alzamos.
                                Console.SetCursorPosition(x, y-2);
                                Console.WriteLine(deck[row, idCard]);
                                y++;
                            } else {
                                Console.SetCursorPosition(x, y);
                                Console.WriteLine(deck[row, idCard]);
                                y++;
                            }
                        }
                        cardsDisplayed--;
                    }
                    x = x + 20;
                    y = 31;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                ReadUserKey();
            }
        }

        public void ReadUserKey() {
            ConsoleKeyInfo tecla;
            SoundPlayer switchSound = new SoundPlayer("..\\..\\..\\sounds\\cardSwitch.wav");
            SoundPlayer selectSound = new SoundPlayer("..\\..\\..\\sounds\\cardSelect.wav");
            int selectedCard = 0;//Será usada como posición para determinar los valores de deckP1
            do {
                tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.RightArrow) {
                    if (selectedCard < 6 && selectedCard < deckP1.Count-1) {//Esta condición es para que selectedCard NO tome un valor mayor al index del array deckP1
                        selectedCard++;
                        FocusIn(selectedCard);
                    }
                    switchSound.Play();
                }
                if (tecla.Key == ConsoleKey.LeftArrow) {
                    if (selectedCard > 0) {
                        selectedCard--;
                        FocusIn(selectedCard);
                    }
                    switchSound.Play();
                }
                if (tecla.Key == ConsoleKey.Enter) {
                    selectSound.Play();
                    UseCard(selectedCard);
                }
            } while (tecla.Key != ConsoleKey.Enter);

        }

        public void FocusIn(int selectedCard) {
            int y = 31;
            int index = 0;
            int cardsDisplayed = 7;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int row = 2; row < 14; row++) {
                Console.SetCursorPosition(selectedCard * 20+7, y-2);//Esto nos sirve para cambiar el valor de x en función a la carta que ha sido seleccionada
                Console.WriteLine(deck[row, (int)deckP1[selectedCard]]);//Tomamos el valor de deckP1 en la posición selectedCard, esto ayudará a deck a saber que carta imprimir
                y++;
            }
            for (int y2 = 41; y2 < 43; y2++) {//Ya que alzamos la carta seleccionada, con esto limpiamos el sobrante que estaba en la pos original.
                Console.SetCursorPosition(selectedCard * 20 + 7, y2);
                Console.WriteLine("                  ");
            }

            foreach (int idCard in deckP1) {
                y = 31;
                Console.ForegroundColor = ConsoleColor.White;
                if (cardsDisplayed > 0) {
                    if (index != selectedCard) {//Si el index = selectedCard, no entrará a esta condición, pues no queremos que la carta seleccionada se pinte blanco.
                        for (int row = 2; row < 14; row++) {
                            Console.SetCursorPosition(index * 20 + 7, y);//En este caso, x tomará valores en función a las cartas que NO están siendo seleccionadas.
                            Console.WriteLine(deck[row, idCard]);//Nos ayudamos con el foreach para ir imprimiendo las cartas no seleccionadas en color blanco.
                            y++;
                        }
                        for (int y2 = 29; y2 < 31; y2++) {//Ya que alzamos la carta seleccionada, con esto limpiamos el sobrante que estaba en la pos original.
                            Console.SetCursorPosition(index * 20 + 7, y2);
                            Console.WriteLine("                  ");
                        }
                    }
                    cardsDisplayed--;
                }
                index++;
            }
        }

        public void UseCard(int selectedCard) {
            int y = 5;
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            for (int row = 2; row < 14; row++) {
                Console.SetCursorPosition(30, y);
                Console.WriteLine(deck[row, (int)deckP1[selectedCard]]);
                y++;
            }
            Thread.Sleep(1000);
            Combate battle = new Combate((int)deckP1[selectedCard], (int)deckP2[Bot.UseBotCard()]);//Básicamente pasamos las cartas seleccionadas por el usuario y el bot
            deckP1.RemoveAt(selectedCard);
            

            UpdateScreen();
        }

        public void UpdateScreen() {
            Pantalla pantalla = new Pantalla();
            Thread.Sleep(2500);
            Console.Clear();
            if (!Combate.CheckHP()) {
                pantalla.ShowTowers();
                ShowCardsP1();
            }
        }

    }
}
