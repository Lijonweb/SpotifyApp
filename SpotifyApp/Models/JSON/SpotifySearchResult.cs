using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SpotifyApp.Models.JSON
{
    public class SpotifySearchResult
    {
        [JsonProperty("artists")]
        public Artists Artists { get; set; }
        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("next")]
        public int Next { get; set; }
        [JsonProperty("previous")]
        public int Previous { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("albums")]
        public Albums albums { get; set; }

    }

    public class Albums
    {
        [JsonProperty("items")]
        public List<AlbumItems> Items { get; set; }
    }

    public class AlbumItems
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("popularity")]
        public int Popularity { get; set; }
    }

    public class Tracks
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("items")]
        public List<TrackItems> Items { get; set; }
    }

    public class TrackItems
    {
        [JsonProperty("album")]
        public Album Album { get; set; }
        [JsonProperty("external_urls")]
        public ExternalUrls External_urls { get; set; }
        [JsonProperty("followers")]
        public Followers Followers { get; set; }
        [JsonProperty("genres")]
        public string[] Genres { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("popularity")]
        public int Popularity { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("huriref")]
        public string Uri { get; set; }
    }

    public class Album
    {
        [JsonProperty("album_type")]
        public string Album_type { get; set; }
        [JsonProperty("available_markets")]
        public string[] Available_markets { get; set; }
        [JsonProperty("external_urls")]
        public ExternalUrls External_urls { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("release_date")]
        public string Release_date { get; set; }
        [JsonProperty("release_date_precision")]
        public string Release_date_precision { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }


    public class Images
    {
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("Width")]
        public int Width { get; set; }
    }

    public class AlbumArtists
    {
        [JsonProperty("external_urls")]
        public ExternalUrls External_urls { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class Artists
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("items")]
        public List<ArtistItems> Items { get; set; }
    }

    public class ArtistItems
    {
        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }
        [JsonProperty("followers")]
        public Followers Followers { get; set; }
        [JsonProperty("genres")]
        public string[] Genres { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("popularity")]
        public int Popularity { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class ExternalUrls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }

    public class Followers
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
