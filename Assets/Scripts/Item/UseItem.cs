using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    PlayerCondition condition;
    PlayerController controller;


    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        condition = CharacterManager.Instance.Player.condition;

        CharacterManager.Instance.Player.useitem += useItem;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void useItem()
    {
        ItemData data = CharacterManager.Instance.Player.itemData;

        for(int i = 0; i<data.consumables.Length; i++)
        {
            switch(data.consumables[i].type)
            {
                case ConsumableType.Health:
                    condition.Heal(data.consumables[i].value);
                    break;
                case ConsumableType.Stemina:
                    condition.StaminaUp(data.consumables[i].value);
                    break;
                case ConsumableType.Speed:
                    StartCoroutine(ApplySpeedBoost(data.consumables[i].value));
                    break;
            }
        }
    }
    private IEnumerator ApplySpeedBoost(float duration)
    {
        controller.speed += 3f;  // 속도 증가
        yield return new WaitForSeconds(duration);  // `value`를 사용하여 지속 시간 설정
        controller.speed -= 3f;  // 효과 종료 후 속도 원래대로
    }

}
