using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components.Character
{
    [Serializable]
    public class CharacterSkinData
    {
        public Color Color;
        public int Price;
    }
    
    [CreateAssetMenu(fileName = "CharacterSkins", menuName = "ZigZag/CharacterSkins", order = 0)]
    public class CharacterSkinsScriptableObject : ScriptableObject
    {
        [FormerlySerializedAs("_skins")] [SerializeField] public List<CharacterSkinData> Skins;
    }
}