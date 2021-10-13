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
    private InitialiseDiscordService _serviceProvider;
    public static void Main(string[] args)
    => new Program().MainAsync().GetAwaiter().GetResult();

    private Task Log(LogMessage msg)
    {
      Console.WriteLine(msg.ToString());
      return Task.CompletedTask;
    }

    private async Task NewMessage(SocketMessage newMsg)
    {
      if (Environment.GetEnvironmentVariable("DOT_ENV") == "Dev")
      {
        SocketGuildChannel chan = newMsg.Channel as SocketGuildChannel;
        string from = chan != null ? $"{chan.Guild.Name} > {chan.Name}" : "MP";
        string author = chan != null ? $"{newMsg.Author} ({(newMsg.Author as SocketGuildUser).Nickname})" : newMsg.Author.ToString();
        Console.WriteLine($"{newMsg.Timestamp.UtcDateTime} : {from} : {author} => {newMsg}");
      }
    }

    public async Task MainAsync()
    {
      DiscordSocketConfig _config = new DiscordSocketConfig { MessageCacheSize = 100 };
      _client = new DiscordSocketClient(_config);
      _commands = new CommandService();
      _serviceProvider = new InitialiseDiscordService(_commands, _client);
      _commandHandler = new CommandHandler(_serviceProvider.BuildServiceProvider(), _client, _commands);
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
