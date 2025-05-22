using System;
using Unity.VisualScripting;
using UnityEngine;

namespace BaseScripts.Test
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private AudioSource audioSource;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null)
            {
                Destroy(other.gameObject);
                audioSource.Play();
                gameController.GameOver();
            }
        }
    }
}
