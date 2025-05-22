using UnityEngine;

namespace BaseScripts.Test
{
    [RequireComponent(typeof(Animator))]
    public class WaterAnimatorController : MonoBehaviour
    {
        private static readonly int Jumped = Animator.StringToHash("Jumped");
        private Animator _animator;
        
        private void Awake() => 
            _animator = GetComponent<Animator>();
        
        public void PlayAnimation() =>
            _animator.SetTrigger(Jumped);
    }
}
