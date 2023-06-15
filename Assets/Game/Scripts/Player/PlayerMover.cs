using System;
using Game.Scripts.Audio;
using Game.Scripts.Level;
using UnityEngine;

namespace Game.Scripts.Player
{
    [RequireComponent(typeof(PlayerInput),typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _rotateSpeed = 1;
        [SerializeField] private GameObject _sprite;
        
        private PlayerInput _playerInput;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _birdRotation = Vector3.zero;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _playerInput.TouchScreen += Jump;
        }

        private void Update()
        {
            if(GameStateControl.instanse.CurrentGameState == GameState.Failed 
               || GameStateControl.instanse.CurrentGameState == GameState.Idle)
                return;
            RotatePlayer();
        }

        public void MakeStart()
        {
            _rigidbody2D.isKinematic = false;
            Jump();
        }

        private void Jump()
        {
            if(GameStateControl.instanse.CurrentGameState == GameState.Failed 
               || GameStateControl.instanse.CurrentGameState == GameState.Idle)
                return;
            _rigidbody2D.velocity = Vector2.up * _force;
            AudioManager.instanse.PlayJumpSound();
        }

        private void OnDisable()
        {
            _playerInput.TouchScreen -= Jump;
        }

        private void RotatePlayer()
        {
            float degreesToAdd = 0;
            if (_rigidbody2D.velocity.y > 0)
                degreesToAdd = 6 * _rotateSpeed;
            else if (_rigidbody2D.velocity.y < 0)
                degreesToAdd = -3 * _rotateSpeed;
            else
                return;
            _birdRotation = new Vector3(0, 0, Mathf.Clamp(_birdRotation.z + degreesToAdd, -90, 45));
            _sprite.transform.eulerAngles = _birdRotation;
        }
    }
}
