using UnityEngine;

namespace Models.Platform
{
    public sealed class PlatformModel
    {
        public Vector3Int Position { get; private set; }
        public Vector3Int Scale { get; private set; }
        
        public PlatformModel(Vector3Int position, Vector3Int scale)
        {
            Position = position;
            Scale = scale;
        }
        
        public void SetPosition(Vector3Int position)
        {
            Position = position;
        }
        
        public void SetScale(Vector3Int scale)
        {
            Scale = scale;
        }

        public void Reset()
        {
            Position = Vector3Int.zero;
            Scale = Vector3Int.one;
        }
    }
}