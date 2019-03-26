using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semPAW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primul program C#!");

            Console.WriteLine("Introdu numele: ");
            string nume;
            nume = Console.ReadLine();
            Console.WriteLine("Numele tau este {0}", nume);

            int[] vector = {5, 6, 7, 8, 9};
            for (int i = 0; i < vector.Length; i++)
                Console.WriteLine(vector[i]);

            vector = new int[3];
            for (int i = 0; i < vector.Length; i++)
                Console.WriteLine(vector[i]);

            vector = new int[4] { 1, 2, 3, 4 };
            for (int i = 0; i < vector.Length; i++)
                Console.WriteLine(vector[i]);

            int[,] matrice = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            for (int i = 0; i < matrice.GetLength(0); i++)
                for (int j = 0; j < matrice.GetLength(1); j++)
                    Console.WriteLine(matrice[i,j]);

            matrice = new int[3, 2];
            for (int i = 0; i < matrice.GetLength(0); i++)
                for (int j = 0; j < matrice.GetLength(1); j++)
                    Console.WriteLine(matrice[i, j]);
            
            Console.WriteLine("---------------");
            int[][] matr = new int[3][];
            for (int i = 0; i < matr.Length; i++)
            {
                matr[i] = new int[2];
                for (int j = 0; j < matr[i].Length; j++)
                    Console.WriteLine(matr[i][j]);
            }

            int[] vector2 = vector;

            int[] vector3 = new int[vector.Length];
            for (int i = 0; i < vector.Length; i++)
                vector3[i] = vector[i];

            vector[0] = 100;
            for (int i = 0; i < vector2.Length; i++)
                Console.WriteLine(vector2[i]);

            for (int i = 0; i < vector3.Length; i++)
                Console.WriteLine(vector3[i]);
        }
    }
}
