using System;

namespace Euler15
{
    class Program
    {
        static int ROWS = 20;
        static int COLS = 20;

        static ulong[,] pathCounts; //path length cache

        static void Main(string[] args)
        {
            pathCounts = new ulong[ROWS + 1, COLS + 1];
            Array.Clear(pathCounts, 0, (ROWS + 1) * (COLS + 1)); 
            ulong n = tryPath(1, 0) + tryPath(0, 1);
            Console.WriteLine(n);
            Console.ReadLine();
        }

        static ulong tryPath(int row, int col)
        {
            if (pathCounts[row, col] > 0)
                return pathCounts[row, col];

            if (row == ROWS && col == COLS)
                return 1;
            ulong count = 0;
            if (row == ROWS)
                count = tryPath(row, col + 1);
            else if (col == COLS)
                count = tryPath(row + 1, col);
            else count = tryPath(row + 1, col) + tryPath(row, col + 1);

            pathCounts[row, col] = count; //update cache

            return count;
        }
    }
}
