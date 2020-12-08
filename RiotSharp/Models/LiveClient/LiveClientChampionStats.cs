using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.LiveClient
{
    public class LiveClientChampionStats
    {
        public double AbilityPower { get; set; }
        public double Armor { get; set; }
        public double ArmorPenetrationFlat { get; set; }
        public double ArmorPenetrationPercent { get; set; }
        public double AttackDamage { get; set; }
        public double AttackRange { get; set; }
        public double AttackSpeed { get; set; }
        public double BonusArmorPenetrationPercent { get; set; }
        public double BonusMagicPenetrationPercent { get; set; }
        public double CooldownReduction { get; set; }
        public double CritChance { get; set; }
        public double CritDamage { get; set; }
        public double CurrentHealth { get; set; }
        public double HealthRegenRate { get; set; }
        public double LifeSteal { get; set; }
        public double MagicLethality { get; set; }
        public double MagicPenetrationFlat { get; set; }
        public double MagicResist { get; set; }
        public double MaxHealth { get; set; }
        public double MoveSpeed { get; set; }
        public double PhysicalLethality { get; set; }
        public double ResourceMax { get; set; }
        public double ResourceRegenRate { get; set; }
        public double ResourceValue { get; set; }
        public double SpellVamp { get; set; }
        public double Tenacity { get; set; }
        public string ResourceType { get; set; }
    }
}
