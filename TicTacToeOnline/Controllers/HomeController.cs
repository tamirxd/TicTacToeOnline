using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TicTacToeOnline.Models;
using TicTacToeOnline.Services;

namespace TicTacToeOnline.Controllers
{
    public class HomeController : Controller
    {
	[Route("~/")]
	public IActionResult Index()
	{
	    HttpContext.Session.Set("GUID",BitConverter.GetBytes(HttpContext.Session.GetHashCode()));
	    return View();
	}

	public IActionResult Privacy()
	{
	    return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
	    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
    }
}
