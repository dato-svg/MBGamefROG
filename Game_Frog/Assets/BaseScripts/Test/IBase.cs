using UnityEngine;

namespace BaseScripts.Test
{
    public interface IBase
    {
        int Score { get; }
        Sprite Sprite { get; }
        void OnEnter(BaseDetector detector);
        void OnExit();
    }
}