using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LeagueCLUTest.RiotSharp.Models
{
    public class LeaguePostablePerkPage
    {
        public string Name { get; set; }
        public int PrimaryStyleId { get; set; }
        public List<int> SelectedPerkIds { get; set; }
        public int SubStyleId { get; set; }

        private static JsonSerializerOptions jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public static LeaguePostablePerkPage FromJSON(string jsonString) => JsonSerializer.Deserialize<LeaguePostablePerkPage>(jsonString, jsonOptions);
        public string ToJSON() => JsonSerializer.Serialize<LeaguePostablePerkPage>(this, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
    }
}
