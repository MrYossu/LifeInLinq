using static Life.Game.GameHelpers;

namespace Life.Tests;

[TestClass]
public class GameHelpersTests {
  [TestMethod]
  public void GameHelpers_ToString() {
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
}