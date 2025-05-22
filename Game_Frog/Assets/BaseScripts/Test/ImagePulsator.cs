using UnityEngine;
using UnityEngine.UI;

namespace BaseScripts.Test
{
    public class ImagePulsator : MonoBehaviour
    {
        [SerializeField] private Image imageToPulse;
        [SerializeField] private float pulseSpeed = 1f;
        [SerializeField] private float minAlpha = 0f;
        [SerializeField] private float maxAlpha = 1f;

        private bool _isPulsing = false;
        private float _timer = 0f;

        private void Start() => 
            StopPulsing();
        
        
        private void Update()
        {
            if (_isPulsing && imageToPulse != null)
            {
                _timer += Time.deltaTime * pulseSpeed;

                float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(_timer) + 1f) / 2f);
                Color color = imageToPulse.color;
                color.a = alpha;
                imageToPulse.color = color;
            }
        }
        
        public void StartPulsing()
        {
            _isPulsing = true;
            imageToPulse.enabled = true;
        }
        
        public void StopPulsing()
        {
            _isPulsing = false;
            imageToPulse.enabled = false;
        }
    }
}