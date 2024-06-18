namespace Life.Game;

public static class GameHelpers {
  /// <summary>
  /// Converts a string representation of a board to the 2D bool array the code uses
  /// </summary>
  /// <param name="b">A string representation of the board, where a space represents a dead cell, and a non-space represents a live cell. The string is expected to contain Environment.NewLines at the end of each row</param>
  /// <returns>A 2D bool array representing the board</returns>
  public static bool[,] ToBoard(string b) =>
    b.Replace(Environment.NewLine, "")
      .Select(c => c != ' ')
      .ToArray()
      .To2D(4);

  public static int[,] InitialiseEmpty(int maxX, int maxY) =>
    new int[maxX, maxY];

  public static int[,] InitialiseRandom(int maxX, int maxY) {
    Random r = new();
    int[,] board = new int[maxX, maxY];
    for (int y = 0; y < maxY; y++) {
      for (int x = 0; x < maxX; x++) {
        board[x, y] = r.Next() % 100 < 15 ? 1 : 0;
      }
    }
    return board;
  }

  public static int[,] InitialiseGlider(int maxX, int maxY) {
    int[,] board = new int[maxX, maxY];
    // Initialise a glider
    board[3, 2] = 1;
    board[4, 3] = 1;
    board[2, 4] = 1;
    board[3, 4] = 1;
    board[4, 4] = 1;
    return board;
  }

  public static void Display(int[,] board, int maxX, int maxY) {
    Console.Clear();
    //Console.WriteLine(" |" + string.Join("", Enumerable.Range(0, maxX)) + "|");
    Console.WriteLine(new string('-', maxX + 3));
    for (int y = 0; y < maxY; y++) {
      //Console.Write($"{y}");
      Console.Write("|");
      for (int x = 0; x < maxX; x++) {
        Console.Write(board[x, y] == 1 ? "*" : "-");
      }
      Console.WriteLine("|");
    }
    Console.WriteLine(new string('¯', maxX + 2));
  }
}