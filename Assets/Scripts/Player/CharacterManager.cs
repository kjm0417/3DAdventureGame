    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager instance;

    public static CharacterManager Instance
    {   
        get
        {
            if (instance == null)
            {
                instance = new GameObject("CharacterManager").AddComponent<CharacterManager>(); //ĳ���͸Ŵ����� ������ ���ο� ���� ������Ʈ�� �߰��ؼ� ����
            }
            return instance; 
        }

    }
    private Player player;

    public Player Player
    {
        get { return player; }
        set { player = value; }
    }


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
