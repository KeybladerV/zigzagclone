using System;

namespace Modules.HUD.World.Overlay
{
    public interface IHUDFadeOverlayView
    {
        HUDFadeOverlayState State { get; }
        bool IsInProcessOfFade { get; }
        
        void SetState(HUDFadeOverlayState state);
        void DoFade(float fadeValue, float duration, Action callback);
    }
}