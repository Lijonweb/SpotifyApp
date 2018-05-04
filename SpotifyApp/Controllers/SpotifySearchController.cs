using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpotifyApp.Utils.Enums;

namespace SpotifyApp.Controllers
{
    public class SpotifySearchController : Controller
    {
        public Repositories.ISpotifyApiConsumer _spotifyApiConsumer;

        public SpotifySearchController(Repositories.ISpotifyApiConsumer spotifyApiConsumer)
        {
            _spotifyApiConsumer = spotifyApiConsumer;
        }

        [HttpPost]
        public async Task<IActionResult> Search(ViewModels.SpotifyPostSearchVm submit)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            var result = await _spotifyApiConsumer.SearchAll(searchString: submit.SearchString, searchType: submit.searchType);

            ViewModels.SearchResultVm model = new ViewModels.SearchResultVm()
            {
                Artists = result?.Artists?.Items?.OrderByDescending(o => o.Popularity).Select(o => o.Name),
                Tracks = result?.Tracks?.Items?.OrderByDescending(o => o.Popularity).Select(o => o.Name),
                Albums = result?.albums?.Items?.OrderByDescending(o => o.Popularity).Select(o => o.Name),
            };

            return View(model);
        }
    }
}
