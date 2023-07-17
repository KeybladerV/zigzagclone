using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.Character
{
    [Serializable]
    public sealed class SkinData
    {
        [JsonProperty("unlockedSkins")] public List<int> UnlockedSkinsArray { get; set; }
        [JsonProperty("currentSkin")] public int CurrentSkin { get; set; }
    }
}