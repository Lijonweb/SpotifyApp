using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyApp.Repositories
{
    public interface ISpotifyApiConsumer
    {
        Task<Models.JSON.SpotifySearchResult> SearchAll(string searchString, Utils.Enums.SearchType searchType);
    }
}
