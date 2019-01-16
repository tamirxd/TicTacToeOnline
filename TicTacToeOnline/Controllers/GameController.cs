using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicTacToeOnline.Models.TicTacToe;
using TicTacToeOnline.Services;
using TicTacToeOnline.ViewModels;

namespace TicTacToeOnline.Controllers
{
    public class GameController : Controller
    {
	private readonly IGameStatics sqlContext;
	private readonly IPlayersSessionHandler sessionHandler;

	public GameController(IPlayersSessionHandler handler, IGameStatics sqlStatics)
	{
	    sqlContext = sqlStatics;
	    sessionHandler = handler;
	}

	public IActionResult Index()
	{
	    sessionHandler.AddNewPlayer(HttpContext.Session);
	    return RedirectToAction(nameof(ActiveGame));
	}

	public IActionResult ActiveGame()
	{
	    GamePartialViewModel viewModel = new GamePartialViewModel();
	    Dictionary<int, GameManager> playingPlayers = sessionHandler.GetPlayingPlayers();
	    int playerGUID = BitConverter.ToInt32(HttpContext.Session.Get("GUID"));

	    if (playingPlayers.ContainsKey(playerGUID))
	    {
		viewModel.Board = playingPlayers[playerGUID].GameBoard;
		viewModel.Player = playingPlayers[playerGUID].Players[playerGUID];
		viewModel.Started = playingPlayers[playerGUID].GameStarted;
	    }
	    else
	    {
		viewModel.Board = new GameBoard(); // Just an empty Board
	    }

	    return View(viewModel);
	}

	public IActionResult GetStartingValues()
	{
	    int playerGUID = BitConverter.ToInt32(HttpContext.Session.Get("GUID"));

	    return Json(new StartingValuesViewModel
	    {
		PlayerSymbol = sessionHandler.GetPlayingPlayers()[playerGUID].Players[playerGUID].PlayerSymbol.ToString(),
		FirstPlayerSymbol = sessionHandler.GetPlayingPlayers()[playerGUID].CurrentPlayerSymbol.ToString(),
		GameStarted = sessionHandler.GetGame(playerGUID).GameStarted
	    });
	}

	[HttpPost]
	public IActionResult Mark(int index)
	{
	    int playerGUID = BitConverter.ToInt32(HttpContext.Session.Get("GUID"));
	    GameManager game = sessionHandler.GetPlayingPlayers()[playerGUID];
	    Symbol symbol = game.Players[playerGUID].PlayerSymbol;
	    if (symbol.Equals(game.CurrentPlayerSymbol))
	    {
		game.Mark(symbol, index / 3, index % 3);
	    }
	    else
	    {
		Response.StatusCode = StatusCodes.Status401Unauthorized;
	    }

	    return Json(new GameUpdateViewModel
	    {
		LastMarkedSquare = index,
		LastMarkedSymbol = symbol.ToString(),
		Winner = game.WinnerSymbol.ToString()
	    });
	}

	public IActionResult Turn()
	{
	    GameManager playerGame = sessionHandler.GetGame(BitConverter.ToInt32(HttpContext.Session.Get("GUID")));
	    if (playerGame == null)
	    {
		Response.StatusCode = StatusCodes.Status400BadRequest;
		return Json(new object());
	    }
	    JsonResult json = Json(new GameUpdateViewModel
	    {
		LastMarkedSquare = playerGame.LastMarkedSquare,
		LastMarkedSymbol = playerGame.LastMarkedSymbol.ToString(),
		Winner = playerGame.WinnerSymbol.ToString(),
		CurrentPlayer = playerGame.CurrentPlayerSymbol.ToString()
	    });


	    if (playerGame.WinnerSymbol != Symbol.None && playerGame.WinnerSymbol != playerGame.Players[BitConverter.ToInt32(HttpContext.Session.Get("GUID"))].PlayerSymbol)
	    {
		saveGameStaticsAsync(playerGame);
		sessionHandler.RemoveFromPlayingListAndUpdateStatics(playerGame);
	    }

	    return json;
	}

	public IActionResult GameStarted()
	{
	    int playerGUID = BitConverter.ToInt32(HttpContext.Session.Get("GUID"));
	    if (sessionHandler.GetGame(playerGUID) != null)
	    {
		return Json(new { sessionHandler.GetGame(playerGUID).GameStarted });
	    }
	    else
	    {
		return Json(false);
	    }
	}

	private void saveGameStaticsAsync(GameManager game)
	{
	    if (!game.IsUpdatedOnDb)
	    {
		sqlContext.Add(game.GetGameStatics());
		sqlContext.SaveAsync();
	    }
	}
    }
}