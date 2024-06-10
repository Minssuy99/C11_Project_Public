using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D hand;
    public Texture2D original;
    public string clickSoundName; // 클릭 효과음 이름
    private SoundManager soundManager;

    void Start()
    {
        soundManager = SoundManager.instance;
    }

    public void OnMouseOver()
    {
        Cursor.SetCursor(hand, new Vector2(hand.width / 3, 0), CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(original, new Vector2(0, 0), CursorMode.Auto);
    }

    public void OnMouseDown()
    {
        PlayClickSound();

        void PlayClickSound()
        {
            if (soundManager != null && !string.IsNullOrEmpty(clickSoundName))
            {
                soundManager.PlaySE(clickSoundName);
            }
        }
    }
}
