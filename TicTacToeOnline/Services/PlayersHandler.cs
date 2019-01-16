using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TicTacToeOnline.Models.TicTacToe;

namespace TicTacToeOnline.Services
{
    public class PlayersHandler : IPlayersSessionHandler
    {
	private readonly ISet<int> waitingPlayers;
	private readonly Dictionary<int, GameManager> playingPlayers;

	public PlayersHandler()
	{
	    waitingPlayers = new HashSet<int>();
	    playingPlayers = new Dictionary<int, GameManager>();
	}

	public void AddNewPlayer(ISession playerSession)
	{
	    int playerGUID = BitConverter.ToInt32(playerSession.Get("GUID"));
	    if (!playingPlayers.ContainsKey(playerGUID))
	    {
		if (!waitingPlayers.Contains(playerGUID))
		{
		    waitingPlayers.Add(playerGUID);
		}

		if (waitingPlayers.Count > 1)
		{
		    int waitingPlayerGUID = waitingPlayers.First(guid => guid != playerGUID);

		    if (!playingPlayers.ContainsKey(waitingPlayerGUID))
		    {
			addPlayersToNewGame(waitingPlayerGUID, waitingPlayerGUID);
		    }
		    else
		    {
			addPlayerToExisitingGame(playerGUID, playingPlayers[waitingPlayerGUID]);
		    }
		}
		else
		{
		    playingPlayers.Add(playerGUID, new GameManager(playerSession));
		}
	    }
	}

	private void addPlayerToExisitingGame(int secondPlayerGUID, GameManager exisitngGame)
	{
	    int firstPlayerGUID = exisitngGame.Players.FirstOrDefault(player => player.Key != secondPlayerGUID).Key;
	    playingPlayers.Add(secondPlayerGUID, exisitngGame);
	    exisitngGame.AddSecondPlayer(secondPlayerGUID);
	    RemovePlayersFromWaitingList(exisitngGame);
	}

	private void addPlayersToNewGame(int secondPlayerGUID, int firstPlayerGUID)
	{
	    GameManager newGame = new GameManager(firstPlayerGUID, secondPlayerGUID);
	    playingPlayers.Add(firstPlayerGUID, newGame);
	    playingPlayers.Add(secondPlayerGUID, newGame);
	    RemovePlayersFromWaitingList(newGame);
	}

	public GameManager GetGame(int playerGUID)
	{
	    if (playingPlayers.ContainsKey(playerGUID))
	    {
		return playingPlayers[playerGUID];
	    }
	    return null;
	}

	public void RemoveFromPlayingListAndUpdateStatics(GameManager playersGame)
	{
	    foreach (var item in playingPlayers.Where(pair => pair.Value == playersGame).ToList())
	    {
		playingPlayers.Remove(item.Key);
	    }
	}

	public void RemovePlayersFromWaitingList(GameManager activeGame)
	{
	    foreach (var session in waitingPlayers.Where(playerSession => playingPlayers[playerSession] == activeGame).ToList())
	    {
		waitingPlayers.Remove(session);
	    }
	}

	public ISet<int> GetWaitingPlayers()
	{
	    return waitingPlayers;
	}

	public Dictionary<int, GameManager> GetPlayingPlayers()
	{
	    return playingPlayers;
	}
    }
}
