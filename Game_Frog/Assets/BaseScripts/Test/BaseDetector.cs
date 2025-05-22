using BaseScripts.Test.WalletIfo;
using UnityEngine;

namespace BaseScripts.Test
{
    public class BaseDetector : MonoBehaviour
    {
        private ArrowController _arrowController;
        [SerializeField] private BaseSpeedChanger baseSpeedChanger;
        [SerializeField] private WalletUI walletUI;
        [SerializeField] private SpriteRenderer arrowVisual;
        [SerializeField] private BackgroundSpawner backgroundSpawner;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClip;
        
        private void Awake() => 
            _arrowController = GetComponentInChildren<ArrowController>();
         
        private void OnTriggerEnter2D(Collider2D other)
        {
            audioSource.PlayOneShot(audioClip);
            ResetRotation();
            backgroundSpawner.SpawnNext();
            _arrowController.hasLaunched = false;
            transform.position = other.transform.position;

            if (other.GetComponent<BaseStandard>() != null)
            {
                walletUI.AddScore(other.GetComponent<BaseStandard>().Score);
                arrowVisual.sprite = other.GetComponent<BaseStandard>().Sprite;
                _arrowController.hasRotate = false;
                baseSpeedChanger.StandardSpeedChange();
                transform.parent = null;
            }
            else if (other.GetComponent<BaseRotator>() != null)
            {
                walletUI.AddScore(other.GetComponent<BaseRotator>().Score);
                arrowVisual.sprite = other.GetComponent<BaseRotator>().Sprite;
                _arrowController.hasRotate = true;
                transform.parent = other.transform;
            }
            else if (other.GetComponent<BaseSlow>() != null)
            {
                other.GetComponent<ImagePulsator>().StartPulsing();
                walletUI.AddScore(other.GetComponent<BaseSlow>().Score);
                arrowVisual.sprite = other.GetComponent<BaseSlow>().Sprite;
                _arrowController.hasRotate = false;
                baseSpeedChanger.SlowSpeedChange();
                transform.parent = null;
            }
            else if (other.GetComponent<BaseFast>() != null)
            {
                other.GetComponent<ImagePulsator>().StartPulsing();
                walletUI.AddScore(other.GetComponent<BaseFast>().Score);
                arrowVisual.sprite = other.GetComponent<BaseFast>().Sprite;
                _arrowController.hasRotate = false;
                baseSpeedChanger.FastSpeedChange();
                transform.parent = null;
            }
            else if (other.GetComponent<BaseTimer>() != null)
            {
                walletUI.AddScore(other.GetComponent<BaseTimer>().Score);
                arrowVisual.sprite = other.GetComponent<BaseTimer>().Sprite;
                _arrowController.hasRotate = false;
                baseSpeedChanger.StandardSpeedChange();
                transform.parent = other.GetComponent<BaseTimer>().transform;
                other.GetComponent<BaseTimer>().StartTimer();
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            Destroy(other.gameObject,9);
            if (other.GetComponent<BaseTimer>() != null) 
                Destroy(other.gameObject);
        
            if (other.GetComponent<BaseSlow>() != null) 
                other.GetComponent<ImagePulsator>().StopPulsing();
        
            if (other.GetComponent<BaseFast>() != null) 
                other.GetComponent<ImagePulsator>().StopPulsing();
        }
        
        
        private void ResetRotation()
        {
            transform.GetChild(0).transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.identity;
        }
        
    }
}
