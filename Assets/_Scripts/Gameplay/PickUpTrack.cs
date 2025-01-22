using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class PickUpTrack : MonoBehaviour
    {
        [Inject]
        private GameManager _gameManager;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            _gameManager.CurrentCollectible = null;
        }
    }
}
