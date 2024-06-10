using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressEscForUseUI : MonoBehaviour
{
    bool cursorLocked = true;
    void Start()
    {
        SetCursorState(true);
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            SetCursorState(cursorLocked);
        }
    }
    void SetCursorState(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
