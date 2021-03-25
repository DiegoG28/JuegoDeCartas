using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JuegoDeCartas {
    class Pantalla:Dibujos {

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
        }


    }
}
