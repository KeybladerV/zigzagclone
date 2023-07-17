using System;
using Newtonsoft.Json;

namespace Models.Stats
{
    [Serializable]
    public class Statistics : IReadOnlyStatistics
    {
        [JsonProperty("bestScore")] public int BestScore { get; set; }
        [JsonProperty("gamesPlayed")] public int GamesPlayed { get; set; }
        [JsonProperty("gems")] public int Gems { get; set; }

        [JsonIgnore] public int Score { get; set; }
    }
}