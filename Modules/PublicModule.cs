using System.Threading.Tasks;
using Discord.Commands;
using MinecraftStatusBot.Services;

namespace MinecraftStatusBot.Modules
{
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        public MinecraftStatusService MinecraftStatusService { get; set; }
        public MinecraftRestartService MinecraftRestartService { get; set; }

        [Command("status")]
        public async Task GetStatus() 
        {
            var status = MinecraftStatusService.GetStatus();
            var message = "The server is currently";
            message += status.IsRunning ? $" up and {status.CurrentPlayerCount} player{(status.CurrentPlayerCount == 1 ? "" : "s")} playing at the moment!" : " down!";
            await ReplyAsync(message);
        }

        [Command("start")]
        public async Task StartServer() 
        {
            var result = MinecraftRestartService.StartServer();
            await ReplyAsync(result);
        }
    }
}