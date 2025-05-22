using UnityEngine;

namespace BaseScripts.Test
{
    public class BaseRotator : MonoBehaviour
    {
        [SerializeField] private int score = 50;
        [SerializeField] private float speed = 100f;

        [SerializeField] private Sprite sprite;
        public int Score => score;
        public Sprite Sprite => sprite;
        
        private void Update() => 
            transform.Rotate(new Vector3(0,0,speed * Time.deltaTime));
    }
}
