using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;

namespace JuegoDeCartas {
    class Program {
        static void Main(string[] args) {
            Console.SetWindowSize(150, 44);
            Console.SetBufferSize(150, 44);
            Game.StartGame();
        }
    }
}
