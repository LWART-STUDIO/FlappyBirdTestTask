using System;
using Game.Scripts.Audio;
using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Level
{
    public class LevelStateControl : MonoBehaviour
    {
        [SerializeField] private PlayerCollisionDetection _playerCollisionDetection;

        private void Awake()
        {
            _playerCollisionDetection.Collide += GameOver;
        }

        private void GameOver()
        {
            AudioManager.instanse.PlayDieSound();
            GameStateControl.instanse.MakeFailed();
        }
    }
}
