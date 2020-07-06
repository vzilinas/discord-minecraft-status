using Microsoft.Extensions.Configuration;
using MinecraftStatusBot.Helpers;

namespace MinecraftStatusBot.Services
{
    public class MinecraftRestartService
    {
        private readonly IConfiguration _configuration;

        public MinecraftRestartService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //ToDo: figure out why this doesn't fire
        public string StartServer()
        {
            var minecraftStatus = new MinecraftStatusChecker(_configuration["ip"], 25565);
            if (!minecraftStatus.ServerUp)
            {
                var command = "screen -dmS \"minecraft\" sh /home/minecraft/minecraft/run.sh";
                BashHelper.Bash(command);
                return "Server is starting up!";
            }
            return "Server is already up!";
        }
    }
}