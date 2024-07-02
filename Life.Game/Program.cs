using Life.Game;
using static Life.Game.GameHelpers;
using static Life.Game.LifeHelpers;

bool[,] board = InitialiseRandom(50, 200);
Console.WriteLine("Press any key to start");
Console.ReadKey();
Console.Clear();
while (true) {
  Console.WriteLine(board.ToBoardString(true));
  board = board.NextSelect("B3/S23");
  Thread.Sleep(400);
  Console.Clear();
}