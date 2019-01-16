using System.ComponentModel;
    
namespace TicTacToeOnline.Models.TicTacToe
{
    [DefaultValue(None)]
    public enum WinningLine
    {
	None,
	Row,
	Column,
	Diagonal
    }
}
