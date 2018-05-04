using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyApp.Models.JSON
{
    public class AuthenticationToken
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public long Expires_in { get; set; }
    }
}
