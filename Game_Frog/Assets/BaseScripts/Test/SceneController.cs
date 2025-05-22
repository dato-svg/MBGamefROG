using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaseScripts.Test
{
    public class SceneController : MonoBehaviour
    {
        public void RestartScene() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
