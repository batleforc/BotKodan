using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Domain.Handler;
using Domain.Model;
using System;

namespace ApplicationDiscord.Command
{
  [Group("hw")]
  [Summary("HomeWork allow the user to handle the basic HomeWork")]
  public class HomeWorkCMD : ModuleBase<SocketCommandContext>
  {
    public HandleHomeWork handlehomeWork { get; set; }
    [Command]
    public async Task DefaultHomeWorkCMD()
    {
      await Context.Channel.SendMessageAsync("Hello World");
    }

    [Command("get")]
    public async Task getAllHomeWork()
    {
      if (handlehomeWork.GetHomeWork().Count == 0)
      {
        await Context.Channel.SendMessageAsync("No Homework yet");
      }
      else
        foreach (HomeWork homework in handlehomeWork.GetHomeWork())
        {
          await Context.Channel.SendMessageAsync(homework.ToString());
        }
    }

    [Command("create")]
    public async Task createHomeWork(HomeWorkParameter homeWorkParameter)
    {
      HomeWork newHomeWork = new HomeWork();
      newHomeWork.Label = homeWorkParameter.Label;
      newHomeWork.Matter = homeWorkParameter.Matter;
      newHomeWork.Content = homeWorkParameter.Content;
      DateTime whenToReturn;
      DateTime.TryParse(homeWorkParameter.Due, out whenToReturn);
      newHomeWork.Return = whenToReturn;
      newHomeWork.By = Context.Message.Author.Id.ToString();
      handlehomeWork.CreateHomeWork(newHomeWork);
      await ReplyAsync($"{homeWorkParameter.Label} : has been created");
    }

    [Command("remove")]
    public async Task deleteHomeWork(int id)
    {
      await ReplyAsync($"Do you want to delete {handlehomeWork.GetHomeWork(id)}\n[Yes/No]");
      async Task awaitResponse(SocketMessage newMsg)
      {
        if (newMsg.Author.IsBot) return;
        if (newMsg.Content.ToLower().Contains("yes") && (newMsg.Timestamp).Subtract(Context.Message.Timestamp).Minutes < 1)
        {
          handlehomeWork.DeleteHomeWork(id);
          Context.Client.MessageReceived -= awaitResponse;
          await ReplyAsync("HomeWork deleted");
        }
        else if (newMsg.Content.ToLower().Contains("no") || (newMsg.Timestamp).Subtract(Context.Message.Timestamp).Minutes > 1)
        {
          Context.Client.MessageReceived -= awaitResponse;
          await ReplyAsync("TimeOut");
        }
      }
      Context.Client.MessageReceived += awaitResponse;
    }
  }
}
