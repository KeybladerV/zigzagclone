using Components.Platform;
using Modules.Platforms.Impl;

namespace Modules.Platforms
{
    public interface IPlatformsController
    {
        int NormalPlatformCount { get; }
        
        PlatformView GetNormalPlatform();
        PlatformView GetBigPlatform();
        bool RollGemActive();
        
        PlatformDirection NextDirection();
        
        void Release(PlatformView platform);
    }
}