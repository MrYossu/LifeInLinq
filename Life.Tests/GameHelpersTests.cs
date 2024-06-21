using static Life.Game.GameHelpers;

namespace Life.Tests;

[TestClass]
public class GameHelpersTests {
  #region ToBoard

  [TestMethod]
  public void GameHelpers_ToBoard_Block() {
    string boardStr =
      """
      ....
      .**.
      .**.
      ....
      """;
    bool[,] board = boardStr.ToBoard();
    for (int col = 0; col < 4; col++) {
      for (int row = 0; row < 4; row++) {
        if (col is 1 or 2 && row is 1 or 2) {
          Assert.IsTrue(board[row, col], $"Expected ({row}, {col}) to be true, but wasn't");
        } else {
          Assert.IsFalse(board[row, col], $"Expected ({row}, {col}) to be false, but wasn't");
        }
      }
    }
  }

  [TestMethod]
  public void GameHelpers_ToBoard_Beehive() {
    string boardStr =
      """
      ......
      ..**..
      .*..*.
      ..**..
      ......
      """;
    bool[,] board = boardStr.ToBoard();
    //Console.WriteLine($"Break at {boardStr.Replace(Environment.NewLine, "").Length / boardStr.IndexOf(Environment.NewLine)}");
    //for (int col = 0; col < 5; col++) {
    //  for (int row = 0; row < 4; row++) {
    //    Console.Write(board[row, col]?'*':'.');
    //  }
    //  Console.WriteLine();
    //}


    for (int col = 0; col < 5; col++) {
      for (int row = 0; row < 4; row++) {
        if ((row == 1 && col == 2)
            || (row == 1 && col == 3)
            || (row == 2 && col == 1)
            || (row == 2 && col == 4)
            || (row == 3 && col == 2)
            || (row == 3 && col == 3)) {
          Assert.IsTrue(board[row, col], $"Expected ({row}, {col}) to be true, but wasn't");
        } else {
          Assert.IsFalse(board[row, col], $"Expected ({row}, {col}) to be false, but wasn't");
        }
      }
    }
  }

  [TestMethod]
  public void GameHelpers_ToBoard_Boat() {
    string boardStr =
      """
      .....
      .**..
      .*.*.
      ..*..
      .....
      """;
    bool[,] board = boardStr.ToBoard();
    for (int col = 0; col < 4; col++) {
      for (int row = 0; row < 4; row++) {
        if ((row == 1 && col == 1)
            || (row == 1 && col == 2)
            || (row == 2 && col == 1)
            || (row == 2 && col == 3)
            || (row == 3 && col == 2)) {
          Assert.IsTrue(board[row, col], $"Expected ({row}, {col}) to be true, but wasn't");
        } else {
          Assert.IsFalse(board[row, col], $"Expected ({row}, {col}) to be false, but wasn't");
        }
      }
    }
  }

  #endregion

  #region ToBoardString

  [TestMethod]
  public void GameHelpers_ToBoardString_Block() {
    string boardStr =
      """
      ....
      .**.
      .**.
      ....
      """;
    bool[,] board = boardStr.ToBoard();
    Assert.AreEqual(boardStr, board.ToBoardString(), $"Got:\n{board.ToBoardString()}\n");
  }

  [TestMethod]
  public void GameHelpers_ToBoardString_Beehive() {
    string boardStr =
      """
      ......
      ..**..
      .*..*.
      ..**..
      ......
      """;
    bool[,] board = boardStr.ToBoard();
    Assert.AreEqual(boardStr, board.ToBoardString(), $"Got:\n{board.ToBoardString()}\n");
  }

  #endregion
}