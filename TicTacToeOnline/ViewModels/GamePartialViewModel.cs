using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeOnline.Models.TicTacToe;

namespace TicTacToeOnline.ViewModels
{
    public class GamePartialViewModel
    {
	public GameBoard Board { get; set; }
	public Player Player { get; set; }
	public bool Started { get; set; }

	public GamePartialViewModel()
	{
	    Board = null;
	    Player = null;
	    Started = false;
	}
    }
}
