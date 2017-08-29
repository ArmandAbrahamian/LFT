using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using GiantBomb.Api;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Configuration;

namespace LFT.Web.Models
{
    public class RootObject
    {
        public string error { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int number_of_page_results { get; set; }
        public int number_of_total_results { get; set; }
        public int status_code { get; set; }
        public List<Result> results { get; set; }
        public string version { get; set; }
    }

    public class Result
    {
        public string aliases { get; set; }
        public string api_detail_url { get; set; }
        public string date_added { get; set; }
        public string date_last_updated { get; set; }
        public string deck { get; set; }
        public string description { get; set; }
        public object expected_release_day { get; set; }
        public object expected_release_month { get; set; }
        public object expected_release_quarter { get; set; }
        public object expected_release_year { get; set; }
        public int id { get; set; }
        public Image image { get; set; }
        public string name { get; set; }
        public int number_of_user_reviews { get; set; }
        public List<OriginalGameRating> original_game_rating { get; set; }
        public string original_release_date { get; set; }
        public List<Platform> platforms { get; set; }
        public string site_detail_url { get; set; }
        public string resource_type { get; set; }
    }

    public class Image
    {
        public string icon_url { get; set; }
        public string medium_url { get; set; }
        public string screen_url { get; set; }
        public string small_url { get; set; }
        public string super_url { get; set; }
        public string thumb_url { get; set; }
        public string tiny_url { get; set; }
    }

    public class OriginalGameRating
    {
        public string api_detail_url { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Platform
    {
        public string api_detail_url { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string site_detail_url { get; set; }
        public string abbreviation { get; set; }
    }

    public class MyClass
    {
        public static ObservableCollection<Result> ApiGamesList = new ObservableCollection<Result>();

        public MyClass()
        {
            GiantBomb = new GiantBombRestClient("4affc7db1e3b7eb2e70b7ad265724d944c92be65");

            var game = GiantBomb.GetGame(23);
        }

        public MyClass(IGiantBombRestClient giantbomb)
        {
            GiantBomb = giantbomb;
        }

        protected IGiantBombRestClient GiantBomb { get; private set; }

        public static async Task<bool> SearchGames(string SearchKeyword)
        {
            RootObject gamesFound = null;

            string jsonData;

            using (var client = new HttpClient())
            {
                try
                {
                    //query to API
                    //response will be a string which will contain json data
                    jsonData = await client.GetStringAsync(new Uri
                    ("http://www.giantbomb.com/api/search/?" + ConfigurationManager.AppSettings["gbapikey"] + "api_key=&format=json&query="  + SearchKeyword + "&resources=game&limit=100"));

                    if (jsonData == null) { return false; }

                    //all games list
                    gamesFound = JsonConvert.DeserializeObject<RootObject>(jsonData);

                    foreach (var game in gamesFound.results)
                    {
                        ApiGamesList.Add(game);
                    }

                }
                catch (Exception)
                { }
            }
            return true;
        }
    }
}