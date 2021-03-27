using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JuegoDeCartas {
    class Dibujos {
        private string[] torrecita = {
                "  ██ ████ ██ ",
                "  ██ ████ ██ ",
                " █░█ █░░█ █░█ ",
                "█░░███░░███░░█",
                "████▓▓▓▓▓▓████",
                "█░█▓▓▓▓▓▓▓▓█░█",
                "█░░█▓▓░░▓▓█░░█",
                "█░░███░░███░░█",
                "█░░░░░░░░░░░░█",
                "██░░░░░░░░░░██",
                "███░░░░░░░░███",
                "███░██░░██░███",
                "█░█░██░░██░█░█",
                "█░░░██░░██░░░█",
                "█░░░░░░░░░░░░█",
                "█░░░░░░░░░░░░█",
                "█░░░░░██░░░░░█",
                "█░░░░█░░█░░░░█",
                "█░░░█░░░░█░░░█",
                "█░░░█░░░░█░░░█",
                " █░░█░░░░█░░█",
                "  █░█░░░░█░█",
                "   ████████"};

        private string[] vss = {
            "  ██              ██        ████████       ",
            "   ██            ██        ██      ██      ",
            "    ██          ██        ██                ",
            "     ██        ██          ███                ",
            "      ██      ██             ██████             ",
            "       ██    ██                   ███       ",
            "        ██  ██                      ██        ",
            "         ████               ██     ██       ",
            "          ██                 ███████       "
        };

        public static string[,] numbers = new string[3, 10];
        public string[] Torrecita { get => torrecita; set => torrecita = value; }
        public string[] Vss { get => vss; set => vss = value; }

        public void SaveNumbers() {

            StreamReader archivo = new StreamReader("..\\..\\..\\num.txt");
            string line = "";
            int column = 0;
            int row = 0;
            while (line != null) {
                line = archivo.ReadLine();
                if (line != null) {
                    if (row == 3) {//Los números tienen 3 de alto, así que cuando row sea 3 signifca que ya se leyó un número, por lo tanto reiniciaremos row y el próximo número estará en la otra columna
                        row = 0;
                        column++;
                        numbers[row, column] = line;
                        row++;
                    } else {
                        numbers[row, column] = line;
                        row++;
                    }
                }
            }
            archivo.Close();
        }
    }
}
