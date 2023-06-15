using System;
using Game.Scripts.Level;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private void Update()
        {
            _text.text = ScoreSystem.instanse.Score.ToString();
        }
    }
}
