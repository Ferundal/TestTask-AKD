using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay
{
    [RequireComponent(typeof(Renderer))]
    public class Collectible : MonoBehaviour
    {
        [HideInInspector]
        [Inject]
        public AudioClip pickUpSound;
        [Inject]
        private GameManager _gameManager;

        private void Awake()
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            Material material = renderer.material;
        }

        private void OnMouseDown()
        {
            if(_gameManager.CurrentCollectible != null) return;
            _gameManager.CurrentCollectible = this;
        }
    }
}
