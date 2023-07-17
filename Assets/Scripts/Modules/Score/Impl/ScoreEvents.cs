using Build1.PostMVC.Core.MVCS.Events;
using Models.Stats;

namespace Modules.Score.Impl
{
    public static class ScoreEvents
    {
        public static readonly Event<IReadOnlyStatistics> ScoreUpdated = new Event<IReadOnlyStatistics>(typeof(ScoreEvents), nameof(ScoreUpdated));
    }
}