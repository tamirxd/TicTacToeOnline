using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeOnline.Data;
using TicTacToeOnline.Models;

namespace TicTacToeOnline.Services
{
    public class SqlGameStatics : IGameStatics
    {
	private TicTacToeDbContext context;

	public SqlGameStatics(TicTacToeDbContext _context)
	{
	    context = _context;
	}

	public void Add(GameStatics gameStatics)
	{
	    context.Games.Add(gameStatics);
	}

	public async Task SaveAsync()
	{
	    await context.SaveChangesAsync();
	}

	public GameStatics Get(int id)
	{
	    return context.Games.FirstOrDefault(game => game.Id == id);
	}

	public IQueryable<GameStatics> GetAll()
	{
	    return context.Games.OrderBy(game => game.Id);
	}
    }
}
