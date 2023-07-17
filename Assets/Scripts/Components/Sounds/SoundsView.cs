using System;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using UnityEngine;

namespace Components.Sounds
{
    [Mediator(typeof(SoundsMediator))]
    public sealed class SoundsView : UnityView
    {
        [SerializeField] private AudioSource _audioSource;
        
        [SerializeField] private AudioClip _gemPickup;
        [SerializeField] private AudioClip _newPlatform;
        [SerializeField] private AudioClip _fall;
        [SerializeField] private AudioClip _screenShow;

        public void PlaySound(SoundType soundType)
        {
            var sound = soundType switch
            {
                SoundType.CharGemPickup => _gemPickup,
                SoundType.CharNewPlatform => _newPlatform,
                SoundType.CharFall => _fall,
                SoundType.ScreenShow => _screenShow,
                _ => throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null)
            };
            
            _audioSource.PlayOneShot(sound);
        }

        public void SetSound(bool isOn)
        {
            _audioSource.mute = !isOn;
        }
    }
}