using UnityEngine;
using Random = UnityEngine.Random;


namespace Game.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerSkinSelector : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int SkinIndex = Animator.StringToHash("SkinIndex");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            int rnd = Random.Range(0, 3);
            _animator.SetInteger(SkinIndex,rnd);
        }
    }
}
