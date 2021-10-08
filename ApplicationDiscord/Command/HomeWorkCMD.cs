using Discord.Commands;
using System.Threading.Tasks;

namespace ApplicationDiscord.Command
{
    [Group("hw")]
    [Summary("HomeWork allow the user to handle the basic HomeWork")]
    public class HomeWorkCMD : ModuleBase<SocketCommandContext>
    {
        [Command]
        public async Task DefaultHomeWorkCMD()
        {
            await Context.Channel.SendMessageAsync("Hello World");
        }
    }
}
