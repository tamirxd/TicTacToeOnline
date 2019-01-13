using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeOnline.ViewModels
{
    public class GameUpdateViewModel
    {
	public int LastMarkedSquare{ get; set; }
	public string LastMarkedSymbol { get; set; }
	public string Winner { get; set; }
	public string CurrentPlayer { get; set; }
    }
}
