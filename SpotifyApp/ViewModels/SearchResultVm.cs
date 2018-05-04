using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpotifyApp.ViewModels
{
    public class SearchResultVm
    {
        public IEnumerable<string> Tracks { get; set; }
        public IEnumerable<string> Artists { get; set; }
        public IEnumerable<string> Albums { get; set; }
    }
}
