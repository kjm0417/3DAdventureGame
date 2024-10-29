using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetIntereactPrompt();
    
    public void OnInteract();
}
//상호작용할 때 필요한 기능
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetIntereactPrompt() //보여주기
    {
        string str = $"{data.ItemName}\n{data.ItemDescription}";
        return str;
    }

    public void OnInteract()//사용했을 때
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.useitem?.Invoke();
        Destroy(gameObject);
    }
}
