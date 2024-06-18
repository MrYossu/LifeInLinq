namespace Life.Game;

public static class LifeHelpers {
  /// <summary>
  /// Converts a 1D array to a 2D array
  /// </summary>
  /// <typeparam name="T">The type of the array values</typeparam>
  /// <param name="source">The 1D array</param>
  /// <param name="dim">The first dimension of the 2D array</param>
  /// <returns>A 2D array containing the values in the 1D array, split according to dim. To use this on a 1D array, you need to call .Cast<T>().ToArray() first</returns>
  // To use this in Life, the Next method would take the board, call .Cast<T>().ToArray() to get a 1S array, then generate a 1D representation of the next generation, then call To2D to convert it to a 2D array
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

  public static int[,] Next(int[,] board, (int X, int Y)[] offsets, int maxX, int maxY) {
    int[,] next = new int[maxX, maxY];
    for (int y = 0; y < maxY; y++) {
      for (int x = 0; x < maxX; x++) {
        int count = Count(board, offsets, x, y, maxX, maxY);
        next[x, y] = count is 3 or 4 ? 1 : 0;
      }
    }
    return next;
  }

  // Get the number of live neighbours. If this is 3 or 4, then (x, y) is alive in the next generation
  // TODO AYS - offsets is only used here, and is always the same fixed 8-element array, so just hard code it at the beginning of the line and remove it from the rest of the code
  public static int Count(int[,] board, (int X, int Y)[] offsets, int x, int y, int maxX, int maxY) =>
    offsets.Sum(o => board[P(x, o.X, maxX), P(y, o.Y, maxY)]);

  public static int P(int n, int offset, int max) =>
    offset switch {
      -1 when n == 0 => max - 1,
      1 when n == max - 1 => 0,
      _ => n + offset
    };
}