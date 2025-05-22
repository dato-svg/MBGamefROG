using System;
using UnityEngine;

namespace BaseScripts.Test
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private BaseSpawner spawner;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject startGamePanel;

        [SerializeField] private GameObject player;
        [SerializeField] private new GameObject camera;

        
        private void Start()
        {
            gameOverPanel.SetActive(false);
            startGamePanel.SetActive(true);
            player.SetActive(false);
            camera.SetActive(false);
        }

        public void GameOver()
        {
            spawner.StopSpawn();
            camera.GetComponent<CameraMover>().enabled = false;
            gameOverPanel.SetActive(true);
        }

        public void StartGame()
        {
            startGamePanel.SetActive(false);
            gameOverPanel.SetActive(false);
            player.SetActive(true);
            camera.SetActive(true);
        }
        
    }
}
