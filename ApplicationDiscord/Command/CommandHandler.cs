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

        public CommandHandler(DiscordSocketClient client,CommandService commands)
        {
            _commands = commands;
            _client = client;
        }

        public async Task InstalCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),services: null);
            Console.WriteLine(_commands.Commands);
        }
        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            SocketUserMessage message = messageParam as SocketUserMessage;
            if (message == null) return;
            int argPos = 0;
            String Prefix = Environment.GetEnvironmentVariable("BotPrefix")!=null? Environment.GetEnvironmentVariable("BotPrefix") : "!";
            if (!(message.HasCharPrefix(Prefix[0], ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;
            SocketCommandContext context = new SocketCommandContext(_client, message);

            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
        }
    }
}
