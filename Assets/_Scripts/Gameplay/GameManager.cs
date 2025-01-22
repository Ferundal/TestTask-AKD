using _Scripts.Gameplay.Sound;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [Inject]
        private SoundManager _soundManager;

        private Collectible _currentCollectible = null;

        public Collectible CurrentCollectible
        {
            get => _currentCollectible;
            set
            {
                if (_currentCollectible == value || (_currentCollectible != null && value != null))
                {
                    return;
                }
                
                if (value == null)
                {
                    _soundManager.PlaySFX(_currentCollectible.pickUpSound);
                }
                else
                {
                    _soundManager.PlaySFX(value.pickUpSound);
                    value.gameObject.SetActive(false);
                }
                _currentCollectible = value;
            }
        }

        private void Start()
        {
            _soundManager.PlayGameMusic();
            _soundManager.SetMusicVolume(0.5f);
            _soundManager.SetSFXVolume(2f);
        }
    }
}