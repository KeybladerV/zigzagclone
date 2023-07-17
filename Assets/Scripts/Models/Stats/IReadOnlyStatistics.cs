namespace Models.Stats
{
    public interface IReadOnlyStatistics
    {
        int BestScore { get; }
        int GamesPlayed { get; }
        int Gems { get; }
        int Score { get; }
    }
}