using Build1.PostMVC.Unity.App.Mediation;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Components.Screens.Main
{
    public class SkinItemView : UnityViewDispatcher
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _priceText;
        
        [SerializeField] private Button _unlockButton;
        [SerializeField] private Button _applyButton;
        [SerializeField] private TMP_Text _applyText;
        
        public int SkinIndex { get; private set; }
        public UnityEvent OnUnlockButtonClick => _unlockButton.onClick;
        public UnityEvent OnApplyButtonClick => _applyButton.onClick;
        
        public void SetData(int index, int price, Color color, bool isUnlocked, bool isApplied)
        {
            SkinIndex = index;
            
            _image.color = color;
            _priceText.text = price.ToString();
            
            _unlockButton.gameObject.SetActive(!isUnlocked);
            _applyButton.gameObject.SetActive(isUnlocked && !isApplied);
            _applyText.gameObject.SetActive(isUnlocked && isApplied);
        }
    }
}