using System.Data;

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
        result[i, j] = source[i * dim2 + j];
      }
    }

    return result;
  }

  public static int Count(bool[,] board, int x, int y) =>
    new[] { -1, 0, 1, -1, 1, -1, 0, 1 }.Zip(new[] { 1, 1, 1, 0, 0, -1, -1, -1 })
      .Sum(o => (x + o.First >= 0) && (x + o.First < board.GetLength(0)) && (y + o.Second >= 0) &&
                (y + o.Second < board.GetLength(1) && board[x + o.First, y + o.Second])
        ? 1
        : 0);

  // The standard Life rules are known as B3/S23, meaning that a cell is born if it has 3 live neighbours and survives if it has 2 or 3.
  // The code below was written to allow us to use different rules. At the moment the two rules are hard-coded in the born and survives arrays,
  // but if allow these to be passed in, we can use any rules we like. Even better, if we implement a helper method that takes a string
  // such as B3/S23 and parses it into two int arrays, then we can pass in the rules as a string.
  public static bool[,] Next(this bool[,] board) =>
    board.Cast<bool>().ToArray()
      .Select((cell, pos) => {
        (int row, int col) = PosToCoords(board, pos);
        int count = Count(board, row, col);
        // General logic that can handle any Life rules. Eventually we will pass these in as parameters, derived from a string, eg B3/S23
        int[] born = [3]; // Any dead cell with this number of live neighbours becomes alive in the next generation
        int[] survives = [2, 3]; // Any live cell with this number of live neighbours is alive in the next generation
        return cell switch {
          true when survives.Contains(count) => true,
          false when born.Contains(count) => true,
          _ => false
        };
      })
      .ToArray()
      .To2D(board.GetLength(0));

  public static bool[,] NextSelect(this bool[,] board) =>
    NextSelect(board, [3], [2, 3]);

  public static bool[,] NextSelect(this bool[,] board, int[] born, int[] survives) =>
    board.Cast<bool>().ToArray()
      .Select((cell, pos) => new { cell, coord = PosToCoords(board, pos) })
      .Select(data => new { data.cell, data.coord.row, data.coord.col })
      .Select(data => new { data.cell, data.row, data.col, count = Count(board, data.row, data.col) })
      .Select(data => data.cell switch {
        true when survives.Contains(data.count) => true,
        false when born.Contains(data.count) => true,
        _ => false
      })
      .ToArray()
      .To2D(board.GetLength(0));


  // [2,3] is 2 rows x 3 cols
  // board.GetLength(0) is rows
  // board.GetLength(1) is cols
  public static (int row, int col) PosToCoords(bool[,] board, int pos) =>
    (pos / board.GetLength(1), pos % board.GetLength(1));
}