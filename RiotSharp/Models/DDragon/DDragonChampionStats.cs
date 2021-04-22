using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCLUTest.RiotSharp.Models.DDragon
{
    public class DDragonChampionStats
    {
        public double Hp { get; set; }
        public double HpPerLevel { get; set; }
        public double Mp { get; set; }
        public double MpPerLevel { get; set; }
        public double MoveSpeed { get; set; }
        public double Armor { get; set; }
        public double ArmorPerLevel { get; set; }
        /// <summary>
        /// Literally Magic Resistance, I know, why would they call it like that?
        /// </summary>
        public double SpellBlock { get; set; }
        /// <summary>
        /// Literally Magic Resistance, I know, why would they call it like that?
        /// </summary>
        public double SpellBlockPerLevel { get; set; }
        public double AttackRange { get; set; }
        public double HpRegen { get; set; }
        public double HpRegenPerLevel { get; set; }
        public double MpRegen { get; set; }
        public double MpRegenPerLevel { get; set; }
        public double Crit { get; set; }
        public double CritPerLevel { get; set; }
        public double AttackDamage { get; set; }
        public double AttackDamagePerLevel { get; set; }
        public double AttackSpeedPerLevel { get; set; }
        public double AttackSpeed { get; set; }

    }
}
