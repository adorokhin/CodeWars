using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tests
{
    [TestClass()]
    public class SudokuTests
    {
        class TestCase
        {
           public bool Expected;
           public int[][] Board;
        }
        private TestCase[] testCases = new TestCase[]
        {
                new TestCase{
                    Expected = true,
                    Board = new int[][]{
                      new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                      new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                      new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                      new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                      new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                      new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                      new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                      new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                      new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9}
                    }
                },
                new TestCase{
                    Expected = false,
                    Board = new int[][]
                    {
                      new int[]{5, 3, 4, 6, 7, 8, 9, 1, 2},
                      new int[]{6, 7, 2, 1, 9, 5, 3, 4, 8},
                      new int[]{1, 9, 8, 3, 0, 2, 5, 6, 7},
                      new int[]{8, 5, 0, 7, 6, 1, 4, 2, 3},
                      new int[]{4, 2, 6, 8, 5, 3, 7, 9, 1},
                      new int[]{7, 0, 3, 9, 2, 4, 8, 5, 6},
                      new int[]{9, 6, 1, 5, 3, 7, 2, 8, 4},
                      new int[]{2, 8, 7, 4, 1, 9, 6, 3, 5},
                      new int[]{3, 0, 0, 2, 8, 6, 1, 7, 9}
                    }
                }
            };


        [TestMethod()]
        public void GetTilesTest()
        {
            var board = new int[][]{
                new int[] {5, 3, 4,  6, 7, 8,  9, 1, 2},
                new int[] {6, 7, 2,  1, 9, 5,  3, 4, 8},
                new int[] {1, 9, 8,  3, 4, 2,  5, 6, 7},

                new int[] {8, 5, 9,  7, 6, 1,  4, 2, 3},
                new int[] {4, 2, 6,  8, 5, 3,  7, 9, 1},
                new int[] {7, 1, 3,  9, 2, 4,  8, 5, 6},

                new int[] {9, 6, 1,  5, 3, 7,  2, 8, 4},
                new int[] {2, 8, 7,  4, 1, 9,  6, 3, 5},
                new int[] {3, 4, 5,  2, 8, 6,  1, 7, 9}
            };

            var expected = new int[][]{
                new int[] {5, 3, 4, 6, 7, 2, 1, 9, 8},
                new int[] {6, 7, 8, 1, 9, 5, 3, 4, 2},
                new int[] {9, 1, 2, 3, 4, 8, 5, 6, 7},
                new int[] {8, 5, 9, 4, 2, 6, 7, 1, 3},
                new int[] {7, 6, 1, 8, 5, 3, 9, 2, 4},
                new int[] {4, 2, 3, 7, 9, 1, 8, 5, 6},
                new int[] {9, 6, 1, 2, 8, 7, 3, 4, 5},
                new int[] {5, 3, 7, 4, 1, 9, 2, 8, 6},
                new int[] {2, 8, 4, 6, 3, 5, 1, 7, 9}
            };

            var tiles = Sudoku.GetTiles(board);
            Sudoku.PrintBoard(board);
            Sudoku.PrintBoard(tiles);

            for (int i = 0; i < 9;  i++)
            {
                CollectionAssert.AreEquivalent(tiles[i], expected[i]);
            }

        }

        [TestMethod()]
        public void Sudoku_ValidateSolutionTest()
        {
            testCases.ToList().ForEach(_ => Assert.AreEqual(_.Expected, Sudoku.ValidateSolution(_.Board)));
        }

    }
}