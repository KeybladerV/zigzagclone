using System.Collections.Generic;
using Components.Character;
using UnityEngine;

namespace Modules.Character
{
    public interface ICharacterController
    {
        Transform CharacterTransform { get; }
        int CurrentSkin { get; }

        void SetSkin(int skin);
        bool UnlockSkin(int skin);
        IReadOnlyList<CharacterSkinData> GetSkins();
        bool IsSkinUnlocked(int i);
    }
}