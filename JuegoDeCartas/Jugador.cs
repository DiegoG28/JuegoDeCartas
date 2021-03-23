using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JuegoDeCartas {
    class Jugador : Mazo {
        int[] deckP1 = new int[totalCards / 2];
        int[] deckP2 = new int[totalCards / 2];

        public Jugador() {
            Console.CursorVisible = false;
        }
        public void DealCards() {
            bool dealP1 = true;
            int deckPosP1 = 0;
            int deckPosP2 = 0;
            foreach (int idCard in shuffledDeck) {
                if (dealP1) {
                    deckP1[deckPosP1] = idCard;
                    deckPosP1++;
                    dealP1 = false;
                } else {
                    deckP2[deckPosP2] = idCard;
                    dealP1 = true;
                    deckPosP2++;
                }
            }
        }

        public void ShowCardsP1() {
            Console.ForegroundColor = ConsoleColor.Blue;
            int x = 0;
            int y = 0;
            foreach(int idCard in deckP1) {
                for (int row = 2; row < 14; row++) {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(deck[row, idCard]);
                    y++;
                }
                x = x+19;
                y = 0;
                Console.ForegroundColor = ConsoleColor.White;
            }
            SelectCard();
        }

        public void SelectCard() {
            ConsoleKeyInfo tecla;
            int option = 0;
            do {
                tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.RightArrow) {
                    if (option < totalCards/2-1) {
                        option++;
                        FocusInCard(option);
                    }
                }
                if(tecla.Key == ConsoleKey.LeftArrow) {
                    if (option > 0) {
                        option--;
                        FocusInCard(option);
                    }
                }
                if(tecla.Key == ConsoleKey.Enter) {
                    UseCard(option);
                }
            } while (tecla.Key != ConsoleKey.Enter);

        }

        public void FocusInCard(int option) {
            int y = 0;
            int index = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int row = 2; row < 14; row++) {
                Console.SetCursorPosition(option * 19, y);
                Console.WriteLine(deck[row, deckP1[option]]);
                y++;
            }

            foreach(int idCard in deckP1) {
                y = 0;
                Console.ForegroundColor = ConsoleColor.White;
                if (index != option) {
                    for (int row = 2; row < 14; row++) {
                        Console.SetCursorPosition(index * 19, y);
                        Console.WriteLine(deck[row, idCard]);
                        y++;
                    }
                }
                index++;
            }
        }

        public void UseCard(int option) {
            Console.ForegroundColor = ConsoleColor.White;
            for (int row = 2; row < 14; row++) {
                Console.WriteLine(deck[row, deckP1[option]]);

            }
        }

    }
}
