using UnityEngine;

namespace BaseScripts.Test
{
    public class BaseFast : MonoBehaviour
    {
        [SerializeField] private int score = 50;
        
        [SerializeField] private Sprite sprite;
        public int Score => score; 
        public Sprite Sprite => sprite;
    }
}
