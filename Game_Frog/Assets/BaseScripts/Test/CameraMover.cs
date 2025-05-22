using UnityEngine;

namespace BaseScripts.Test
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private float ascendSpeed = 1f;
        [SerializeField] private float boostSpeed = 5f;
        [SerializeField] private float boostDuration = 0.5f;
        
        [HideInInspector] public bool gameStarted = false;
        
        private float _currentSpeed;
        private float _boostTimer = 0f;
        
        private void Start() => 
            _currentSpeed = ascendSpeed;
        
        private void Update()
        {
            if (!gameStarted) return;
            
            if (_boostTimer > 0f)
            {
                _boostTimer -= Time.deltaTime;
                if (_boostTimer <= 0f) 
                    _currentSpeed = ascendSpeed;
            }
            
            transform.position += Vector3.up * _currentSpeed * Time.deltaTime;
        }
        
        
        public void AddBoost()
        {
            _currentSpeed = boostSpeed;
            _boostTimer = boostDuration;
        }
        
        public float GetCameraTopY()
        {
            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            return transform.position.y + (height / 2f);
        }
    }
}