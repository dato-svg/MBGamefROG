using UnityEngine;

namespace BaseScripts.Test
{
    public class BackGroundMusic : MonoBehaviour
    {
        private static BackGroundMusic _instance;
        
        [SerializeField] private AudioSource audioSource;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        
        
        private void Start() => 
            audioSource.Play();
    }
}
