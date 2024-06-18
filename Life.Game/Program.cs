using static Life.Game.GameHelpers;
using static Life.Game.LifeHelpers;

(int X, int Y)[] offsets = [(-1, 1), (0, 1), (1, 1), (-1, 0), (1, 0), (-1, -1), (0, -1), (1, -1)];
int maxX = 5;
int maxY = 5;
int[,] board = InitialiseEmpty(maxX, maxY);
//int[,] board = InitialiseGlider(maxX, maxY);
//int[,] board = InitialiseRandom(maxX, maxY);

// Something not working correctly. The counts seem to be correct, but the glider doesn't look like it should after the first iteration
while (true) {
  board = Next(board, offsets, maxX, maxY);
  Display(board, maxX, maxY);
  Thread.Sleep(300);
}