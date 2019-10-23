using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {

        public static int[][] testboard = new int[][]{
                      new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                      new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                      new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                      new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                      new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                      new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                      new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                      new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                      new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9}
                    };

        //----------------- x  y    x - 0,1,2   y = 
        /*
        tiles[0][0] = board[0][0];      tiles[1][0] = board[0][3];      tiles[2][0] = board[0][6];
        tiles[0][1] = board[0][1];      tiles[1][1] = board[0][4];      tiles[2][1] = board[0][7];
        tiles[0][2] = board[0][2];      tiles[1][2] = board[0][5];      tiles[2][2] = board[0][8];
        tiles[0][3] = board[1][0];      tiles[1][3] = board[1][3];      tiles[2][3] = board[1][6];
        tiles[0][4] = board[1][1];      tiles[1][4] = board[1][4];      tiles[2][4] = board[1][7];
        tiles[0][5] = board[1][2];      tiles[1][5] = board[1][5];      tiles[2][5] = board[1][8];
        tiles[0][6] = board[2][0];      tiles[1][6] = board[2][3];      tiles[2][6] = board[2][6];
        tiles[0][7] = board[2][1];      tiles[1][7] = board[2][4];      tiles[2][7] = board[2][7];
        tiles[0][8] = board[2][2];      tiles[1][8] = board[2][5];      tiles[2][8] = board[2][8];
        //--------------------------    ----------------------------    --------------------------
        //----------------- x  y x - (0,1,2) + 3
        tiles[3][0] = board[3][0];      tiles[4][0] = board[3][3];      tiles[5][0] = board[3][6];
        tiles[3][1] = board[3][1];      tiles[4][1] = board[3][4];      tiles[5][1] = board[3][7];
        tiles[3][2] = board[3][2];      tiles[4][2] = board[3][5];      tiles[5][2] = board[3][8];
        tiles[3][3] = board[4][0];      tiles[4][3] = board[4][3];      tiles[5][3] = board[4][6];
        tiles[3][4] = board[4][1];      tiles[4][4] = board[4][4];      tiles[5][4] = board[4][7];
        tiles[3][5] = board[4][2];      tiles[4][5] = board[4][5];      tiles[5][5] = board[4][8];
        tiles[3][6] = board[5][0];      tiles[4][6] = board[5][3];      tiles[5][6] = board[5][6];
        tiles[3][7] = board[5][1];      tiles[4][7] = board[5][4];      tiles[5][7] = board[5][7];
        tiles[3][8] = board[5][2];      tiles[4][8] = board[5][5];      tiles[5][8] = board[5][8];
        //--------------------------    ----------------------------    --------------------------
        //----------------- x  y x - (0,1,2) + 6
        tiles[6][0] = board[6][0];      tiles[7][0] = board[6][3];      tiles[8][0] = board[6][6];
        tiles[6][1] = board[6][1];      tiles[7][1] = board[6][4];      tiles[8][1] = board[6][7];
        tiles[6][2] = board[6][2];      tiles[7][2] = board[6][5];      tiles[8][2] = board[6][8];
        tiles[6][3] = board[7][0];      tiles[7][3] = board[7][3];      tiles[8][3] = board[7][6];
        tiles[6][4] = board[7][1];      tiles[7][4] = board[7][4];      tiles[8][4] = board[7][7];
        tiles[6][5] = board[7][2];      tiles[7][5] = board[7][5];      tiles[8][5] = board[7][8];
        tiles[6][6] = board[8][0];      tiles[7][6] = board[8][3];      tiles[8][6] = board[8][6];
        tiles[6][7] = board[8][1];      tiles[7][7] = board[8][4];      tiles[8][7] = board[8][7];
        tiles[6][8] = board[8][2];      tiles[7][8] = board[8][5];      tiles[8][8] = board[8][8];
        */



        static void Main(string[] args)
        {
            int[][] board = Sudoku.GetEmptyBoard();
            int[][] tiles = Sudoku.GetEmptyBoard();

            tiles = Sudoku.GetTiles(testboard);
            Sudoku.PrintBoard(board);
            Sudoku.PrintBoard(tiles);
        }
    }
}
