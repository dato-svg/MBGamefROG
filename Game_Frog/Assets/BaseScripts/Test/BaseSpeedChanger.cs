using UnityEngine;

namespace BaseScripts.Test
{
    public class BaseSpeedChanger : MonoBehaviour
    {
       [SerializeField] private float slowSpeed = 35f;
       [SerializeField] private float fastSpeed = 95f;
       [SerializeField] private float standardSpeed = 70f;
       
       [SerializeField] private ArrowController arrowController;
       
       public float SlowSpeed => slowSpeed;
       public float FastSpeed => fastSpeed;
       public float StandardSpeed => standardSpeed;
       
       public void SlowSpeedChange() => 
           arrowController.RotationSpeed = slowSpeed;
       
       public void FastSpeedChange() => 
           arrowController.RotationSpeed = fastSpeed;
       
       public void StandardSpeedChange() => 
           arrowController.RotationSpeed = standardSpeed;
    }
}
