using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue; // 현재값
    public float startValue; // 시작값
    public float maxValue; // 최대값
    public float passiveValue; // 변동값
    public Image uiBar;
    void Start()
    {
        // 저장 기능 추가시 startValue 대신 저장값
        curValue = startValue;
    }

    // Update is called once per frame
    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
    }
}
