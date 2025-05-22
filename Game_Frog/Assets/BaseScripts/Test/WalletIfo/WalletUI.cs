using TMPro;
using UnityEngine;

namespace BaseScripts.Test.WalletIfo
{
    public class WalletUI : MonoBehaviour
    {
        private Wallet _wallet;
        [SerializeField] private TMP_Text textInGame;
        [SerializeField] private TMP_Text textInMenu;
        
        private void Start() => 
            _wallet = new Wallet();

        public void AddScore(int score)
        {
            _wallet.Score += score;
            textInGame.text = _wallet.Score.ToString();
            textInMenu.text = _wallet.Score.ToString();
        }
    }
}