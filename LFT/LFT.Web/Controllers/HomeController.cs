using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GiantBomb.Api;
using LFT.Web.ViewModel;
using LFT.Web.Models;
using System.Configuration;

namespace LFT.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendGame()
        {
            return View();
        }
        public ActionResult MyGames()
        {
            return View();
        }
        
        //Custom made URL for the test page --- Look at RouteConfig.cs
        [Route("testingzone/test")]
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult SearchGames(string query)
        {
            ViewData["Query"] = query;
            GameViewModel game = new GameViewModel();

            game.giantbomb = new GiantBombRestClient(ConfigurationManager.AppSettings["gbapikey"]);
            game.gameQuery = game.giantbomb.SearchForGames(query, 1, 50);
            game.searchResults = game.gameQuery.Cast<GiantBomb.Api.Model.Game>().ToList();

            return View(game);
        }
        
        public ActionResult Landing()
        {
            return View();
        }

        public ActionResult ViewGame(string query)
        {
            ViewBag.data1 = query;
            ViewData["Query"] = query;

            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult Wishlist()
        {
            return View();
        }

        public ActionResult FrontPage()
        {
            return View();
        }
    }
}