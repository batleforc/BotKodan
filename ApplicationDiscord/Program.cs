using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace ApplicationDiscord
{
    class Program
    {
        private DiscordSocketClient _client;
        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        private async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            Console.WriteLine("Trigger messageUpdated");
            // If the message was not in the cache, downloading it will result in getting a copy of `after`.
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"{message} -> {after}");
        }

        private async Task NewMessage(SocketMessage newMsg)
        {
            Console.WriteLine($"{newMsg.Timestamp.UtcDateTime} : {newMsg}");
        }

        public async Task MainAsync()
        {
            var _config = new DiscordSocketConfig { MessageCacheSize = 100 };
            _client = new DiscordSocketClient(_config);
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("BotToken"));
            await _client.StartAsync();
            _client.MessageUpdated += MessageUpdated;
            _client.MessageReceived += NewMessage;
            _client.Ready += () =>
            {
                Console.WriteLine("Bot is connected!");
                return Task.CompletedTask;
            };
            await Task.Delay(-1);
        }
        
    }
}
