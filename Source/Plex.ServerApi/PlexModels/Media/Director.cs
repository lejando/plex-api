namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class Director
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}
