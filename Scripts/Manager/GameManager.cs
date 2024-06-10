using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string MainSceneBGM;
    public string StartSceneBGM;
    public Animator UIObjectAnimator;
    [SerializeField] private string Start_Sound;
    public Slider bgmVolumeSlider;  // BGM 볼륨 조절 슬라이더
    public Slider effectVolumeSlider;  // 효과음 볼륨 조절 슬라이더

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayBGM(MainSceneBGM);

        SoundManager soundManager = SoundManager.instance;
        // BGM 슬라이더의 값이 변경될 때마다 OnBGMVolumeChange 함수 호출
        if (bgmVolumeSlider != null)
        {
            bgmVolumeSlider.onValueChanged.AddListener(soundManager.OnBGMVolumeChange);
            bgmVolumeSlider.value = soundManager.audioSourceBFM.volume;  // 슬라이더 초기값 설정
        }

        // 효과음 슬라이더의 값이 변경될 때마다 OnEffectVolumeChange 함수 호출
        if (effectVolumeSlider != null)
        {
            effectVolumeSlider.onValueChanged.AddListener(soundManager.OnEffectVolumeChange);
            // 모든 효과음 AudioSource의 초기 볼륨 설정
            if (soundManager.audioSourceEffects.Length > 0)
            {
                effectVolumeSlider.value = soundManager.audioSourceEffects[0].volume;
            }
        }
    }

    public void OnClickMainSceneToStartScene()
    {
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(Start_Sound);
        
        MySceneManager.instance.ChangeScene("StartScene");
        Invoke("DelayStartSceneBGM", 2f);
    }

    public void DelayStartSceneBGM()
    {
        SoundManager.instance.PlayBGM(StartSceneBGM);
    }

    public void OnClickMainSceneSetting()
    {
        bool isOpen = UIObjectAnimator.GetBool("isOpen");

        // isOpen 값을 반대로 변경
        UIObjectAnimator.SetBool("isOpen", !isOpen);
    }

}
