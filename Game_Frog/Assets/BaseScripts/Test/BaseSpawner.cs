using System.Collections;
using UnityEngine;

namespace BaseScripts.Test
{
    public class BaseSpawner : MonoBehaviour
    {
        [Header("Объекты для спавна")]
        [SerializeField] private GameObject[] spawnPrefabs;
        
        [Header("Настройки спавна")]
        [SerializeField] private float spawnInterval = 2f;
        [SerializeField] private float minX = -3f;
        [SerializeField] private float maxX = 3f;
        
        private float _currentY = 0f;
        
        private Coroutine _coroutine;
        
        private bool _isSpawning = false;
        
        private void Start() => 
            StartSpawn();
        
        private void StartSpawn()
        {
            StopSpawn();
            _isSpawning = true;
            _coroutine = StartCoroutine(SpawnObject());
        }
        
        public void StopSpawn()
        {
            if (_coroutine != null) 
                StopCoroutine(_coroutine);
            
            _coroutine = null;
        }
        
        
        private IEnumerator SpawnObject()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(spawnInterval);
                int randomIndex = Random.Range(0, spawnPrefabs.Length);
                GameObject prefabToSpawn = spawnPrefabs[randomIndex];
            
                float randomX = Random.Range(minX, maxX);
                Vector3 spawnPosition = new Vector3(randomX, _currentY, 0f);
            
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            
                _currentY += Random.Range(4.7f,8);
                
            }
            yield return null;
            // ReSharper disable once IteratorNeverReturns
        }
    }
}

