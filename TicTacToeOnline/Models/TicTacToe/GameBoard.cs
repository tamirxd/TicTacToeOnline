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
	    Board = new Symbol[BOARD_ROWS , BOARD_COLS];
	}
    }
}
