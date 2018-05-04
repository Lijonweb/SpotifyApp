using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static SpotifyApp.Utils.Enums;

namespace SpotifyApp.Repositories
{

    public class SpotifyApiConsumer : ISpotifyApiConsumer
    {
        private readonly Models.Options.Credentials _options;
        private string accessToken;
        private long tokenExpiresIn;

        public SpotifyApiConsumer(IOptions<Models.Options.Credentials> options)
        {
            _options = options.Value;
        }

        public async Task<Models.JSON.SpotifySearchResult> SearchAll(string searchString, SearchType type)
        {
            if (string.IsNullOrEmpty(accessToken) || tokenExpiresIn <= 10)
                await SetAuthenticationToken();

            string query = $"?q={searchString}";
            switch (type)
            {
                case SearchType.Album:
                    query = $"{query}&type=album";
                    break;

                case SearchType.Artist:
                    query = $"{query}&type=artist";

                    break;

                case SearchType.Track:
                    query = $"{query}&type=track";

                    break;

                case SearchType.All:
                    query = $"{query}&type=track,album,artist";

                    break;
            }

            var requestUri = new Uri($"https://api.spotify.com/v1/search" + query);

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                using (var request = await httpClient.GetAsync(($"{requestUri}")))
                {
                    string response = await request.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<Models.JSON.SpotifySearchResult>(response);

                    return model;
                }
            }
        }

        private async Task SetAuthenticationToken()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_options.ClientId}:{_options.ClientSecret}")));

                var requestData = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("grant_type", "client_credentials") };
                var requestBody = new FormUrlEncodedContent(requestData);
                var requestUri = new Uri("https://accounts.spotify.com/api/token");

                using (var request = await httpClient.PostAsync(requestUri, requestBody))
                {
                    string response = await request.Content.ReadAsStringAsync();
                    Models.JSON.AuthenticationToken authenticationToken = JsonConvert.DeserializeObject<Models.JSON.AuthenticationToken>(response);
                    accessToken = authenticationToken.Access_token;
                    tokenExpiresIn = authenticationToken.Expires_in;
                }
            }
        }
    }
}
