using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.Assets;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Components.Character;
using Modules.Assets;
using Modules.Character;
using Modules.GameInput;
using Modules.Score;
using Screen = Modules.Screens.Screen;

namespace Components.Screens.Main
{
    public sealed class SkinsScreenMediator : Mediator
    {
        [Inject] public SkinsScreenView View { get; set; }
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public IScreensController ScreensController { get; set; }
        [Inject] public IGameInputController GameInputController { get; set; }
        [Inject] public ICharacterController CharacterController { get; set; }
        [Inject] public IScoreController ScoreController { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            EventMap.Map(View, View.OnCloseButtonClick, OnCloseButton);
            
            EventMap.Map(View, View.OnApplyButtonClick, OnApply);
            EventMap.Map(View, View.OnUnlockButtonClick, OnUnlock);
            
            View.SetGems(ScoreController.Statistics.Gems);

            var skins = CharacterController.GetSkins();
            for (int i = 0; i < skins.Count; i++)
            {
                var skinData = skins[i];
                View.AddSkinItem(i, skinData.Price, skinData.Color, CharacterController.IsSkinUnlocked(i), CharacterController.CurrentSkin == i);
            }
        }

        private void OnUnlock(SkinItemView obj)
        {
            if(CharacterController.IsSkinUnlocked(obj.SkinIndex))
                return;
            var skin = CharacterController.GetSkins()[obj.SkinIndex];
            if(ScoreController.Statistics.Gems < skin.Price)
                return;
            
            if (CharacterController.UnlockSkin(obj.SkinIndex))
            {
                if (ScoreController.WithdrawGems(skin.Price))
                {
                    View.SetGems(ScoreController.Statistics.Gems);
                    obj.SetData(obj.SkinIndex, skin.Price,
                        skin.Color, true, false);
                }
            }
        }

        private void OnApply(SkinItemView obj)
        {
            if (CharacterController.CurrentSkin == obj.SkinIndex || !CharacterController.IsSkinUnlocked(obj.SkinIndex))
                return;
            var oldSkin = CharacterController.GetSkins()[CharacterController.CurrentSkin];
            var currentSkin = CharacterController.GetSkins()[obj.SkinIndex];
            View.UpdateItemView(CharacterController.CurrentSkin, oldSkin.Price, oldSkin.Color, true, false);
            CharacterController.SetSkin(obj.SkinIndex);
            obj.SetData(obj.SkinIndex, currentSkin.Price,
                currentSkin.Color, true, true);
        }

        [Start]
        private void OnStart()
        {
            ToggleInputs(false);
        }

        [OnDestroy]
        private void OnDestroy()
        {
            EventMap.UnmapAll();
            ToggleInputs(true);
        }
        
        private void ToggleInputs(bool enable)
        {
            if(enable)
                GameInputController.UnblockInput(this);
            else
                GameInputController.BlockInput(this);
        }
        
        private void OnCloseButton()
        {
            ScreensController.Show(Screen.MainScreen);
        }
    }
}
