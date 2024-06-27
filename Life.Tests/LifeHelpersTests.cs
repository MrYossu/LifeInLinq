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
  [DataRow(0, 0, 0)] // pos, x, y
  [DataRow(1, 0, 1)]
  [DataRow(2, 0, 2)]
  [DataRow(3, 1, 0)]
  [DataRow(4, 1, 1)]
  [DataRow(5, 1, 2)]
  public void LifeHelpers_PosToCoords2x3(int pos, int x, int y) {
    bool[,] board = new bool[2, 3];
    (int xRes, int yRes) = PosToCoords(board, pos);
    Assert.AreEqual(x, xRes, $"Expected pos: {pos} -> ({x}, {y}), but found ({xRes}, {yRes})");
    Assert.AreEqual(y, yRes, $"Expected pos: {pos} -> ({x}, {y}), but found ({xRes}, {yRes})");
  }

  [DataTestMethod]
  [DataRow(0, 0, 0)] // pos, x, y
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
    bool[,] board = new bool[6, 5];
    int xRes = PosToCoords(board, pos).x;
    int yRes = PosToCoords(board, pos).y;
    Assert.IsTrue(xRes == x && yRes == y, $"pos: {pos}: - expected ({x}, {y}), found ({xRes}, {yRes})");
  }

  #endregion

  #region Next

  // Test a few still lifes first
  [TestMethod]
  public void LifeHelpers_Next_Block() {
    bool[,] block =
      """
        ....
        .**.
        .**.
        ....
        """
        .ToBoard();
    Assert.AreEqual(block.ToBoardString(), Next(block).ToBoardString(),
      $"Expected:\n{block.ToBoardString()}\n\n...but found...\n\n{Next(block).ToBoardString()}");
  }

  [TestMethod]
  public void LifeHelpers_Next_Beehive() {
    string blockStr =
      """
      ......
      ..**..
      .*..*.
      ..**..
      ......
      """;
    bool[,] block = blockStr.ToBoard();
    string expected = block.ToBoardString();
    string actual = Next(block).ToBoardString();
    Console.WriteLine($"blockStr:\n{blockStr}");
    Assert.AreEqual(expected, actual, $"\n\nExpected:\n{expected}\n\n...but found:\n{actual}");
  }

  // TODO AYS - Write tests for other initial patterns. Use ToBoardString to check the results

  #endregion
}