using UnityEngine;

namespace BaseScripts.Test
{
    public class BaseSlow : MonoBehaviour
    {
        [SerializeField] private int score = 100;
        
        [SerializeField] private Sprite sprite;
        public int Score => score;
        public Sprite Sprite => sprite;
    }
}
