using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Player
{
    [RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
    public class PlayerCollisionDetection : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        private UnityAction _collide;
        public UnityAction Collide
        {
            get => _collide;
            set => _collide = value;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & _layerMask) != 0)
                return;
            _collide?.Invoke();
        }
    }
}
