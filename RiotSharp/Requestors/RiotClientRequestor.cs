using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using System.Text.Json;
using LeagueCLUTest.RiotSharp.Enums;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    partial class LeagueRequestor
    {
        public class RiotClientRequestor
        {
            private RestClient RestClient;
            public RiotClientRequestor(RestClient RestClient) => this.RestClient = RestClient;

            private static RestRequest AppNameRequest = new RestRequest("/riotclient/app-name", Method.GET);
            private static RestRequest AppPortRequest = new RestRequest("/riotclient/app-port", Method.GET);
            private static RestRequest UxMinimizeRequest = new RestRequest("/riotclient/ux-minimize", Method.POST);
            private static RestRequest UxShowRequest = new RestRequest("/riotclient/ux-show", Method.POST);
            private static RestRequest UxFlashRequest = new RestRequest("/riotclient/ux-flash", Method.POST);
            private static RestRequest RegionLocaleRequest = new RestRequest("/riotclient/region-locale", Method.GET);

            public async Task<string>GetAppName()
            {
                var response = await RestClient.ExecuteAsync(AppNameRequest);
                return response.Content;
            }
            public async Task<int> GetAppPort()
            {
                var response = await RestClient.ExecuteAsync(AppPortRequest);
                return Convert.ToInt32(response.Content);
            }

            public async Task UxMinimize() => await RestClient.ExecuteAsync(UxMinimizeRequest);

            public async Task UxShow() => await RestClient.ExecuteAsync(UxShowRequest);

            public async Task UxFlash() => await RestClient.ExecuteAsync(UxFlashRequest);

            public async Task<(Enums.LeagueLocale, Enums.LeagueRegion)> GetRegionLocale()
            {
                var res = await RestClient.ExecuteAsync(RegionLocaleRequest);
                JsonDocument jDoc = JsonDocument.Parse(res.Content);
                return (jDoc.RootElement.GetProperty("locale").GetString().ToLeagueLocale(), jDoc.RootElement.GetProperty("region").GetString().ToLeagueRegion());
            }
        }
    }
}
