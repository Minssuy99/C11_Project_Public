using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterSelector : MonoBehaviour
{
    public GameObject maleCharacterPrefab;
    public GameObject femaleCharacterPrefab;
    public Button ManSelected;
    public Button WomanSelected;

    private string selectedCharacter;
    [SerializeField] private string Loading_Sound;
    [SerializeField] private string Start_Sound;
    [SerializeField] private string Warning_Sound;
    
    // 애니메이터 참조 변수 추가
    public Animator WarningTriggerAnimator;
    [SerializeField] private string WarningTrigger = "WarningTrigger"; // 트리거 이름

    public void SelectMaleCharacter()
    {
        selectedCharacter = "Male";
        TriggerCharacterAnimation(maleCharacterPrefab, true);
        TriggerCharacterAnimation(femaleCharacterPrefab, false);
        selectCharactorColorUI(ManSelected);
        CharacterManager.Instance.character = 1;
    }

    public void SelectFemaleCharacter()
    {
        selectedCharacter = "Female";
        TriggerCharacterAnimation(maleCharacterPrefab, false);
        TriggerCharacterAnimation(femaleCharacterPrefab, true);
        selectCharactorColorUI(WomanSelected);
        CharacterManager.Instance.character = 2;
    }

    private void TriggerCharacterAnimation(GameObject characterPrefab, bool isSelected)
    {
        Animator animator = characterPrefab.GetComponent<Animator>();
        if (animator != null)
        {
            // isSelected 값을 애니메이터에 전달
            animator.SetBool("isSelected", isSelected);
        }
    }

    public void StartGame()
    {
        if (selectedCharacter != null)
        {
            SoundManager.instance.PlaySE(Start_Sound);
            PlayerPrefs.SetString("SelectedCharacter", selectedCharacter);
            MySceneManager.instance.OnClickMainScene();
            Invoke("PlayLoadingSound", 1f);
            SoundManager.instance.StopBGM();

        }
        else
        {
            WarningTriggerAnimator.SetTrigger(WarningTrigger);
            SoundManager.instance.PlaySE(Warning_Sound);
        }
    }
    private void PlayLoadingSound()
    {
            SoundManager.instance.PlaySE(Loading_Sound);
    }    
    public void BackStartScene()
    {
        MySceneManager.instance.OnClickStartMenu();
    }

    private void selectCharactorColorUI(Button button)
    {
        void changedColor(Button button)
        {
            Image image = button.GetComponent<Image>();
            image.color = new Color32(255, 255, 255, 80);
        }

        void OriginalColor(Button button)
        {
            Image image = button.GetComponent<Image>();
            image.color = new Color32(255, 255, 255, 0);
        }

        if (selectedCharacter == "Male")
        {
            changedColor(ManSelected);
            OriginalColor(WomanSelected);
        }
        else if (selectedCharacter == "Female")
        {
            changedColor(WomanSelected);
            OriginalColor(ManSelected);
        }
        else
        {
            OriginalColor(ManSelected);
            OriginalColor(WomanSelected);
        }
    }
}
