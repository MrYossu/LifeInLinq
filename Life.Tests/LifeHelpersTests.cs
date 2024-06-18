using static Life.Game.GameHelpers;
using static Life.Game.LifeHelpers;

namespace Life.Tests;

[TestClass]
public class LifeHelpersTests {
  [TestMethod]
  public void LifeHelpers_Count_AllEmpty() {
    (int X, int Y)[] offsets = [(-1, 1), (0, 1), (1, 1), (-1, 0), (1, 0), (-1, -1), (0, -1), (1, -1)];
    int maxX = 5;
    int maxY = 5;
    int[,] board = InitialiseEmpty(maxX, maxY);
    for (int x = 0; x < maxX; x++) {
      for (int y = 0; y < maxY; y++) {
        Assert.AreEqual(0, Count(board, offsets, x, y, maxX, maxY));
      }
    }
  }
}