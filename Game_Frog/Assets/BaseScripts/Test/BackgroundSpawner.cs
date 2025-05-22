using UnityEngine;

namespace BaseScripts.Test
{
    public class BackgroundSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] backgroundPrefabs; 
        [SerializeField] private int startCount = 3;
        [SerializeField] private bool isHorizontal = true;

        private Vector3 _lastPosition;

        private void Start()
        {
            for (int i = 0; i < startCount; i++)
            {
                SpawnNext();
            }
        }
        
        public void SpawnNext()
        {
            int index = Random.Range(0, backgroundPrefabs.Length);
            GameObject prefab = backgroundPrefabs[index];

          
            GameObject newBackground = Instantiate(prefab, _lastPosition, Quaternion.identity);
            
            float size = 0f;
            if (isHorizontal)
                size = newBackground.GetComponent<SpriteRenderer>().bounds.size.x;
            else
                size = newBackground.GetComponent<SpriteRenderer>().bounds.size.y;

         
            if (isHorizontal)
                _lastPosition += new Vector3(size, 0f, 0f);
            else
                _lastPosition += new Vector3(0f, size, 0f);
        }
    }
}