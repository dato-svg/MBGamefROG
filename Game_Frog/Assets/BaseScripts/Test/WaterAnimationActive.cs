using UnityEngine;

namespace BaseScripts.Test
{
    public class WaterAnimationActive : MonoBehaviour
    {
        [SerializeField] private WaterAnimatorController waterAnimatorController;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null) 
                waterAnimatorController.PlayAnimation();
        }
    }
}
