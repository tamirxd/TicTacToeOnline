using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToeOnline.Models.TicTacToe;
using TicTacToeOnline.Services;
using TicTacToeOnline.ViewModels;

namespace TicTacToeOnline.Controllers
{
    public class GameController : Controller
    {
	private readonly IPlayersSessionHandler sessionHandler;
	//private IHttpContextAccessor httpContextAccessor;

	public GameController(IPlayersSessionHandler handler)
	{
	    //waitingPlayers = new HashSet<ISession>();
	    //playingPlayers = new Dictionary<ISession, GameManager>();
	    //  httpContextAccessor = contextAccessor;
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
		FirstPlayerSymbol = sessionHandler.GetPlayingPlayers()[playerGUID].CurrentPlayerSymbol.ToString()
	    });
	}

	public IActionResult Mark(int index)
	{
	    int playerGUID = BitConverter.ToInt32(HttpContext.Session.Get("GUID"));
	    GameManager game = sessionHandler.GetPlayingPlayers()[playerGUID];
	    Symbol symbol = game.Players[playerGUID].PlayerSymbol;


	    if (symbol.Equals(game.CurrentPlayerSymbol))
	    {
		game.Mark(symbol, index / 3, index % 3);
		if (game.WinnerSymbol != Symbol.None)
		{
		    sessionHandler.RemovePlayerFromPlayingList(game);
		}
	    }

	    return Json(new GameUpdateViewModel
	    {
		LastMarkedSquare = index,
		LastMarkedSymbol = symbol.ToString(),
		Winner = game.WinnerSymbol.ToString()
	    });
	}
    }

}