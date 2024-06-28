using Life.Game;
using static Life.Game.GameHelpers;
using static Life.Game.LifeHelpers;

bool[,] board = LifeShapes.Blinker.ToBoard();
while (true) {
  Console.WriteLine(board.ToBoardString(true));
  board = Next(board);
  Thread.Sleep(500);
  Console.Clear();
}