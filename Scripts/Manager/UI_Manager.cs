using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject optionUI;
    public Animator optionUIAnimatorObject;
    public Slider bgmVolumeSlider;  // BGM 볼륨 조절 슬라이더
    public Slider effectVolumeSlider;  // 효과음 볼륨 조절 슬라이더


    void Start()
    {
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

    public void OnClickOptionButton()
    {
        bool isOpen = optionUIAnimatorObject.GetBool("isOpen");

        // isOpen 값을 반대로 변경
        optionUIAnimatorObject.SetBool("isOpen", !isOpen);
    }

        public void OnClickNewGameButton()
        {
            MySceneManager.instance.ChangeScene("SelectScene");
        }

        public void OnClickLoadSaveButton()
        {
             MySceneManager.instance.ChangeScene("LoadSaveScene");
        }

        public void OnClickMainScene()
        {
             MySceneManager.instance.ChangeScene("MainScene");
        }

        public void OnClickStartMenu()
        {
             MySceneManager.instance.ChangeScene("StartScene");
        }

        

}
