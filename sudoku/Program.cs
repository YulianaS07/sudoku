using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int[,] siatkaSudoku = new int[9, 9];

        for (int i = 0; i < 9; i++)
        {
            string[] wiersz = Console.ReadLine().Split(" ");
            for (int j = 0; j < 9; j++)
            {
                siatkaSudoku[i, j] = int.Parse(wiersz[j]);
            }
        }

        if (RozwiazanieSudoku(siatkaSudoku))
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }

    static bool RozwiazanieSudoku(int[,] siatka)
    {
        for (int i = 0; i < 9; i++)
        {
            if (!UnikalWTab(Wiersz(siatka, i)) || !UnikalWTab(Kolumna(siatka, i)))
            {
                return false;
            }
        }

        for (int i = 0; i < 9; i += 3)
        {
            for (int j = 0; j < 9; j += 3)
            {
                if (!UnikalWTab(Kwadrat(siatka, i, j)))
                {
                    return false;
                }
            }
        }

        return true;
    }

    static int[] Wiersz(int[,] siatka, int wiersz)
    {
        int[] wynik = new int[9];
        for (int i = 0; i < 9; i++)
        {
            wynik[i] = siatka[wiersz, i];
        }
        return wynik;
    }

    static int[] Kolumna(int[,] siatka, int kolumna)
    {
        int[] wynik = new int[9];
        for (int i = 0; i < 9; i++)
        {
            wynik[i] = siatka[i, kolumna];
        }
        return wynik;
    }

    static int[] Kwadrat(int[,] siatka, int poczWiersz, int poczKol)
    {
        int[] wynik = new int[9];
        int indeks = 0;
        for (int i = poczWiersz; i < poczWiersz + 3; i++)
        {
            for (int j = poczKol; j < poczKol + 3; j++)
            {
                wynik[indeks++] = siatka[i, j];
            }
        }
        return wynik;
    }

    static bool UnikalWTab(int[] tab)
    {
        HashSet<int> zb = new HashSet<int>();
        foreach (var nr in tab)
        {
            if (nr < 1 || nr > 9 || !zb.Add(nr))
            {
                return false;
            }
        }
        return true;
    }
}
