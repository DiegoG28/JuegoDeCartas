using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;

namespace JuegoDeCartas {
    class Pantalla : Dibujos {

        public void ShowDealScreen() {
            int pos = 5;
            for (int i = 0; i < Torrecita.Length; i++) {
                pos++;
                Console.SetCursorPosition(20, pos);
                Console.WriteLine(Torrecita[i]);
            }
            pos = 5;
            for (int i = 0; i < Torrecita.Length; i++) {
                pos++;
                Console.SetCursorPosition(115, pos);
                Console.WriteLine(Torrecita[i]);
            }

            pos = 10;
            for (int i = 0; i < Vss.Length; i++) {
                pos++;
                Console.SetCursorPosition(55, pos);
                Console.WriteLine(Vss[i]);
            }
            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(67, 25);
                Console.Write("Repartiendo cartas."); Thread.Sleep(1000);
                Console.Write("."); Thread.Sleep(500);
                Console.Write("."); Thread.Sleep(500);
                Console.SetCursorPosition(78, 25);
                Console.WriteLine("   ");
            }
        }
        public void ShowTowers() {
            int pos = 0;
            for (int i = 0; i < Torrecita.Length; i++) {
                pos++;
                Console.SetCursorPosition(9, pos);
                Console.WriteLine(Torrecita[i]);
            }
            pos = 0;
            for (int i = 0; i < Torrecita.Length; i++) {
                pos++;
                Console.SetCursorPosition(125, pos);
                Console.WriteLine(Torrecita[i]);
            }

            DrawNumbers();//Guardamos dibujos de los números que usaremos a continuación
            PrintPlayerHP(Jugador.playerHP / 1000 % 10, Jugador.playerHP / 100 % 10, Jugador.playerHP / 10 % 10, Jugador.playerHP % 10);
            PrintBotHP(Jugador.botHP / 1000 % 10, Jugador.botHP / 100 % 10, Jugador.botHP / 10 % 10, Jugador.botHP % 10);
        }
        public void ShowMenu(bool secondRound) {
            int pos = 2;
            for (int i = 0; i < Towerdes.Length; i++) {
                pos++;
                Console.SetCursorPosition(1, pos);
                Console.WriteLine(Towerdes[i]);
            }
            pos = 14;
            for (int i = 0; i < Torrecita.Length; i++) {
                pos++;
                Console.SetCursorPosition(19, pos);
                Console.WriteLine(Torrecita[i]);
            }
            pos = 14;
            for (int i = 0; i < Torrecita.Length; i++) {
                pos++;
                Console.SetCursorPosition(119, pos);
                Console.WriteLine(Torrecita[i]);
            }
            pos = 15;
            for (int i = 0; i < Start.Length; i++) {
                pos++;
                Console.SetCursorPosition(51, pos);
                Console.WriteLine(Start[i]);
            }
            pos = 27;
            for (int i = 0; i < Exit.Length; i++) {
                pos++;
                Console.SetCursorPosition(51, pos);
                Console.WriteLine(Exit[i]);
            }

            SoundPlayer sound = new SoundPlayer("..\\..\\..\\sounds\\sonidito.wav");
            bool ejecutar = false;
            for (int k = 0; ;) {
                opciones(k);
                if (ejecutar) {
                    return;
                }
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key) {
                    case ConsoleKey.UpArrow: k--; break;
                    case ConsoleKey.DownArrow: k++; break;
                    case ConsoleKey.Enter: 
                        if (!secondRound) {
                            ejecutar = true;
                        } break;
                }
                if (k < 0) k = 1; else if (k > 1) k = 0;
                if (ejecutar) {
                    switch (k) {
                        case 0: Console.SetCursorPosition(62, 12);
                                if (!secondRound) {
                                    k = 3;
                                    sound.PlaySync();
                                 } else {
                                    k = -1;
                                } 
                                break;
                        case 1: Console.Clear(); Console.SetCursorPosition(62, 12); k = 4; Environment.Exit(0); break;
                        case 3: Console.Clear(); break;
                    }
                }
                if (secondRound)
                    secondRound = false;
            }

            void opciones(int k) {
                if (k==0) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    pos = 17;
                    for (int i = 0; i < Startt.Length; i++) {
                        pos++;
                        Console.SetCursorPosition(55, pos);
                        Console.WriteLine(Startt[i]);
                    }
                }
                if (k == 1) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    pos = 17;
                    for (int i = 0; i < Startt.Length; i++) {
                        pos++;
                        Console.SetCursorPosition(55, pos);
                        Console.WriteLine(Startt[i]);
                    }
                }
                if (k == 1) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    pos = 29;
                    for (int i = 0; i < Exitt.Length; i++) {
                        pos++;
                        Console.SetCursorPosition(59, pos);
                        Console.WriteLine(Exitt[i]);
                    }
                }
                if (k == 0) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    pos = 29;
                    for (int i = 0; i < Exitt.Length; i++) {
                        pos++;
                        Console.SetCursorPosition(59, pos);
                        Console.WriteLine(Exitt[i]);
                    }
                }
                if (k == 3) {
                    Console.Clear();
                    ShowDealScreen();
                }
            }
        }
        public void ShowLostScreen() {
            SoundPlayer sound = new SoundPlayer("..\\..\\..\\sounds\\abucheo.wav");
            Console.ForegroundColor = ConsoleColor.Red;
            int pos;
            pos = 2;
            for (int i = 0; i < Torrecitaff.Length; i++) {
                pos++;
                Console.SetCursorPosition(69, pos);
                Console.WriteLine(Torrecitaff[i]);
            }
            pos = 28;
            for (int i = 0; i < base.Lost.Length; i++) {
                pos++;
                Console.SetCursorPosition(42, pos);
                Console.WriteLine(base.Lost[i]);
            }
            EndButton();
            //sound.PlaySync();
        }
        public void ShowWonScreen() {
            SoundPlayer sound = new SoundPlayer("..\\..\\..\\sounds\\aplausos.wav");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int pos;
            pos = 2;
            for (int i = 0; i < Torrecita.Length; i++) {
                pos++;
                Console.SetCursorPosition(69, pos);
                Console.WriteLine(Torrecita[i]);
            }
            pos = 28;
            for (int i = 0; i < Won.Length; i++) {
                pos++;
                Console.SetCursorPosition(45, pos);
                Console.WriteLine(Won[i]);
            }
            //sound.PlaySync();
            EndButton();
        }
        public void EndButton() {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int x = 58, y = 35;
            bool gray = true;

            while (x!=0) {
                if (Console.KeyAvailable) {
                    return;
                }
                Thread.Sleep(700);
                for (int i = 0; i < Continuar.Length; i++) {
                    y++;

                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(Continuar[i]);
                }
                x = 58;
                y = 35;
                if (gray) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    gray = false;
                } else {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    gray = true;
                }
            }
        }


        public static void PrintPlayerHP(int d1, int d2, int d3, int d4) {
            Console.ForegroundColor = ConsoleColor.Red;
            int y = 25;
            int x = 9;

            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(numbers[i, d1]);
                y++;
            }
            y = 25;
            x = x + 4;
            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(numbers[i, d2]);
                y++;
            }
            y = 25;
            x = x + 4;
            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(numbers[i, d3]);
                y++;
            }
            y = 25;
            x = x + 4;
            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(numbers[i, d4]);
                y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintBotHP(int d1, int d2, int d3, int d4) {
            Console.ForegroundColor = ConsoleColor.Red;
            int y = 25;
            int x = 125;

            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(numbers[i, d1]);
                y++;
            }
            y = 25;
            x = x + 4;
            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(numbers[i, d2]);
                y++;
            }
            y = 25;
            x = x + 4;
            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(numbers[i, d3]);
                y++;
            }
            y = 25;
            x = x + 4;
            for (int i = 0; i < 3; i++) {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(numbers[i, d4]);
                y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SplashScreen() {
            int pos;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            char[] line1 = "██████  ██████ ██████████████ ██████████████   ████████████████   ██████████████ ██████████████".ToCharArray();
            char[] line2 = "██░░██  ██░░██ ██░░░░░░░░░░██ ██░░░░░░░░░░██   ██░░░░░░░░░░░░██   ██░░░░░░░░░░██ ██░░░░░░░░░░██".ToCharArray();
            char[] line3 = "██░░██  ██░░██ ██░░██████░░██ ██░░██████░░██   ██░░████████░░██   ██░░██████░░██ ██░░██████░░██".ToCharArray();
            char[] line4 = "██░░██  ██░░██ ██░░██  ██░░██ ██░░██  ██░░██   ██░░██    ██░░██   ██░░██  ██░░██ ██░░██  ██░░██".ToCharArray();
            char[] line5 = "██░░██  ██░░██ ██░░██████░░██ ██░░██  ██░░██   ██░░████████░░██   ██░░██  ██░░██ ██░░██  ██░░██".ToCharArray();
            char[] line6 = "██░░██  ██░░██ ██░░░░░░░░░░██ ██░░██  ██░░██   ██░░░░░░░░░░░░██   ██░░██  ██░░██ ██░░██  ██░░██".ToCharArray();
            char[] line7 = "██░░██  ██░░██ ██░░██████████ ██░░██  ██░░██   ██░░██████░░████   ██░░██  ██░░██ ██░░██  ██░░██".ToCharArray();
            char[] line8 = "██░░██  ██░░██ ██░░██         ██░░██  ██░░██   ██░░██  ██░░██     ██░░██  ██░░██ ██░░██  ██░░██".ToCharArray();
            char[] line9 = "██░░██████░░██ ██░░██         ██░░██████░░████ ██░░██  ██░░██████ ██░░██████░░██ ██░░██████░░██".ToCharArray();
            char[] line10 = "██░░░░░░░░░░██ ██░░██         ██░░░░░░░░░░░░██ ██░░██  ██░░░░░░██ ██░░░░░░░░░░██ ██░░░░░░░░░░██".ToCharArray();
            char[] line11 = "██████████████ ██████         ████████████████ ██████  ██████████ ██████████████ ██████████████".ToCharArray();
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line1.Length / 2), Console.WindowHeight / 2 - 6);
            Console.WriteLine(line1);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line2.Length / 2), Console.WindowHeight / 2 - 6 + 1);
            Console.WriteLine(line2);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line3.Length / 2), Console.WindowHeight / 2 - 6 + 2);
            Console.WriteLine(line3);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line4.Length / 2), Console.WindowHeight / 2 - 6 + 3);
            Console.WriteLine(line4);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line5.Length / 2), Console.WindowHeight / 2 - 6 + 4);
            Console.WriteLine(line5);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line6.Length / 2), Console.WindowHeight / 2 - 6 + 5);
            Console.WriteLine(line6);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line7.Length / 2), Console.WindowHeight / 2 - 6 + 6);
            Console.WriteLine(line7);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line8.Length / 2), Console.WindowHeight / 2 - 6 + 7);
            Console.WriteLine(line8);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line9.Length / 2), Console.WindowHeight / 2 - 6 + 8);
            Console.WriteLine(line9);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line10.Length / 2), Console.WindowHeight / 2 - 6 + 9);
            Console.WriteLine(line10);
            Console.SetCursorPosition(Console.WindowWidth / 2 - (line11.Length / 2), Console.WindowHeight / 2 - 6 + 10);
            Console.WriteLine(line11);
            Console.ForegroundColor = ConsoleColor.Blue;
            pos = Console.WindowWidth / 2 - (line1.Length / 2);
            foreach (char relleno in line2) {
                if (relleno.Equals('░')) {
                    Console.SetCursorPosition(pos, Console.WindowHeight / 2 - 6 + 1);
                    Thread.Sleep(35);
                    Console.Write("█");
                }
                pos++;
            }
            for (int i = 2; i < 5; i++) {
                pos = Console.WindowWidth / 2 - (line1.Length / 2);
                foreach (char relleno in line3) {
                    if (relleno.Equals('░')) {
                        Console.SetCursorPosition(pos, Console.WindowHeight / 2 - 6 + i);
                        Thread.Sleep(12);
                        Console.Write("█");
                    }
                    pos++;
                }
            }
            pos = Console.WindowWidth / 2 - (line1.Length / 2);
            foreach (char relleno in line6) {
                if (relleno.Equals('░')) {
                    Console.SetCursorPosition(pos, Console.WindowHeight / 2 - 6 + 5);
                    Thread.Sleep(15);
                    Console.Write("█");
                }
                pos++;
            }
            for (int i = 6; i < 9; i++) {
                pos = Console.WindowWidth / 2 - (line1.Length / 2);
                foreach (char relleno in line7) {
                    if (relleno.Equals('░')) {
                        Console.SetCursorPosition(pos, Console.WindowHeight / 2 - 6 + i);
                        Thread.Sleep(12);
                        Console.Write("█");
                    }
                    pos++;
                }
            }
            pos = Console.WindowWidth / 2 - (line1.Length / 2);
            foreach (char relleno in line10) {
                if (relleno.Equals('░')) {
                    Console.SetCursorPosition(pos, Console.WindowHeight / 2 - 6 + 9);
                    Thread.Sleep(20);
                    Console.Write("█");
                }
                pos++;
            }
            Thread.Sleep(600);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
