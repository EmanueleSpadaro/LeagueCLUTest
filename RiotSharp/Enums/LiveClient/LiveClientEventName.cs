using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Enums.LiveClient
{
    public enum LiveClientEventName
    {
        GameStart = 0x0,
        MinionsSpawning = 0x1,
        DragonKill = 0x4,
        HeraldKill = 0x5,
        BaronKill =  0x6,
        ChampionKill = 0x8,
        Multikill = 0x9,
        Ace = 0x10,
        TurretKilled = 0x16,
        InhibKilled = 0x17,
        FirstBrick = 0x18,
    }

    public static class LeagueClientEventNameExtension
    {
        public static string AsString(this LiveClientEventName ld)
        {
            string[] values = { "GameStart", "MinionsSpawning", "DragonKill", "HeraldKill", "BaronKill", "ChampionKill", "Multikill", "Ace", "TurretKilled", "InhibKilled", "FirstBrick" };
            int i = (int)ld;
            if (i >= 0 && i < values.Length)
                return values[i];
            else
                return default;
        }

        public static LiveClientEventName ToLiveClientEventName(this string s)
        {
            string[] values = { "GameStart", "MinionsSpawning", "DragonKill", "HeraldKill", "BaronKill", "ChampionKill", "Multikill", "Ace", "TurretKilled", "InhibKilled", "FirstBrick" };
            for (int i = 0; i < values.Length; i++)
                if (values[i] == s)
                    return (LiveClientEventName)i;
            return default;
        }
    }
}
