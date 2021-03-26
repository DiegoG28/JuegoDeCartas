using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace JuegoDeCartas {
    class Pantalla : Dibujos {

        public void ShowFirstScreen() {
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
                Console.SetCursorPosition(60, 25);
                Console.Write("Repartiendo cartas."); Thread.Sleep(1000);
                Console.Write("."); Thread.Sleep(500);
                Console.Write("."); Thread.Sleep(500);
                Console.SetCursorPosition(78, 25);
                Console.WriteLine("   ");

            }
        }

        public void InGame() {
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

            SaveNumbers();//Guardamos dibujos de los números que usaremos a continuación
            Console.ForegroundColor = ConsoleColor.Red;
            PrintPlayerHP(Jugador.playerHP / 1000 % 10, Jugador.playerHP / 100 % 10, Jugador.playerHP / 10 % 10, Jugador.playerHP % 10);
            PrintBotHP(Jugador.botHP / 1000 % 10, Jugador.botHP / 100 % 10, Jugador.botHP / 10 % 10, Jugador.botHP % 10);
            Console.ForegroundColor = ConsoleColor.White;
        }

           void PrintPlayerHP(int d1, int d2, int d3, int d4) {
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
        }

        void PrintBotHP(int d1, int d2, int d3, int d4) {
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
            Console.WriteLine(line1);
            Console.WriteLine(line2);
            Console.WriteLine(line3);
            Console.WriteLine(line4);
            Console.WriteLine(line5);
            Console.WriteLine(line6);
            Console.WriteLine(line7);
            Console.WriteLine(line8);
            Console.WriteLine(line9);
            Console.WriteLine(line10);
            Console.WriteLine(line11);
            Console.ForegroundColor = ConsoleColor.Blue;
            pos = 0;
            foreach (char relleno in line2) {
                if (relleno.Equals('░')) {
                    Console.SetCursorPosition(pos, 1);
                    Thread.Sleep(35);
                    Console.Write("█");
                }
                pos++;
            }
            for (int i = 2; i < 5; i++) {
                pos = 0;
                foreach (char relleno in line3) {
                    if (relleno.Equals('░')) {
                        Console.SetCursorPosition(pos, i);
                        Thread.Sleep(12);
                        Console.Write("█");
                    }
                    pos++;
                }
            }
            pos = 0;
            foreach (char relleno in line6) {
                if (relleno.Equals('░')) {
                    Console.SetCursorPosition(pos, 5);
                    Thread.Sleep(15);
                    Console.Write("█");
                }
                pos++;
            }
            for (int i = 6; i < 9; i++) {
                pos = 0;
                foreach (char relleno in line7) {
                    if (relleno.Equals('░')) {
                        Console.SetCursorPosition(pos, i);
                        Thread.Sleep(12);
                        Console.Write("█");
                    }
                    pos++;
                }
            }
            pos = 0;
            foreach (char relleno in line10) {
                if (relleno.Equals('░')) {
                    Console.SetCursorPosition(pos, 9);
                    Thread.Sleep(20);
                    Console.Write("█");
                }
                pos++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
