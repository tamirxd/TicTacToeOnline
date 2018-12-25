using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToeOnline.Models.TicTacToe;
using TicTacToeOnline.ViewModels;

namespace TicTacToeOnline.Controllers
{
    public class GameController : Controller
    {
	private readonly ISet<ISession> waitingPlayers;
	private readonly Dictionary<ISession, GameManager> playingPlayers;

	public GameController()
	{
	    waitingPlayers = new HashSet<ISession>();
	    playingPlayers = new Dictionary<ISession, GameManager>();
	}

	public IActionResult Index()
	{
	    if (!playingPlayers.ContainsKey(HttpContext.Session))
	    {

		waitingPlayers.Add(HttpContext.Session);
		if (waitingPlayers.Count > 1)
		{
		    ISession waitingPlayerSession = waitingPlayers.First(playerSession => playerSession != HttpContext.Session);
		    addToPlayingPlayers(waitingPlayerSession, HttpContext.Session);
		}
	    }

	    return RedirectToAction(nameof(ActiveGame));
	}

	public IActionResult ActiveGame()
	{
	    GamePartialViewModel viewModel = new GamePartialViewModel();

	    if (playingPlayers.ContainsKey(HttpContext.Session))
	    {
		viewModel.Board = playingPlayers[HttpContext.Session].GameBoard;
		viewModel.Player = playingPlayers[HttpContext.Session].Players[HttpContext.Session];
		viewModel.Started = playingPlayers[HttpContext.Session].GameStarted;
	    }
	    else
	    {
		viewModel.Board = new GameBoard(); // Just an empty Board
	    }

	    return View(viewModel);
	}

	private void addToPlayingPlayers(ISession firstPlayer, ISession secondPlayer)
	{
	    GameManager newGame = new GameManager(firstPlayer, secondPlayer);
	    waitingPlayers.Remove(firstPlayer);
	    waitingPlayers.Remove(secondPlayer);
	    playingPlayers.Add(firstPlayer, newGame);
	    playingPlayers.Add(secondPlayer, newGame);
	}

	public IActionResult PlayerSymbol()
	{
	    return Json(playingPlayers[HttpContext.Session].Players[HttpContext.Session].PlayerSymbol);
	}

	public IActionResult Mark(int index) 
	{
	    GameManager game = playingPlayers[HttpContext.Session];

	    if (game.Players[HttpContext.Session].PlayerSymbol.Equals(game.CurrentPlayerSymbol))
	    {
		game.Mark(game.Players[HttpContext.Session].PlayerSymbol, index / 3, index % 3);
	    }
	    
	}
    }

}