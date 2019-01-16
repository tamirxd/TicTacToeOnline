using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeOnline.Models.TicTacToe;

namespace TicTacToeOnline.Services
{
    public interface IPlayersSessionHandler
    {
	GameManager GetGame(int playerGUID);
	void AddNewPlayer(ISession newPlayer);
	void RemovePlayersFromWaitingList(GameManager existingGame);
	void RemoveFromPlayingListAndUpdateStatics(GameManager gameManager);
	ISet<int> GetWaitingPlayers();
	Dictionary<int, GameManager> GetPlayingPlayers();
    }
}
