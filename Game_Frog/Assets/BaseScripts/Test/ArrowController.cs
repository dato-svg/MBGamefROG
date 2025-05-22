using UnityEngine;

namespace BaseScripts.Test
{
    public class ArrowController : MonoBehaviour
    {
        [HideInInspector] public bool hasLaunched = false;
        [HideInInspector] public bool hasRotate = false;
        
        [SerializeField] private Transform arrowTransform;
        [SerializeField] private GameObject player;
        [SerializeField] private CameraMover cameraMover;
        [SerializeField] private float maxAngle = 40f;
        [SerializeField] private float rotationSpeed = 50f;
        [SerializeField] private float moveSpeed = 5f;
        
        private GameObject _arrowVisual;
        private float _currentAngle = 0f;
        private int _rotationDirection = 1;
        private Vector3 _launchDirection;
        
        public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
        
        private void Awake() => 
            _arrowVisual = player.transform.GetChild(0).GetChild(0).gameObject;
        
        private void Update()
        {
            _arrowVisual.SetActive(!hasLaunched);
            
            if (!hasLaunched)
            {
                if (!hasRotate) 
                    RotateArrow();
            
                if (UnityEngine.Input.GetMouseButtonDown(0))
                {
                    _launchDirection = arrowTransform.up.normalized;
                    
                    transform.parent.up = _launchDirection;
                    
                    cameraMover.gameStarted = true;
                    hasLaunched = true;
                    player.transform.parent = null;
                }
            }
            else
            {
                MoveCharacter();
            }
        }
        
        private void RotateArrow()
        {
            var rotationStep = rotationSpeed * Time.deltaTime * _rotationDirection;
            _currentAngle += rotationStep;
            
            if (Mathf.Abs(_currentAngle) >= maxAngle)
            {
                _rotationDirection *= -1; 
                _currentAngle = Mathf.Clamp(_currentAngle, -maxAngle, maxAngle);
            }
            
            arrowTransform.localRotation = Quaternion.Euler(0f, 0f, _currentAngle);
        }
        
        private void MoveCharacter() => 
            player.transform.position += _launchDirection * moveSpeed * Time.deltaTime;
    }
}
