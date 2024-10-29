using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType
{
    Health,
    Speed,
    Stemina
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "ItemData", menuName ="New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string ItemName;
    public string ItemDescription;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables; //어떤걸 올려줄걸지 정하기
}
