﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicTacToeOnline.Data;
using TicTacToeOnline.Services;

namespace TicTacToeOnline
{
    public class Startup
    {
	public Startup(IConfiguration configuration)
	{
	    Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
	    services.AddDbContext<TicTacToeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TicTacToeOnline")));
	    services.AddScoped<IGameStatics, SqlGameStatics>();
	    services.AddSingleton<IPlayersSessionHandler, PlayersHandler>();
	    services.Configure<CookiePolicyOptions>(options =>
	    {
		options.CheckConsentNeeded = context => false;
		options.MinimumSameSitePolicy = SameSiteMode.None;
	    });

	    services.AddDistributedMemoryCache();
	    services.AddSession(options =>
	    {
		options.IdleTimeout = TimeSpan.FromMinutes(25);
		options.Cookie.HttpOnly = true;
	    });
	    services.AddMvc();

	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
	    if (env.IsDevelopment())
	    {
		app.UseDeveloperExceptionPage();
	    }
	    else
	    {
		app.UseExceptionHandler("/Home/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	    }

	    app.UseHttpsRedirection();
	    app.UseStaticFiles();
	    app.UseCookiePolicy();
	    app.UseSession();
	    app.UseMvc(routes =>
	    {
		routes.MapRoute(
		    name: "default",
		    template: "{controller=Home}/{action=Index}/{id?}");
	    });
	}
    }
}
