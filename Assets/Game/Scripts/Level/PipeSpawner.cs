using Extensions;
using UnityEngine;

namespace Game.Scripts.Level
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _pipePrefabs;
        [SerializeField] private float _timeMin = 1f;
        [SerializeField] private float _timeMax = 2f;
        [SerializeField] private Transform _pipeParent;
        private int _difficultValue=0;
        
        private GameObject _pipe;

        public void SetDifficultValue(int value)
        {
            _difficultValue = value;
        }
        public void MakeStart()
        {
            _pipe = _pipePrefabs[_difficultValue];
            Spawn();
        }
        private void Spawn()
        {
            if (GameStateControl.instanse.CurrentGameState == GameState.Started)
            {
                //random y position
                float y = Random.Range(-0.3f, 2.5f);
                GameObject go =_pipe.Spawn(_pipeParent,this.transform.localPosition + new Vector3(0, y, 0), Quaternion.identity);
            }
            Invoke("Spawn", Random.Range(_timeMin, _timeMax));
        }
    }
}
