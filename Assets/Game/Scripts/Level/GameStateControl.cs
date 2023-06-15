using System;
using System.Security.Cryptography;
using Game.Scripts.Player;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Level
{
    public class GameStateControl : MonoBehaviour
    {
        public static GameStateControl instanse;

        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PipeSpawner _pipeSpawner;
        
        private GameState _currentGameState = GameState.Idle;
        public GameState CurrentGameState => _currentGameState;

        public Action Started;
        public Action Failed;

        
        

        private void Awake()
        {
            if (instanse != null && instanse != this)
                Destroy(this);
            else
                instanse = this;
        }

        public void MakeStarted()
        {
            _currentGameState = GameState.Started;
            _playerMover.MakeStart();
            _pipeSpawner.MakeStart();
            Started?.Invoke();
        }

        public void MakeFailed()
        {
            _currentGameState = GameState.Failed;
            UIPanelsControl.instanse.GameOverScreenEnable();
            Failed?.Invoke();
        }

        public void MakeIdle()
        {
            _currentGameState = GameState.Idle;
        }

    }

    public enum GameState
    {
        Idle = 0,
        Started = 1,
        Failed = 2
        
    }
}
