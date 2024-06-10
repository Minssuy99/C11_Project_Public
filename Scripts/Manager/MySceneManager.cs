using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MySceneManager : MonoBehaviour
{
    public CanvasGroup Fade_img;
    public float fadeDuration = 2;
    public GameObject Loading;
    public Text Loading_text;

    //public GameObject maleCharacterPrefab; // 프리팹 할당
    //public GameObject femaleCharacterPrefab; // 프리팹 할당

    private string selectedCharacter;

    #region singleton
    static public MySceneManager instance;
    private void Awake()
    {
        if (instance != null) {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    #endregion

    public void OnClickNewGameButton()
    {
        ChangeScene("SelectScene");
    }

    public void OnClickLoadSaveButton()
    {
        ChangeScene("LoadSaveScene");
    }

    public void OnClickMainScene()
    {
        ChangeScene("MainScene");
    }

    public void OnClickStartMenu()
    {
        ChangeScene("StartScene");
    }

    #region Scene Change Effect
    public void ChangeScene(string sceneName)
    {
        Fade_img.DOFade(1, fadeDuration).OnStart(() => { Fade_img.blocksRaycasts = true; })
            .OnComplete(() => { StartCoroutine("LoadScene", sceneName); });
    }

    IEnumerator LoadScene(string sceneName)
    {
        Loading.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        float past_time = 0;
        float percentage = 0;

        while (!async.isDone)
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true;
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            Loading_text.text = percentage.ToString("0") + "%";
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fade_img.DOFade(0, fadeDuration).OnStart(() => { Loading.SetActive(false); })
            .OnComplete(() => { Fade_img.blocksRaycasts = false; });

        //if (scene.name == "MainScene")
        //{
        //    SpawnSelectedCharacter(caracterChoice);
        //}
    }
    #endregion


    //캐릭터 스폰
    //private void SpawnSelectedCharacter()
    //{
    //    selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");

    //    if (selectedCharacter == "Male" && maleCharacterPrefab != null)
    //    {
    //        Instantiate(maleCharacterPrefab, Vector3.zero, Quaternion.identity);
    //    }
    //    else if (selectedCharacter == "Female" && femaleCharacterPrefab != null)
    //    {
    //        Instantiate(femaleCharacterPrefab, Vector3.zero, Quaternion.identity);
    //    }
    //}
}
