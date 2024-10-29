using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 체력, 기력에 대한 계산식을 불러와서 적용시켜주는 곳
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
