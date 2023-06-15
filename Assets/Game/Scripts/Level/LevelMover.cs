using System;
using UnityEngine;

namespace Game.Scripts.Level
{
    public class LevelMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private SpriteRenderer _floorRenderer;
        [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
        [SerializeField] private Transform _pipesParent;

        private Material _floorMaterial;
        private Material _backGroundMaterial;

        private void Awake()
        {
            _floorRenderer.sharedMaterial = new Material(_floorRenderer.material);
            _backgroundSpriteRenderer.sharedMaterial = new Material(_backgroundSpriteRenderer.material);
            _floorMaterial = _floorRenderer.sharedMaterial;
            _backGroundMaterial = _backgroundSpriteRenderer.sharedMaterial;
        }

        private void Update()
        {
            if(GameStateControl.instanse.CurrentGameState == GameState.Failed)
                return;
            MoveFloor();
            MoveBackground();
            MovePipes();
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        private void MovePipes()
        {
            float x = Time.deltaTime * _speed*6.5f;
            
            _pipesParent.position+=new Vector3(-x,0,0);
        }
        private void MoveFloor()
        {
            float x = Time.time * _speed;

            Vector2 offset = new Vector2(x, 0);
            
            _floorMaterial.SetTextureOffset("_MainTex",offset);
        }
        private void MoveBackground()
        {
            float x = Time.time * _speed/4;

            Vector2 offset = new Vector2(x, 0);
            
            _backGroundMaterial.SetTextureOffset("_MainTex",offset);
        }
    }
}
