using System;
using Extensions;
using UnityEngine;

namespace Game.Scripts.Level
{
    public class PipeDestroyer : MonoBehaviour
    {
        [SerializeField] private LayerMask _pipeLayerMask;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (((1 << col.gameObject.layer) & _pipeLayerMask) != 0)
                col.gameObject.Recycle();
        }
    }
}
