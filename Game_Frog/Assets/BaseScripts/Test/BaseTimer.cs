using UnityEngine;
using UnityEngine.UI;

namespace BaseScripts.Test
{
    public class BaseTimer : MonoBehaviour
    {
        [SerializeField] private int score = 50;
        [SerializeField] private Sprite sprite;
        [SerializeField] private Slider timerSlider;
        [SerializeField] private float timerDuration = 2.5f;
        
        private float _remainingTime;
        private bool _isRunning;
        private bool _playerInside;
        
        private GameController _gameController;
        
        public int Score => score;
        public Sprite Sprite => sprite;
        
        private void Start()
        {
            _gameController = FindObjectOfType<GameController>();
            timerSlider.gameObject.SetActive(false);
        }
        
        private void Update()
        {
            if (!_isRunning) return;
            
            _remainingTime -= Time.deltaTime;
            timerSlider.value = _remainingTime / timerDuration;
            
            if (_remainingTime <= 0f) 
                StopTimer();
        }
        
        public void StartTimer()
        {
            _remainingTime = timerDuration;
            _isRunning = true;
            timerSlider.gameObject.SetActive(true);
        }
        
        private void StopTimer()
        {
            _isRunning = false;
            timerSlider.value = 0f;
            timerSlider.gameObject.SetActive(false);
            
            if (_playerInside)
            {
                Debug.Log("Время вышло, и игрок всё ещё внутри!");
                _gameController.GameOver();
            }
            else
            {
                Debug.Log("Время вышло, но игрок уже ушёл.");
            }
            
            Destroy(gameObject);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null) 
                _playerInside = true;
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null) 
                _playerInside = false;
        }
    }
}
