using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;

namespace JuegoDeCartas {
    class Jugador : Mazo {
        ArrayList deckP1 = new ArrayList();
        public static ArrayList deckP2 = new ArrayList();

        public Jugador() {
            Console.CursorVisible = false;
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
            int y = 28;//posiciones iniciales en las que se dibujará la baraja, estos valores los seguiremos usando después.
            foreach (int idCard in deckP1) {
                for (int row = 2; row < 14; row++) {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(deck[row, idCard]);
                    y++;
                }
                x = x + 19;
                y = 28;
                Console.ForegroundColor = ConsoleColor.White;
            }
            ReadUserKey();
        }

        public void ReadUserKey() {
            ConsoleKeyInfo tecla;
            int selectedCard = 0;//Será usada como posición para determinar los valores de deckP1
            do {
                tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.RightArrow) {
                    if (selectedCard < deckP1.Count - 1) {//Esta condición es para que selectedCard NO tome un valor mayor al index del array deckP1
                        selectedCard++;
                        FocusIn(selectedCard);
                    }
                }
                if (tecla.Key == ConsoleKey.LeftArrow) {
                    if (selectedCard > 0) {
                        selectedCard--;
                        FocusIn(selectedCard);
                    }
                }
                if (tecla.Key == ConsoleKey.Enter) {
                    UseCard(selectedCard);
                }
            } while (tecla.Key != ConsoleKey.Enter);

        }

        public void FocusIn(int selectedCard) {
            int y = 28;
            int index = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int row = 2; row < 14; row++) {
                Console.SetCursorPosition(selectedCard * 19+7, y);//Esto nos sirve para cambiar el valor de x en función a la carta que ha sido seleccionada
                Console.WriteLine(deck[row, (int)deckP1[selectedCard]]);//Tomamos el valor de deckP1 en la posición selectedCard, esto ayudará a deck a saber que carta imprimir
                y++;
            }

            foreach (int idCard in deckP1) {
                y = 28;
                Console.ForegroundColor = ConsoleColor.White;
                if (index != selectedCard) {//Si el index = selectedCard, no entrará a esta condición, pues no queremos que la carta seleccionada se pinte blanco.
                    for (int row = 2; row < 14; row++) {
                        Console.SetCursorPosition(index * 19+7, y);//En este caso, x tomará valores en función a las cartas que NO están siendo seleccionadas.
                        Console.WriteLine(deck[row, idCard]);//Nos ayudamos con el foreach para ir imprimiendo las cartas no seleccionadas en color blanco.
                        y++;
                    }
                }
                index++;
            }
        }

        public void UseCard(int SelectedCard) {
            int y = 5;
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            for (int row = 2; row < 14; row++) {
                Console.SetCursorPosition(30, y);
                Console.WriteLine(deck[row, (int)deckP1[SelectedCard]]);
                y++;
            }
            deckP1.RemoveAt(SelectedCard);
            UpdateScreen();
        }

        public void UpdateScreen() {
            Pantalla pantalla = new Pantalla();
            Thread.Sleep(1000);
            Bot.UseBotCard();
            Thread.Sleep(1000);
            Console.Clear();
            pantalla.InGame();
            ShowCardsP1();
        }

    }
}
