using Life.Game;
using static Life.Game.GameHelpers;
using static Life.Game.LifeHelpers;

namespace Life.Tests;

[TestClass]
public class LifeHelpersTests {
  #region Count

  [TestMethod]
  public void LifeHelpers_Count_AllEmpty() {
    int maxX = 5;
    int maxY = 5;
    bool[,] board = InitialiseEmpty(maxX, maxY);
    for (int x = 0; x < maxX; x++) {
      for (int y = 0; y < maxY; y++) {
        Assert.AreEqual(0, Count(board, x, y));
      }
    }
  }

  [DataTestMethod]
  [DataRow(0, 0, 3)] // x, y, expected
  [DataRow(0, 1, 3)]
  [DataRow(0, 2, 2)]
  [DataRow(0, 3, 0)]
  [DataRow(1, 0, 3)]
  [DataRow(1, 1, 3)]
  [DataRow(1, 2, 2)]
  [DataRow(1, 3, 0)]
  [DataRow(2, 0, 2)]
  [DataRow(2, 1, 2)]
  [DataRow(2, 2, 1)]
  [DataRow(2, 3, 0)]
  [DataRow(3, 0, 0)]
  [DataRow(3, 1, 0)]
  [DataRow(3, 2, 0)]
  [DataRow(3, 3, 0)]
  public void LifeHelpers_Count_4x4With2x2TopLeft(int x, int y, int expected) {
    bool[,] board =
      """
        **..
        **..
        ....
        ....
        """
        .ToBoard();
    Assert.AreEqual(expected, Count(board, x, y), $"Expected {expected} at ({x}, {y}), but found {Count(board, x, y)}");
  }

  [DataTestMethod]
  [DataRow(0, 0, 1)] // x, y, expected
  [DataRow(0, 1, 2)]
  [DataRow(0, 2, 2)]
  [DataRow(0, 3, 1)]
  [DataRow(1, 0, 2)]
  [DataRow(1, 1, 3)]
  [DataRow(1, 2, 3)]
  [DataRow(1, 3, 2)]
  [DataRow(2, 0, 2)]
  [DataRow(2, 1, 3)]
  [DataRow(2, 2, 3)]
  [DataRow(2, 3, 2)]
  [DataRow(3, 0, 1)]
  [DataRow(3, 1, 2)]
  [DataRow(3, 2, 2)]
  [DataRow(3, 3, 1)]
  public void LifeHelpers_Count_4x4With2x2InMiddle(int x, int y, int expected) {
    bool[,] board =
      """
        ....
        .**.
        .**.
        ....
        """
        .ToBoard();
    Assert.AreEqual(expected, Count(board, x, y), $"Expected {expected} at ({x}, {y}), but found {Count(board, x, y)}");
  }

  #endregion

  #region PosToCoords

  [DataTestMethod]
  [DataRow(0, 0, 0)] // pos, row, col
  [DataRow(1, 0, 1)]
  [DataRow(2, 0, 2)]
  [DataRow(3, 1, 0)]
  [DataRow(4, 1, 1)]
  [DataRow(5, 1, 2)]
  public void LifeHelpers_PosToCoords2x3(int pos, int row, int col) {
    bool[,] board = new bool[2, 3]; // 2 rows x 3 cols
    (int rowRes, int colRes) = PosToCoords(board, pos);
    Assert.AreEqual(row, rowRes, $"Expected pos: {pos} -> ({row}, {col}), but found ({rowRes}, {colRes})");
    Assert.AreEqual(col, colRes, $"Expected pos: {pos} -> ({row}, {col}), but found ({rowRes}, {colRes})");
  }

  [DataTestMethod]
  [DataRow(0, 0, 0)] // pos, row, col
  [DataRow(1, 0, 1)]
  [DataRow(2, 0, 2)]
  [DataRow(3, 0, 3)]
  [DataRow(4, 0, 4)]
  [DataRow(5, 0, 5)]
  [DataRow(6, 1, 0)]
  [DataRow(7, 1, 1)]
  [DataRow(8, 1, 2)]
  [DataRow(9, 1, 3)]
  [DataRow(10, 1, 4)]
  [DataRow(11, 1, 5)]
  [DataRow(12, 2, 0)]
  [DataRow(13, 2, 1)]
  [DataRow(14, 2, 2)]
  [DataRow(15, 2, 3)]
  [DataRow(16, 2, 4)]
  [DataRow(17, 2, 5)]
  [DataRow(18, 3, 0)]
  [DataRow(19, 3, 1)]
  [DataRow(20, 3, 2)]
  [DataRow(21, 3, 3)]
  [DataRow(22, 3, 4)]
  [DataRow(23, 3, 5)]
  [DataRow(24, 4, 0)]
  [DataRow(25, 4, 1)]
  [DataRow(26, 4, 2)]
  [DataRow(27, 4, 3)]
  [DataRow(28, 4, 4)]
  [DataRow(29, 4, 5)]
  public void LifeHelpers_PosToCoords5x4(int pos, int x, int y) {
    bool[,] board = new bool[5, 6];
    int xRes = PosToCoords(board, pos).row;
    int yRes = PosToCoords(board, pos).cols;
    Assert.IsTrue(xRes == x && yRes == y, $"pos: {pos}: - expected ({x}, {y}), found ({xRes}, {yRes})");
  }

  #endregion

  #region Next

  [DataTestMethod]
  [DataRow(LifeShapes.Block)]
  [DataRow(LifeShapes.BeeHive)]
  [DataRow(LifeShapes.Loaf)]
  [DataRow(LifeShapes.Boat)]
  [DataRow(LifeShapes.Tub)]
  public void LifeHelpers_Next_StillLifes(string blockStr) {
    bool[,] block = blockStr.ToBoard();
    string expected = block.ToBoardString();
    string actual = Next(block).ToBoardString();
    Assert.AreEqual(expected, actual, $"\n\nExpected:\n{expected}\n\n...but found:\n{actual}");
  }

  [DataTestMethod]
  [DataRow(LifeShapes.Blinker)]
  [DataRow(LifeShapes.Toad)]
  [DataRow(LifeShapes.Beacon)]
  public void LifeHelpers_Next_Oscillators(string blockStr) {
    // Test the period-2 oscillators by passing them through Next twice
    bool[,] block = blockStr.ToBoard();
    string expected = block.ToBoardString();
    string actual = Next(Next(block)).ToBoardString();
    Assert.AreEqual(expected, actual, $"\n\nExpected:\n{expected}\n\n...but found:\n{actual}");
  }

  #endregion
}