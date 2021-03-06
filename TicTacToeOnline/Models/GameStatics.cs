﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeOnline.Models
{
    [Display(Name ="Game Statics")]
    public class GameStatics
    {
	[Display(Name="Game Id")]
	public int Id { get; set; }
	[Display(Name ="Winner")]
	public string WinnerSymbol { get; set; }    // Can be "Tie" for tie
	[Display(Name ="Number Of Moves")]
	public int Moves { get; set; }
	[Display(Name ="Win Type")]
	public string WinningLine { get; set; }     // Row Col Diagonal
    }
}
