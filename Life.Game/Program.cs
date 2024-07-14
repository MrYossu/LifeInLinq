using System.Diagnostics;
using Life.Game;
using static Life.Game.GameHelpers;
using static Life.Game.LifeHelpers;

bool[,] board = InitialiseRandom(50, 100);
board = LifeShapes.InfiniteGrowth3.ToBoard();
Console.WriteLine("Press any key to start");
Console.ReadKey();
Console.Clear();
while (true) {
  Console.WriteLine(board.ToBoardString(true));
  board = board.NextSelect();
  Thread.Sleep(100);
  Console.Clear();
}

/*
// The automaton B1/S12 generates four very close approximations to the Sierpinski triangle when applied to a single live cell
bool[,] board = InitialiseEmpty(50, 100);
board[25, 50] = true;
*/

/*
// Timing test
Stopwatch sw = Stopwatch.StartNew();
for (int i = 0; i < 1000; i++) {
  board = board.NextSelect();
}
Console.WriteLine(sw.ElapsedMilliseconds);
return;
*/
