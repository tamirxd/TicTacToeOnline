using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeOnline.Models;
    
namespace TicTacToeOnline.Data
{
    public class TicTacToeDbContext : DbContext
    {
	public DbSet<GameStatics> Games { get; set; }

	public TicTacToeDbContext(DbContextOptions options) : base(options)
	{
	}
    }
}
