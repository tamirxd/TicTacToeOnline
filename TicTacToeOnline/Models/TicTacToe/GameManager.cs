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

	public GameManager(ISession firstPlayer) : this() // Add waiting player to an existing game
	{
	    Players.Add(BitConverter.ToInt32(firstPlayer.Get("GUID")), new Player(Symbol.X, PLAYER_ONE));
	    //Players[secondPlayer] = new Player(Symbol.O, PLAYER_TWO);
	}

	public GameManager(int firstGUID, int secondGUID) : this() // Add 2 waiting players to a new game
	{
	    Players.Add(firstGUID, new Player(Symbol.X, PLAYER_ONE));
	    Players.Add(secondGUID, new Player(Symbol.O, PLAYER_TWO));
	}

	private GameManager()
	{
	    GameBoard = new GameBoard();
	    Players = new Dictionary<int, Player>();
	    GameStarted = true;
	    WinnerSymbol = Symbol.None;
	    MarkedSquares = 0;
	    CurrentPlayerSymbol = randomFirstPlayer(Players.Count);
	    LastMarkedSymbol = Symbol.None;
	}

	public void AddSecondPlayer(int secondPlayerGUID)
	{
	    if (Players.Count < 2)
	    {
		Players.Add(secondPlayerGUID, new Player(Symbol.O, PLAYER_TWO));
	    }
	}

	private Symbol randomFirstPlayer(int randMax)
	{
	    return (Symbol)new Random().Next(randMax);
	}

	// returns true if the player has won
	public PlayResult Mark(Symbol playerSymbol, int cellRow, int cellCol)
	{
	    PlayResult playResult = PlayResult.None;
	    if (GameBoard.Board[cellRow, cellCol] != Symbol.X && GameBoard.Board[cellRow, cellCol] != Symbol.O)
	    {
		GameBoard.Board[cellRow, cellCol] = playerSymbol;
		MarkedSquares++;
		playResult = checkForCurrentPlayerWin(cellRow, cellCol);
		LastMarkedSquare = cellRow * 3 + cellCol;
		LastMarkedSymbol = CurrentPlayerSymbol;
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
	    }

	    return playResult;
	}

	private bool checkDiagonalWin(int cellRow, int cellCol)
	{
	    bool diagonalWin = (GameBoard.Board[1, 1] != CurrentPlayerSymbol) ? true : false;
	    if (cellCol == 0)
	    {
		if (cellRow == 0)
		{
		    diagonalWin = diagonalWin && GameBoard.Board[cellRow, cellCol] == CurrentPlayerSymbol &&
			GameBoard.Board[GameBoard.BOARD_ROWS, GameBoard.BOARD_COLS] == CurrentPlayerSymbol;
		}
		else if (cellRow == GameBoard.BOARD_ROWS)
		{
		    diagonalWin = diagonalWin && GameBoard.Board[cellRow, cellCol] == CurrentPlayerSymbol &&
			GameBoard.Board[0, GameBoard.BOARD_COLS] == CurrentPlayerSymbol;
		}
	    }
	    else if (cellCol == GameBoard.BOARD_COLS)
	    {
		if (cellRow == 0)
		{
		    diagonalWin = diagonalWin && GameBoard.Board[cellRow, cellCol] == CurrentPlayerSymbol &&
					    GameBoard.Board[GameBoard.BOARD_ROWS, 0] == CurrentPlayerSymbol;
		}
		else if (cellRow == GameBoard.BOARD_ROWS)
		{
		    diagonalWin = diagonalWin && GameBoard.Board[cellRow, cellCol] == CurrentPlayerSymbol &&
					    GameBoard.Board[0, 0] == CurrentPlayerSymbol;
		}
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
	    return rowWin;
	}

	private bool checkColWin(int cellCol)
	{
	    bool colWin = true;
	    for (int i = 0; i < GameBoard.BOARD_COLS; i++)
	    {
		colWin = colWin && GameBoard.Board[i, cellCol] == CurrentPlayerSymbol;
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
    }
}
