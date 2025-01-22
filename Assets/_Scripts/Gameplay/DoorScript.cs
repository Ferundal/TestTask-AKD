using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class DoorScript : MonoBehaviour
    {

        public float moveDistance = 1.0f;
        public float moveSpeed = 2.0f;
        private bool _isMoving = false; // Флаг движения
        private Vector3 _targetPosition; // Целевая позиция

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _targetPosition = transform.position + new Vector3(moveDistance, 0, 0);
            _isMoving = true;
        }

        private void Update()
        {
            if (!_isMoving) return;
            transform.position =
                Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
                
            if (Vector3.Distance(transform.position, _targetPosition) < 0.01f)
            { 
                Destroy(gameObject);
            }
        }
    }
}
