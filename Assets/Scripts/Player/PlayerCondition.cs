using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾��� ü��, ��¿� ���� ������ �ҷ��ͼ� ��������ִ� ��
public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get {  return uiCondition.health; } }
    Condition stamina { get {  return uiCondition.stamina; } }

    void Update()
    {
        health.Subtract(2f * Time.deltaTime);

    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void StaminaUp(float amount)
    {
        stamina.Add(amount);
    }
    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Subtract(amount);
        return true;
    }

}
