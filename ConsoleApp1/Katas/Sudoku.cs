using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{

    /*
    public class Sudoku
    {
    public static bool ValidateSolution(int[][] board)
    {
    return Enumerable
      .Range(0, 9)
      .SelectMany(i => new[]
      {
          board[i].Sum(),
          board.Sum(b => b[i]),
          board.Skip(3 * (i / 3)).Take(3).SelectMany(r => r.Skip(3 * (i % 3)).Take(3)).Sum()
      })
      .All(i => i == 45);
  }
}
         */

    public class Sudoku
    {
        readonly static int[] validRow = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static int[][] GetEmptyBoard()
        {
            var empty = new int[9][];
            for (int i = 0; i < 9; i++)
                empty[i] = new int[9];
            return empty;
        }

        public static bool ValidateSolution(int[][] _board)
        {
            var board = _board;

            if (!ValidateRows(board))
                return false;
            if (!ValidateColumns(board))
                return false;
            if (!ValidateTiles(board))
                return false;

            return true;
        }

        private static bool ValidateRows(int[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (false == ValidateRowCol(board[i]))
                    return false;
            }
            return true;
        }

        private static bool ValidateColumns(int[][] board)
        {
            return ValidateRows(FlipRight90Degrees(board));
        }

        private static bool ValidateTiles(int[][] board)
        {
            return ValidateRows(GetTiles(board));
        }


        private static int[][] FlipRight90Degrees(int[][] board)
        {
            int[][] flipped = GetEmptyBoard();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 8; j >= 0; j--)
                {
                    flipped[i][8 - j] = board[j][i];
                }
            }
            return flipped;
        }

        public static int[][] GetTiles(int[][] board)
        {
            int[][] tiles = Sudoku.GetEmptyBoard();
            int x = 0, y = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    x = i + (j / 3) - (i % 3);
                    if (i % 3 == 0)
                        y = j % 3;
                    else if (i % 3 == 1)
                        y = j % 3 + 3;
                    else if (i % 3 == 2)
                        y = j % 3 + 6;
                    tiles[i][j] = board[x][y];
                }
            }
            return tiles;
        }

        bool ValidateColumn(int[] row)
        {
            int[] _row = (int[])row.Clone();
            Array.Sort(_row.ToArray());
            if (!Enumerable.SequenceEqual(_row, validRow))
                return false;
            return true;
        }

        private static bool ValidateRowCol(int[] row_col)
        {
            int[] _row_col = (int[])row_col.Clone();
            Array.Sort(_row_col);
            if (!Enumerable.SequenceEqual(_row_col, validRow))
                return false;
            return true;
        }

        public static void PrintBoard(int[][] board)
        {
            Debug.WriteLine("---- BOARD   ----");
            foreach (var row in board)
                Debug.WriteLine(string.Join(",", row));
            Debug.WriteLine("");
        }

    }
}