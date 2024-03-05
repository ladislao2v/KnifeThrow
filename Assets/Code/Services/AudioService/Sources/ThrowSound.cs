using System;
using Code.Services.ShootService;
using Code.UI.Gameplay;
using UnityEngine;
using Zenject;

namespace Code.Services.AudioService.Sources
{
    public class ThrowSound : SoundProvider
    {
        private IShootService _shootService;

        [Inject]
        private void Construct(IShootService shootService)
        {
            _shootService = shootService;
        }

        private void OnEnable()
        {
            _shootService.Shooted += Play;
        }

        private void OnDisable()
        {
            _shootService.Shooted -= Play;
        }

        protected override void PlayClip(AudioSource audioSource, AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}