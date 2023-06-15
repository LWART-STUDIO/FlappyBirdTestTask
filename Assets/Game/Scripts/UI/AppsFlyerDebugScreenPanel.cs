using System;
using Game.Scripts.SDK;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class AppsFlyerDebugScreenPanel : Panel
    {
        [SerializeField] private TMP_Text _debugText;


        private void Update()
        {
            _debugText.text = AppsFlyerInit.instanse.Logs;
        }
    }
}
