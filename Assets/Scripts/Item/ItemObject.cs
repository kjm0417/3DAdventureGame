using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetIntereactPrompt();
    
    public void OnInteract();
}
//��ȣ�ۿ��� �� �ʿ��� ���
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetIntereactPrompt() //�����ֱ�
    {
        string str = $"{data.ItemName}\n{data.ItemDescription}";
        return str;
    }

    public void OnInteract()//������� ��
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.useitem?.Invoke();
        Destroy(gameObject);
    }
}
