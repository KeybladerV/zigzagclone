namespace Models.Settings
{
    public interface IReadOnlySettings
    {
        bool SoundOn { get; set; }
        int Skin { get; set; }
        bool AutoOn { get; set; }
    }
}