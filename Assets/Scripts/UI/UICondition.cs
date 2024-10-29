using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//어떤 UI가 있는지 정의
public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition stamina;
    
    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }


}
