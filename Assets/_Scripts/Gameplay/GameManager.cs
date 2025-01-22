using _Scripts.Gameplay.Sound;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Transform playerPickedUpItemPosition;
        [Inject]
        private SoundManager _soundManager;

        private Collectible _currentCollectible = null;

        public Collectible CurrentCollectible
        {
            get => _currentCollectible;
            set
            {
                if(_currentCollectible != null)
                    return;
                PickUp(value);
                _currentCollectible = value;
            }
        }

        private void Start()
        {
            _soundManager.PlayGameMusic();
        }

        private void PickUp(Collectible collectible)
        {
            collectible.transform.SetParent(playerPickedUpItemPosition);
            collectible.transform.localPosition = Vector3.zero;
            collectible.transform.localRotation = Quaternion.identity;
            collectible.IsPickedUp = true;
            _soundManager.PlaySFX(collectible.pickUpSound);
            
        }
    }
}