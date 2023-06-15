using System;
using UnityEngine;

namespace Game.Scripts.Level
{
    public class ScoreTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            ScoreSystem.instanse.AddScore();
        }
    }
}
