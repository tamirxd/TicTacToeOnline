using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeOnline.Models;

namespace TicTacToeOnline.Services
{
    public interface IGameStatics
    {
	void Add(GameStatics gameStatics);
	Task SaveAsync();
	IQueryable<GameStatics> GetAll();
	GameStatics Get(int id);
    }
}
