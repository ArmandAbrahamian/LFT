using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiantBomb.Api;

namespace LFT.Web.ViewModel
{
    public class GameViewModel
    {
        public GiantBombRestClient giantbomb { get; set; }

        public IEnumerable<GiantBomb.Api.Model.Game> gameQuery { get; set; }
        public List<GiantBomb.Api.Model.Game> searchResults { get; set; }
    }
}