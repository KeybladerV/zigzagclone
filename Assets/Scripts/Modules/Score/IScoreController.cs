using Models.Stats;

namespace Modules.Score
{
    public interface IScoreController
    {
        public IReadOnlyStatistics Statistics { get; }
        public bool WithdrawGems(int gems);
    }
}