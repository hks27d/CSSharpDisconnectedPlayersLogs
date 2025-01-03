using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Logging;

namespace CSSharpDisconnectedPlayersLogs
{
    public class CSSharpDisconnectedPlayersLogs : BasePlugin
    {
        public override string ModuleName => "CS# Disconnected Players Logs";
        public override string ModuleVersion => "1.0.0";
        public override string ModuleAuthor => "HKS 27D";

        public override void Load(bool hotReload)
        {
            RegisterEventHandler((EventPlayerDisconnect @event, GameEventInfo info) =>
            {
                CCSPlayerController Player = @event.Userid!;

                if (Player != null && Player.IsValid && Player.PlayerPawn.IsValid && !Player.IsBot)
                {
                    Logger.LogInformation("{PlayerName} <{PlayerSteamID}> <{PlayerIP}> disconnected", Player.PlayerName, Player.SteamID, Player.IpAddress);
                }

                return HookResult.Continue;
            }, HookMode.Pre);
        }
    }
};
