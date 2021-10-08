using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using ApplicationDiscord.Command;
using Discord.Commands;

namespace ApplicationDiscord
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private CommandHandler _commandHandler;
        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task NewMessage(SocketMessage newMsg)
        {
            SocketGuildChannel chan = newMsg.Channel as SocketGuildChannel;
            String from = chan != null ? $"{chan.Guild.Name} > {chan.Name}" : "MP";
            Console.WriteLine($"{newMsg.Timestamp.UtcDateTime} : {from} : {newMsg.Author} => {newMsg}");
        }

        public async Task MainAsync()
        {
            var _config = new DiscordSocketConfig { MessageCacheSize = 100 };
            _client = new DiscordSocketClient(_config);
            _commands = new CommandService();
            _commandHandler = new CommandHandler(_client, _commands);
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("BotToken"));
            await _client.StartAsync();
            await _commandHandler.InstalCommandsAsync();
            _client.MessageReceived += NewMessage;
            _client.Ready += () =>
            {
                Console.WriteLine("BotKodan is connected!");
                Console.WriteLine($"With the user {_client.CurrentUser}");
                return Task.CompletedTask;
            };
            await Task.Delay(-1);
        }
        
    }
}
