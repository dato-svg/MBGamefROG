using UnityEngine;

namespace BaseScripts.Test
{
    public class CameraBoostByPlayerHeight : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private CameraMover cameraMover;
        [SerializeField] private float topThreshold = 1.5f;

        private void Update()
        {
            if (!cameraMover.gameStarted || player == null)
                return;

            var cameraTopY = cameraMover.GetCameraTopY();

            var distanceToTop = cameraTopY - player.position.y;

            if (distanceToTop <= topThreshold) 
                cameraMover.AddBoost();
        }
    }
}