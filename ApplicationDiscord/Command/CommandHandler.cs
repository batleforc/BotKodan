using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ApplicationDiscord.Command
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _service;
        private string Prefix = "!";

        public CommandHandler(IServiceProvider service,DiscordSocketClient client,CommandService commands)
        {
            _commands = commands;
            _client = client;
            _service = service;
        }

        public async Task InstalCommandsAsync()
        {
            Prefix = Environment.GetEnvironmentVariable("BotPrefix") != null ? Environment.GetEnvironmentVariable("BotPrefix") : "!";
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),services: _service);
        }
        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            SocketUserMessage message = messageParam as SocketUserMessage;
            if (message == null) return;
            int argPos = 0;
            
            if (!(message.HasCharPrefix(Prefix[0], ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;
            var context = new SocketCommandContext(_client, message);

            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: _service);
        }
    }
}
