using System;
using Game.Scripts.UI;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private const string VOLUME = "Volume";
        public static AudioManager instanse;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioSource _jumpSound;
        [SerializeField] private AudioSource _dieSound;
        [SerializeField] private AudioSource _pointSound;

        private void Awake()
        {
            if (instanse != null && instanse != this)
                Destroy(this);
            else
                instanse = this;
        }

        private void Start()
        {
            UIPanelsControl.instanse.GetSettingsScreenPanel().UpdateSound += SoundChange;
        }

        private void SoundChange(int value)
        {
            if (value == 0)
                _audioMixer.SetFloat(VOLUME, -80f);
            else
                _audioMixer.SetFloat(VOLUME, 0f);
        }
        public void PlayJumpSound()
        {
            _jumpSound.PlayOneShot(_jumpSound.clip);
        }
        public void PlayDieSound()
        {
            _dieSound.PlayOneShot(_dieSound.clip);
        }
        public void PlayPointSound()
        {
            _pointSound.PlayOneShot(_pointSound.clip);
        }

        private void OnDestroy()
        {
            UIPanelsControl.instanse.GetSettingsScreenPanel().UpdateSound -= SoundChange;
        }
    }
}
