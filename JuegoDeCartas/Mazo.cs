using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace JuegoDeCartas {
    class Mazo {
        public static ArrayList shuffledDeck = new ArrayList();
        public static int totalCards = 20;
        public static string[,] deck = new string[20, totalCards];

        public void ReadCards() {
            for (int i = 0; i < totalCards; i++) {
                //Los archivos tienen como nombre número, por lo tanto se puede ir leyendo fácilmente cada uno de ellos
                StreamReader archivo = new StreamReader("..\\..\\..\\Cartas\\" + i + ".txt");
                ArrayList cardData = new ArrayList();
                string line = "";

                while (line != null) {
                    //Lee un renglón del archivo y enseguida hace un salto de línea, por lo que en la siguiente iteración leerá el siguiente renglón
                    line = archivo.ReadLine();
                    if (line != null) {
                        //Si el renglón NO está en blanco, va guardando los atributos o datos de las deck.
                        cardData.Add(line);
                    }
                }
                archivo.Close();
                BuildDeck(cardData, i); //Cuando se termina el proceso de leer UN SOLO txt y guardar los datos en un arraylist, se asignan esos datos a deck.
            }
        }

        void BuildDeck(ArrayList data, int i) {
            int row = 0;
            //Agrega los atributos guardados de las deck en un arreglo bidimensional.
            foreach (string atributo in data) {
                deck[row, i] = atributo;
                row++;
            }
        }

        public void ShuffleCards() {
            Random generate = new Random();

            int idRandom;
            for (int i = 0; i < totalCards; i++) {
                idRandom = generate.Next(0, totalCards);
                //Mientras shuffledDeck contenga el valor de idRandom, generará uno nuevo hasta que ese nuevo valor no esté dentro de shuffledDeck, así nos aseguramos que no hayan repetidos.
                while (shuffledDeck.Contains(idRandom)) {
                    idRandom = generate.Next(0, totalCards);
                }
                shuffledDeck.Add(idRandom);
            }
        }
    }
}
