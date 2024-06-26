﻿using Pixata.Extensions;

namespace Life.Game;

public static class GameHelpers {
  /// <summary>
  /// Converts a string representation of a board to the 2D bool array the code uses
  /// </summary>
  /// <param name="b">A string representation of the board, where a space or full stop represents a dead cell, and a non-space represents a live cell. The string is expected to contain Environment.NewLines at the end of each row</param>
  /// <returns>A 2D bool array representing the board</returns>
  public static bool[,] ToBoard(this string b) =>
    b.Replace(Environment.NewLine, "")
      .Select(c => c != '.' && c != ' ')
      .ToArray()
      .To2D(b.Replace(Environment.NewLine, "").Length / b.IndexOf(Environment.NewLine));

  /// <summary>
  /// Converts a 2D bool array that represents a Life game into a string that can be displayed
  /// </summary>
  /// <param name="board">The Life board as a 2D bool array</param>
  /// <returns></returns>
  public static string ToBoardString(this bool[,] board, bool spaces = false) {
    int dim = board.GetLength(1);
    string str = board.Cast<bool>().Select(c => c ? "*" : spaces ? " " : ".").JoinStr("");
    return Enumerable.Range(0, str.Length / dim)
      .Select(i => str.Substring(i * dim, dim))
      .JoinStr(Environment.NewLine);
  }

  public static bool[,] InitialiseEmpty(int maxX, int maxY) =>
    new bool[maxX, maxY];

  public static bool[,] InitialiseRandom(int maxX, int maxY) {
    Random r = new();
    bool[,] board = new bool[maxX, maxY];
    for (int y = 0; y < maxY; y++) {
      for (int x = 0; x < maxX; x++) {
        board[x, y] = r.Next() % 100 < 15;
      }
    }

    return board;
  }

  public static bool[,] InitialiseGlider(int maxX, int maxY) {
    bool[,] board = new bool[maxX, maxY];
    // Initialise a glider
    board[3, 2] = true;
    board[4, 3] = true;
    board[2, 4] = true;
    board[3, 4] = true;
    board[4, 4] = true;
    return board;
  }
}