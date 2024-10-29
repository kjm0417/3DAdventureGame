using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���⼭ �÷��̾� ���õ� ü��, ����, ��� ���� ���� ����
public class Condition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public Image uibar;

    void Start()
    {
        curValue = maxValue;
    }

    void Update()
    {
        uibar.fillAmount = GetPercentage();
    }

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Min(curValue - amount, maxValue);
    }

    private float GetPercentage()
    {
       return curValue / maxValue;
    }

}
