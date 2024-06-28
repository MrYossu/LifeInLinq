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
      .Sum(o => (x + o.First >= 0) && (x + o.First < board.GetLength(0)) && (y + o.Second >= 0) && (y + o.Second < board.GetLength(1) && board[x + o.First, y + o.Second]) ? 1 : 0);

  /*
    At each step in time, the following transitions occur:
        Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        Any live cell with two or three live neighbours lives on to the next generation.
        Any live cell with more than three live neighbours dies, as if by overpopulation.
        Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

    As a table...
      live	count	result
        t    1      f
        t    2      t
        t    3      t
        t    4      f
        t    5      f
        t    6      f
        t    7      f
        t    8      f
        f    1      f
        f    2      f
        f    3      t
        f    4      f
        f    5      f
        f    6      f
        f    7      f
        f    8      f
        
        So cell is alive if...
        t    2      t
        t    3      t
        f    3      t

   TODO AYS - Although we can use the simple logic below, if we rewrite it as a switch with two int[] (one for births, one for continued life) then we can implement different sets of rules
   */

  public static bool[,] Next(this bool[,] board) =>
    board.Cast<bool>().ToArray()
      .Select((cell, pos) => {
        (int x, int y) = PosToCoords(board, pos);
        int count = Count(board, x, y);

        // ie when count==2 and cell, or when count==3
        //return (count == 2 && cell) || count == 3;

        // General logic that can handle any Life rules. Eventually we will pass these in as parameters, derived from a string, eg B3/S23
        int[] survives = [2,3]; // Any live cell with this number of live neighbours is alive in the next generation
        int[] born = [3]; // Any dead cell with this number of live neighbours becomes alive in the next generation

        bool res = cell switch {
          true when survives.Contains(count) => true,
          false when born.Contains(count) => true,
          _ => false
        };
        return cell switch {
          true when survives.Contains(count) => true,
          false when born.Contains(count) => true,
          _ => false
        };
      })
      .ToArray()
      .To2D(board.GetLength(0));

  // [2,3] is 2 rows x 3 cols
  // board.GetLength(0) is rows
  // board.GetLength(1) is cols
  public static (int row, int cols) PosToCoords(bool[,] board, int pos) =>
    (pos / board.GetLength(1), pos % board.GetLength(1));
}