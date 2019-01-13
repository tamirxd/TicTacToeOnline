using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeOnline.Models.TicTacToe
{
    public class GameBoard
    {
	public const short BOARD_ROWS = 3;
	public const short BOARD_COLS = 3;

	public Symbol[,] Board { get; }

	public GameBoard()
	{
	    Board = new Symbol[BOARD_ROWS, BOARD_COLS];
	    initializeBoard();
	}

	private void initializeBoard()
	{
	    for (int i = 0; i < BOARD_ROWS; i++)
	    {
		for (int j = 0; j < BOARD_COLS; j++)
		{
		    Board[i, j] = Symbol.None;
		}
	    }
	}
    }
}
