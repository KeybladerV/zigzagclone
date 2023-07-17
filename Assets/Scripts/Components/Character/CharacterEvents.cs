using Build1.PostMVC.Core.MVCS.Events;
using Components.Gem;

namespace Components.Character
{
    public static class CharacterEvents
    {
        public static readonly Event CharacterCreated = new Event(typeof(CharacterEvents), nameof(CharacterCreated));
        public static readonly Event CharacterFall = new Event(typeof(CharacterEvents), nameof(CharacterFall));
        public static readonly Event ResetCharacter = new Event(typeof(CharacterEvents), nameof(ResetCharacter));
        public static readonly Event CharacterEnteredPlatform = new Event(typeof(CharacterEvents), nameof(CharacterEnteredPlatform));
        public static readonly Event<GemView> CharacterCollectedGem = new Event<GemView>(typeof(CharacterEvents), nameof(CharacterCollectedGem));
        public static readonly Event<int> SkinChanged = new Event<int>(typeof(CharacterEvents), nameof(SkinChanged));
    }
}