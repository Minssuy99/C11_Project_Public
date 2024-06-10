using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    public string name;  // 곡 이름
    public AudioClip clip;  // 곡
}

public class SoundManager : MonoBehaviour
{
    #region singleton
    static public SoundManager instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    #endregion singleton

    public Sound[] effectSounds;  // 효과음 클립들
    public Sound[] bgmSounds;  // BGM 오디오 클립들

    public AudioSource audioSourceBFM;  // BGM 재생기
    public AudioSource[] audioSourceEffects;

    public string[] playSoundName;  // 재생 중인 효과음 사운드 이름 배열

    public float bgmVolume = 1.0f;  // BGM 볼륨
    public float effectVolume = 1.0f;  // 효과음 볼륨

    void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }

    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (_name == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if (!audioSourceEffects[j].isPlaying)
                    {
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].volume = effectVolume;  // 효과음 볼륨 설정
                        audioSourceEffects[j].Play();
                        playSoundName[j] = effectSounds[i].name;
                        return;
                    }
                }
                Debug.Log("모든 가용 AudioSource가 사용 중입니다.");
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }

    public void PlayBGM(string _name)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (_name == bgmSounds[i].name)
            {
                audioSourceBFM.clip = bgmSounds[i].clip;
                audioSourceBFM.volume = bgmVolume;  // BGM 볼륨 설정
                audioSourceBFM.Play();
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }

    public void StopAllSE()
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if (playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                break;
            }
        }
        Debug.Log("재생 중인" + _name + "사운드가 없습니다. ");
    }

    // BGM 일시정지
    public void PauseBGM()
    {
        if (audioSourceBFM.isPlaying)
        {
            audioSourceBFM.Pause();
        }
    }

    // BGM 다시 재생
    public void ResumeBGM()
    {
        if (!audioSourceBFM.isPlaying)
        {
            audioSourceBFM.Play();
        }
    }

    // BGM 정지
    public void StopBGM()
    {
        if (audioSourceBFM.isPlaying)
        {
            audioSourceBFM.Stop();
        }
    }

    // BGM 볼륨 조절 함수
    public void OnBGMVolumeChange(float value)
    {
        bgmVolume = value;
        audioSourceBFM.volume = value;
    }

    // 효과음 볼륨 조절 함수
    public void OnEffectVolumeChange(float value)
    {
        effectVolume = value;
        foreach (AudioSource effectSource in audioSourceEffects)
        {
            effectSource.volume = value;
        }
    }
}