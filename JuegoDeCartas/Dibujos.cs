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

        private string[] towerdes =
       {
            "████████ ████████ ██  ██  ██ ████████ ████████   ██████   ████████ █████████ ████████ ████████ ██    ██ ████████ ████████ ████████ ████████ ███    ██",
            "   ██    ██    ██ ██  ██  ██ ██       ██    ██   ██    ██ ██       ██           ██    ██    ██ ██    ██ ██          ██       ██    ██    ██ ██ █   ██",
            "   ██    ██    ██ ██  ██  ██ █████    ████████   ██    ██ █████    █████████    ██    ████████ ██    ██ ██          ██       ██    ██    ██ ██  █  ██",
            "   ██    ██    ██ ██  ██  ██ ██       ██   ██    ██    ██ ██              ██    ██    ██   ██  ██    ██ ██          ██       ██    ██    ██ ██   █ ██",
            "   ██    ████████ ██████████ ████████ ██    ██   ██████   ████████ █████████    ██    ██    ██ ████████ ████████    ██    ████████ ████████ ██    ███",
        };

        private string[] torrecitaff = {
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "        █     ",
                "      ░░█  █░█",
                "      ░░██ ░░█",
                "   ░░ ░░░░░░░█",
                "  ░░░░░░░░░░░█",
                " ░░░░░██░░░░░█",
                "█░░░░█░░█░░░░█",
                "█░░░█░░░░█░░░█",
                "█░░░█░░░░█░░░█",
                " █░░█░░░░█░░█ ",
                "  █░█░░░░█░█  ",
                "   ████████   ",
        };

        private string[] start =
       {
            "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░",
            "░░                                                ░░",
            "░░  ████████ ████████ ████████ ████████ ████████  ░░",
            "░░  ██          ██    ██    ██ ██    ██    ██     ░░",
            "░░  ████████    ██    ████████ ████████    ██     ░░",
            "░░        ██    ██    ██    ██ ██   ██     ██     ░░",
            "░░  ████████    ██    ██    ██ ██    ██    ██     ░░",
            "░░                                                ░░",
            "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░",
        };
        private string[] exit =
       {
            "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░",
            "░░                                                ░░",
            "░░      ████████ ██      ██ ████████ ████████     ░░",
            "░░      ██         ██  ██      ██       ██        ░░",
            "░░      ██████       ██        ██       ██        ░░",
            "░░      ██         ██  ██      ██       ██        ░░",
            "░░      ████████ ██      ██ ████████    ██        ░░",
            "░░                                                ░░",
            "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░",
        };
        private string[] startt =
        {
            "████████ ████████ ████████ ████████ ████████",
            "██          ██    ██    ██ ██    ██    ██",
            "████████    ██    ████████ ████████    ██",
            "      ██    ██    ██    ██ ██   ██     ██",
            "████████    ██    ██    ██ ██    ██    ██",
        };
        private string[] exitt =
        {
            "████████ ██      ██ ████████ ████████",
            "██         ██  ██      ██       ██",
            "██████       ██        ██       ██",
            "██         ██  ██      ██       ██",
            "████████ ██      ██ ████████    ██",
        };
        private string[] won =
        {
            "██    ██ ████████ ██    ██        ██  ██  ██ ████████ ███    ██",
            " ██  ██  ██    ██ ██    ██        ██  ██  ██ ██    ██ ██ █   ██",
            "  ████   ██    ██ ██    ██        ██  ██  ██ ██    ██ ██  █  ██",
            "   ██    ██    ██ ██    ██        ██  ██  ██ ██    ██ ██   █ ██",
            "   ██    ████████ ████████        ██████████ ████████ ██    ███",
        };
        private string[] lost =
        {
            "██    ██ ████████ ██    ██        ██       ████████ ████████ ████████",
            " ██  ██  ██    ██ ██    ██        ██       ██    ██ ██          ██   ",
            "  ████   ██    ██ ██    ██        ██       ██    ██ ████████    ██   ",
            "   ██    ██    ██ ██    ██        ██       ██    ██       ██    ██   ",
            "   ██    ████████ ████████        ████████ ████████ ████████    ██   ",
        };

        private string[] continuar =
        {
            "╔═══════════════════════════════╗",
            "║   _   _      __            _  ║",
            "║  / ` / / /|/ /  / /|/ / / /_` ║",
            "║ /_, /_/ / | /  / / | /_/ /_   ║",
            "╚═══════════════════════════════╝"
        };
        public string[] Torrecita { get => torrecita; set => torrecita = value; }
        public string[] Torrecitaff { get => torrecitaff; set => torrecitaff = value; }
        public string[] Towerdes { get => towerdes; set => towerdes = value; }
        public string[] Start { get => start; set => start = value; }
        public string[] Exit { get => exit; set => exit = value; }
        public string[] Startt { get => startt; set => startt = value; }
        public string[] Exitt { get => exitt; set => exitt = value; }
        public string[] Won { get => won; set => won = value; }
        public string[] Lost { get => lost; set => lost = value; }

        public static string[,] numbers = new string[3, 10];
        public string[] Vss { get => vss; set => vss = value; }
        public string[] Continuar { get => continuar; set => continuar = value; }

        public void DrawNumbers() {

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
