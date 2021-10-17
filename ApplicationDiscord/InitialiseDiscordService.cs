using ApplicationDiscord.Command;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Database;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Domain.Handler;
using Domain.Interface;
using Infra.Database.inDatabase;
using LinqToDB.Data;

namespace ApplicationDiscord
{
    public class InitialiseDiscordService
    {
		private readonly CommandService _commands;
		private readonly DiscordSocketClient _client;
		private IDb<HomeWork> _database;
		private HandleHomeWork _handler;

		public InitialiseDiscordService(CommandService commands = null, DiscordSocketClient client = null)
		{
			_commands = commands ?? new CommandService();
			_client = client ?? new DiscordSocketClient();
			DataConnection.DefaultSettings = new ConnectionSettings();
			_database = new InDatabase<HomeWork>();
			_database.ConnectDb();
			_handler = new HandleHomeWork(_database);
		}

		public IServiceProvider BuildServiceProvider() => new ServiceCollection()
			.AddSingleton(_client)
			.AddSingleton(_commands)
			.AddSingleton(_handler)
			.AddSingleton<CommandHandler>()
			.BuildServiceProvider();
	}
}
