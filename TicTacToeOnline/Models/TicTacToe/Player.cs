namespace TicTacToeOnline.Models.TicTacToe
{
    public class Player
    {
	public Symbol PlayerSymbol { get; }
	public int Index { get; }

	public Player(Symbol symbol, int index)
	{
	    PlayerSymbol = symbol;
	    Index = index;
	}
    }
}