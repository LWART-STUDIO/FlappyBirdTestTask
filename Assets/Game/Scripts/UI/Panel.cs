using UnityEngine;

namespace Game.Scripts.UI
{
    public class Panel : MonoBehaviour,IPanel
    {
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
