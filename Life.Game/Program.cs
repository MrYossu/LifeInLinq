using Life.Game;
using static Life.Game.GameHelpers;
using static Life.Game.LifeHelpers;

int maxX = 5;
int maxY = 5;
bool[,] board = InitialiseEmpty(maxX, maxY);
//int[,] board = InitialiseGlider(maxX, maxY);
//int[,] board = InitialiseRandom(maxX, maxY);

bool[,] board1 = """
    
 ** 
 ** 
    
"""
.ToBoard();

// Something not working correctly. The counts seem to be correct, but the glider doesn't look like it should after the first iteration
//while (true) {
//  board = Next(board, maxX, maxY);
//  Display(board, maxX, maxY);
//  Thread.Sleep(300);
//}