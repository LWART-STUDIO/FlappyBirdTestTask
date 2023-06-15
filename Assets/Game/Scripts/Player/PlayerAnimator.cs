using System;
using Game.Scripts.Level;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Start()
        {
            GameStateControl.instanse.Failed += DeactivateAnimator;
        }

        private void DeactivateAnimator()
        {
            _animator.enabled = false;
        }
    }
}
