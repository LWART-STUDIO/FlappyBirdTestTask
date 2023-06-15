using Game.Scripts.Audio;
using UnityEngine;

namespace Game.Scripts.Level
{
    public class ScoreSystem : MonoBehaviour
    {
        public static ScoreSystem instanse;

        private int _score;
        public int Score => _score;
        private void Awake()
        {
            _score = 0;
            if (instanse != null && instanse != this)
                Destroy(this);
            else
                instanse = this;
        }

        public void AddScore()
        {
            _score++;
            AudioManager.instanse.PlayPointSound();
        }
    }
}
