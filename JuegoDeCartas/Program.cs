using System;
using System.Collections;
using System.IO;
using System.Text;

namespace JuegoDeCartas {
    class Program {
        static void Main(string[] args) {
            Console.SetWindowSize(150, 44);
            DisableConsoleQuickEdit.Go();
            bool infinite = true;
            bool RoundGreaterThanOne = false;
            while (infinite){
                Game.StartGame(RoundGreaterThanOne);
                RoundGreaterThanOne = true;
            }
        }
    }
}
