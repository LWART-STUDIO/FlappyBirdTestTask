using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts.UI
{
    public class SettingsPanelClose : MonoBehaviour,IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            UIPanelsControl.instanse.SettingsScreenDisable();
        }
    }
}
