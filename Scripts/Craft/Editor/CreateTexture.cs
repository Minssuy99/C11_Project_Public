using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class CreateTexture : EditorWindow
{
    public GameObject[] createList;

    [MenuItem("Editor/CreateTexture")]
    static void ShowWindow()
    {
        GetWindow(typeof(CreateTexture)).Show();
    }


    private void OnGUI()
    {
        GUILayout.Label("이미지를 생성할 게임오브젝트");

        ScriptableObject scriptableObj = this;
        SerializedObject serialObj = new SerializedObject(scriptableObj);
        SerializedProperty serialProp = serialObj.FindProperty("createList");

        EditorGUILayout.PropertyField(serialProp, true);
        serialObj.ApplyModifiedProperties();

        if (GUILayout.Button("이미지 생성")) Create();
    }

    public void Create()
    {
        for (int i = 0; i < createList.Length; i++)
        {
            Texture2D texture = AssetPreview.GetAssetPreview(createList[i]);
            Debug.Log(texture);
            byte[] texturebytes = texture.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + $"/SON/Sprite/{createList[i].name}.png", texturebytes);
        }

        //createList = null; //다하고 비우기
    }
}
