namespace Life.Game;

public static class LifeHelpers {
  /// <summary>
  /// Converts a 1D array to a 2D array
  /// </summary>
  /// <typeparam name="T">The type of the array values</typeparam>
  /// <param name="source">The 1D array</param>
  /// <param name="dim">The first dimension of the 2D array</param>
  /// <returns>A 2D array containing the values in the 1D array, split according to dim. To use this on a 1D array, you need to call .Cast<T>().ToArray() first</returns>
  // To use this in Life, the Next method would take the board, call .Cast<T>().ToArray() to get a 1D array, then generate a 1D representation of the next generation, then call To2D to convert it to a 2D array
  public static T[,] To2D<T>(this T[] source, int dim) {
    int dim2 = source.Length / dim;
    T[,] result = new T[dim, dim2];
    for (int i = 0; i < dim; i++) {
      for (int j = 0; j < dim2; j++) {
        result[i, j] = source[i * dim + j];
      }
    }
    return result;
  }

  public static int Count(bool[,] board, int x, int y) =>
    new[] { -1, 0, 1, -1, 1, -1, 0, 1 }.Zip(new[] { 1, 1, 1, 0, 0, -1, -1, -1 })
      .Sum(o => (x + o.First >= 0) && (x + o.First < board.GetLength(0)) && (y + o.Second >= 0) && (y + o.Second < board.GetLength(1) && board[x + o.First, y + o.Second]) ? 1 : 0);

  /*
  // TODO AYS - This doesn't need to take the max values as we can get the number of rows from board.GetLength(0) and the number of columns from board.GetLength(1)
  public static int[,] Next(int[,] board, int maxX, int maxY) {
    int[,] next = new int[maxX, maxY];
    for (int y = 0; y < maxY; y++) {
      for (int x = 0; x < maxX; x++) {
        int count = Count(board, x, y, maxX, maxY);
        next[x, y] = count is 3 or 4 ? 1 : 0;
      }
    }
    return next;
  }
*/
}