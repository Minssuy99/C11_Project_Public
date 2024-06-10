using UnityEngine;

public class MainSceneSoundManager : SoundManager
{
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
}
