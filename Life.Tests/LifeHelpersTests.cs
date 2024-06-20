using static Life.Game.GameHelpers;
using static Life.Game.LifeHelpers;

namespace Life.Tests;

[TestClass]
public class LifeHelpersTests {
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

  [DataTestMethod]
  [DataRow(0, 0, 0)] // pos, x, y
  [DataRow(1, 0, 1)]
  [DataRow(2, 0, 2)]
  [DataRow(3, 1, 0)]
  [DataRow(4, 1, 1)]
  [DataRow(5, 1, 2)]
  public void LifeHelpers_PosToCoords(int pos, int x, int y) {
    bool[,] board = new bool[2, 3];
    Assert.AreEqual(x, PosToCoords(board, pos).x);
    Assert.AreEqual(y, PosToCoords(board, pos).y);
  }

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
    Assert.AreEqual(block, Next(block));
  }

  // TODO AYS - Write tests for other initial patterns. Use ToBoardString to check the results
}