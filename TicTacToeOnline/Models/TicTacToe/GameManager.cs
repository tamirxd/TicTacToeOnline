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
	public Dictionary<ISession, Player> Players { get; }
	public Symbol CurrentPlayerSymbol { get; }
	public bool GameStarted { get; }

	public GameManager(ISession firstPlayer, ISession secondPlayer)
	{
	    GameBoard = new GameBoard();
	    Players = new Dictionary<ISession, Player>();
	    Players[firstPlayer] = new Player(Symbol.X, PLAYER_ONE);
	    Players[secondPlayer] = new Player(Symbol.O, PLAYER_TWO);
	    CurrentPlayerSymbol = randomFirstPlayer(Players.Count);
	    GameStarted = true;
	}

	private Symbol randomFirstPlayer(int randMax)
	{
	    return (Symbol)new Random().Next(randMax);
	}

	// returns true if the player has won
	public bool Mark(Symbol playerSymbol, int cellRow, int cellCol)
	{
	    bool gameOver = false;
	    if (GameBoard.Board[cellRow, cellCol] != Symbol.X && GameBoard.Board[cellRow, cellCol] != Symbol.O)
	    {
		GameBoard.Board[cellRow, cellCol] = playerSymbol;
		gameOver = checkForCurrentPlayerWin(cellRow, cellCol);
		toggleTurn();
	    }

	    return gameOver;
	}

	private bool checkForCurrentPlayerWin(int cellRow, int cellCol)
	{
	    return checkRowWin(cellRow) || checkColWin(cellCol) || checkDiagonalWin(cellRow, cellCol);
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
