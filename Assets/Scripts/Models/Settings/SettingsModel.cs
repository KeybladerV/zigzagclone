using System;
using Newtonsoft.Json;

namespace Models.Settings
{
    [Serializable]
    public class SettingsModel : IReadOnlySettings
    {
        [JsonProperty("sound")] public bool SoundOn { get; set; }
        [JsonProperty("skin")] public int Skin { get; set; }

        [JsonIgnore] public bool AutoOn { get; set; }
    }
}