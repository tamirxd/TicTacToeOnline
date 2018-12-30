using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeOnline.Models.TicTacToe
{
    [DefaultValue(None)]
    public enum PlayResult
    {
	Winner,
	Loser,
	Tie,
	None
    }
}
