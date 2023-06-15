using Game.Scripts.Level;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts.UI
{
    public class StartScreen : MonoBehaviour,IPointerClickHandler
    {

        public void OnPointerClick(PointerEventData eventData)
        {
            UIPanelsControl.instanse.StartScreenDisable();
            GameStateControl.instanse.MakeStarted();
        }
    }
}
