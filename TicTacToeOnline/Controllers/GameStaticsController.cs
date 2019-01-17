using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicTacToeOnline.Data;
using TicTacToeOnline.Models;

namespace TicTacToeOnline.Controllers
{
    public class GameStaticsController : Controller
    {
	private readonly TicTacToeDbContext _context;

	public GameStaticsController(TicTacToeDbContext context)
	{
	    _context = context;
	}

	// GET: GameStatics
	public async Task<IActionResult> Index()
	{
	    return View(await _context.Games.ToListAsync());
	}

	// GET: GameStatics/Details/5
	public async Task<IActionResult> Details(int? id)
	{
	    if (id == null)
	    {
		return NotFound();
	    }

	    var gameStatics = await _context.Games
		.FirstOrDefaultAsync(m => m.Id == id);
	    if (gameStatics == null)
	    {
		return NotFound();
	    }

	    return View(gameStatics);
	}
    }

}
