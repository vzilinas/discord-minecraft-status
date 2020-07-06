using System;
using Microsoft.Extensions.Configuration;
using MinecraftStatusBot.Helpers;
using MinecraftStatusBot.Models;

namespace MinecraftStatusBot.Services
{
    public class MinecraftStatusService
    {
        private readonly IConfiguration _configuration;
        public MinecraftStatusService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MinecraftStatus GetStatus()
        {
            var minecraftStatus = new MinecraftStatusChecker(_configuration["ip"], 25565);
            return new MinecraftStatus
            {
                CurrentPlayerCount = Convert.ToInt32(minecraftStatus.CurrentPlayers),
                IsRunning = minecraftStatus.ServerUp
            };
        }
    }
}