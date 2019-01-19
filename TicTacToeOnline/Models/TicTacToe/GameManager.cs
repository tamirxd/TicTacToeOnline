using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeOnline.Models.TicTacToe
{
    public class GameManager
    {
	private const short PLAYER_ONE = 0;
	private const short PLAYER_TWO = 1;
	public GameBoard GameBoard { get; }
	public Dictionary<int, Player> Players { get; }
	public Symbol CurrentPlayerSymbol { get; private set; }
	public short MarkedSquares { get; private set; }
	public bool GameStarted { get; private set; }
	public Symbol WinnerSymbol { get; private set; }
	public int LastMarkedSquare { get; private set; }
	public Symbol LastMarkedSymbol { get; private set; }
	public WinningLine WinningLine { get; private set; }
	public bool IsUpdatedOnDb { get; private set; }

	public GameManager(ISession firstPlayer) : this()
	{
	    Players.Add(BitConverter.ToInt32(firstPlayer.Get("GUID")), new Player(Symbol.X, PLAYER_ONE));
	}

	public GameManager(int firstGUID, int secondGUID) : this() // Add 2 waiting players to a new game
	{
	    Players.Add(firstGUID, new Player(Symbol.X, PLAYER_ONE));
	    Players.Add(secondGUID, new Player(Symbol.O, PLAYER_TWO));
	    GameStarted = true;
	}

	private GameManager()
	{
	    GameBoard = new GameBoard();
	    Players = new Dictionary<int, Player>();
	    GameStarted = false;
	    WinnerSymbol = Symbol.None;
	    MarkedSquares = 0;
	    CurrentPlayerSymbol = randomFirstPlayer(2);
	    LastMarkedSymbol = Symbol.None;
	    WinningLine = WinningLine.None;
	    IsUpdatedOnDb = false;
	}

	public void AddSecondPlayer(int secondPlayerGUID)
	{
	    if (Players.Count < 2)
	    {
		Players.Add(secondPlayerGUID, new Player(Symbol.O, PLAYER_TWO));
		GameStarted = true;
	    }
	}

	private Symbol randomFirstPlayer(int randMax)
	{
	    return (Symbol)new Random().Next(randMax);
	}

	public PlayResult Mark(Symbol playerSymbol, int cellRow, int cellCol)
	{
	    PlayResult playResult = PlayResult.None;
	    if (GameBoard.Board[cellRow, cellCol] != Symbol.X && GameBoard.Board[cellRow, cellCol] != Symbol.O)
	    {
		GameBoard.Board[cellRow, cellCol] = playerSymbol;
		MarkedSquares++;
		playResult = checkForCurrentPlayerWin(cellRow, cellCol);
		LastMarkedSquare = cellRow * 3 + cellCol;
		LastMarkedSymbol = playerSymbol;
		toggleTurn();
	    }

	    return playResult;
	}

	private PlayResult checkForCurrentPlayerWin(int cellRow, int cellCol)
	{
	    PlayResult playResult = PlayResult.None;
	    if (checkRowWin(cellRow) || checkColWin(cellCol) || checkDiagonalWin(cellRow, cellCol))
	    {
		playResult = PlayResult.Winner;
		WinnerSymbol = CurrentPlayerSymbol;
	    }
	    else if (MarkedSquares == 9)
	    {
		playResult = PlayResult.Tie;
		WinnerSymbol = Symbol.Tie;
	    }

	    return playResult;
	}

	private bool checkDiagonalWin(int cellRow, int cellCol)
	{
	    bool diagonalWin = (GameBoard.Board[1, 1] == CurrentPlayerSymbol) ? true : false;
	    if (diagonalWin)
	    {
		diagonalWin = checkDiagonalWinWithCenter(cellRow, cellCol);
	    }

	    if (diagonalWin)
	    {
		WinningLine = WinningLine.Diagonal;
	    }

	    return diagonalWin;
	}

	private bool checkDiagonalWinWithCenter(int cellRow, int cellCol)
	{
	    bool diagonalWin = true;
	    if (cellCol == 0)
	    {
		if (cellRow == 0)
		{
		    diagonalWin = diagonalWin && GameBoard.Board[cellRow, cellCol] == CurrentPlayerSymbol &&
			GameBoard.Board[GameBoard.BOARD_ROWS - 1, GameBoard.BOARD_COLS - 1] == CurrentPlayerSymbol;
		}
		else if (cellRow == GameBoard.BOARD_ROWS - 1)
		{
		    diagonalWin = diagonalWin && GameBoard.Board[cellRow, cellCol] == CurrentPlayerSymbol &&
			GameBoard.Board[0, GameBoard.BOARD_COLS - 1] == CurrentPlayerSymbol;
		}
		else
		{
		    diagonalWin = false;
		}
	    }
	    else if (cellCol == GameBoard.BOARD_COLS - 1)
	    {
		if (cellRow == 0)
		{
		    diagonalWin = diagonalWin && GameBoard.Board[cellRow, cellCol] == CurrentPlayerSymbol &&
					    GameBoard.Board[GameBoard.BOARD_ROWS - 1, 0] == CurrentPlayerSymbol;
		}
		else if (cellRow == GameBoard.BOARD_ROWS - 1)
		{
		    diagonalWin = diagonalWin && GameBoard.Board[cellRow, cellCol] == CurrentPlayerSymbol &&
					    GameBoard.Board[0, 0] == CurrentPlayerSymbol;
		}
		else
		{
		    diagonalWin = false;
		}
	    }
	    else
	    {
		diagonalWin = false;
	    }

	    return diagonalWin;
	}

	private bool checkRowWin(int cellRow)
	{
	    bool rowWin = true;
	    for (int i = 0; i < GameBoard.BOARD_ROWS; i++)
	    {
		rowWin = rowWin && GameBoard.Board[cellRow, i] == CurrentPlayerSymbol;
	    }

	    if (rowWin)
	    {
		WinningLine = WinningLine.Row;
	    }
	    return rowWin;
	}

	private bool checkColWin(int cellCol)
	{
	    bool colWin = true;
	    for (int i = 0; i < GameBoard.BOARD_COLS; i++)
	    {
		colWin = colWin && GameBoard.Board[i, cellCol] == CurrentPlayerSymbol;
	    }

	    if (colWin)
	    {
		WinningLine = WinningLine.Column;
	    }

	    return colWin;
	}

	private void toggleTurn()
	{
	    if (CurrentPlayerSymbol == Symbol.O)
	    {
		CurrentPlayerSymbol = Symbol.X;
	    }
	    else
	    {
		CurrentPlayerSymbol = Symbol.O;
	    }
	}

	public GameStatics GetGameStatics()
	{
	    if (WinnerSymbol != Symbol.None && !IsUpdatedOnDb)
	    {
		IsUpdatedOnDb = true;
		return new GameStatics
		{
		    Moves = MarkedSquares,
		    WinningLine = WinningLine.ToString(),
		    WinnerSymbol = WinnerSymbol.ToString()
		};
	    }

	    return null;
	}
    }
}