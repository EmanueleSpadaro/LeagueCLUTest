using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using RestSharp;

using LeagueCLUTest.RiotSharp.Models;
using LeagueCLUTest.RiotSharp.Exceptions;

namespace LeagueCLUTest.RiotSharp.Requestors
{
    public partial class LeagueRequestor
    {
        public class LeaguePerksRequestor
        {
            private RestClient RestClient;

            public LeaguePerksRequestor(RestClient RestClient) => this.RestClient = RestClient;

            private static RestRequest DeleteAllPagesRequest = new RestRequest("/lol-perks/v1/pages", Method.DELETE);
            private static RestRequest GetCurrentPageRequest = new RestRequest("/lol-perks/v1/currentpage", Method.GET);
            private static RestRequest PutCurrentPageRequest = new RestRequest("/lol-perks/v1/currentpage", Method.GET);
            private static RestRequest GetAllPagesRequest = new RestRequest("/lol-perks/v1/pages", Method.GET);
            private static RestRequest PostPageRequest = new RestRequest("/lol-perks/v1/pages", Method.POST);
            private static RestRequest DeletePageRequest = new RestRequest("/lol-perks/v1/pages/", Method.DELETE);

            public async Task DeleteAllPages() => await RestClient.ExecuteAsync(DeleteAllPagesRequest);
            public async Task<LeaguePerkPage> GetCurrentPage()
            {
                var res = await RestClient.ExecuteAsync(GetCurrentPageRequest);
                return JsonSerializer.Deserialize<LeaguePerkPage>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            private async Task DeletePage(int PageID)
            {
                DeletePageRequest = new RestRequest($"/lol-perks/v1/pages/{PageID}" , Method.DELETE);
                await RestClient.ExecuteAsync(DeletePageRequest);
            }

            public async Task DeletePage(LeaguePerkPage page)
            {
                if (!page.IsDeletable)
                    throw new LeagueUndeletablePageDeleteAttemptException(page);
                await DeletePage(page.ID);
            }

            public async Task<LeaguePerkPage> PostNewPage(LeaguePostablePerkPage page)
            {
                PostPageRequest = new RestRequest("/lol-perks/v1/pages", Method.POST);
                PostPageRequest.AddJsonBody(page.ToJSON());
                var res = await RestClient.ExecuteAsync(PostPageRequest);
                return JsonSerializer.Deserialize<LeaguePerkPage>(res.Content, LeagueRequestor.JsonSerializerOptions);
            }

            public async Task<LeaguePerkPage> ReplaceCurrentPageWith(LeaguePostablePerkPage page)
            {
                var currentPage = await GetCurrentPage();
                await DeletePage(currentPage);
                return await PostNewPage(page);
            }
        }
    }
}
