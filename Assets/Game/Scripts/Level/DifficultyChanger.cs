using System;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Level
{
    public class DifficultyChanger : MonoBehaviour
    {
        private const string DIFFICULTY = "Difficulty";
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private Sprite _backgroundDay;
        [SerializeField] private Sprite _backgroundNight;
        [SerializeField] private LevelMover _levelMover;
        [SerializeField] private PipeSpawner _pipeSpawner;
        
        private void Start()
        {
            UIPanelsControl.instanse.GetSettingsScreenPanel().DifficultyChange += ChangeDifficulty;
            ChangeDifficulty(PlayerPrefs.GetInt(DIFFICULTY));
        }

        private void ChangeDifficulty(int value)
        {
            switch (value)
            {
                case 0:
                    _background.sprite = _backgroundDay;
                    _levelMover.SetSpeed(0.4f);
                    
                    break;
                case 1:
                    _background.sprite = _backgroundNight;
                    _levelMover.SetSpeed(0.8f);
                    break;
                case 2:
                    _background.sprite = _backgroundNight;
                    _levelMover.SetSpeed(0.8f);
                    break;

            }
            _pipeSpawner.SetDifficultValue(value);
        }

        private void OnDestroy()
        {
            UIPanelsControl.instanse.GetSettingsScreenPanel().DifficultyChange -= ChangeDifficulty;
        }
    }
}
