using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class SettingsScreenPanel : Panel
    {
        private const string DIFFICULTY = "Difficulty";
        private const string SOUND = "Sound";
        [SerializeField] private Image _soundImage;
        [SerializeField] private Image[] _difficultyImages;
        [SerializeField] private Sprite _soundOnSprite;
        [SerializeField] private Sprite _soundOffSprite;
        [SerializeField] private GameObject _hideObject;

        private UnityAction<int> _difficultyChange;
        public UnityAction<int>  DifficultyChange
        {
            get => _difficultyChange;
            set => _difficultyChange = value;
        }

        private UnityAction<int>  _updateSound;
        public UnityAction<int>  UpdateSound
        {
            get => _updateSound;
            set => _updateSound = value;
        }
        

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(DIFFICULTY)) 
                PlayerPrefs.SetInt(DIFFICULTY, 0);
            
            if (!PlayerPrefs.HasKey(SOUND)) 
                PlayerPrefs.SetInt(SOUND, 1);
            PlayerPrefs.Save();
            
        }

        private void Start()
        {
            SetDifficulty(PlayerPrefs.GetInt(DIFFICULTY));
            UpdateSoundIcon();
        }

        private void UpdateSoundIcon()
        {
            _soundImage.sprite = PlayerPrefs.GetInt(SOUND) == 0 
                ? _soundOffSprite : _soundOnSprite;
            _updateSound?.Invoke(PlayerPrefs.GetInt(SOUND));
        }
        public void SoundChange()
        {
            if (PlayerPrefs.GetInt(SOUND) == 0)
            {
                PlayerPrefs.SetInt(SOUND, 1);
                PlayerPrefs.Save();
            }
            else
            {
                PlayerPrefs.SetInt(SOUND, 0);
                PlayerPrefs.Save();
            }
            UpdateSoundIcon();
            
           
        }
        public void SetDifficulty(int index)
        {
            for (int i = 0; i < _difficultyImages.Length; i++)
            {
                if(i<=index)
                    _difficultyImages[i].color=Color.yellow;
                else
                    _difficultyImages[i].color = Color.black;
            }
            PlayerPrefs.SetInt(DIFFICULTY, index);
            PlayerPrefs.Save();
            _difficultyChange?.Invoke(index);
        }

        public override void Hide()
        {
            _hideObject.SetActive(false);
        }
        public override void Show()
        {
            _hideObject.SetActive(true);
        }

    }
}
