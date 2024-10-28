using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public PlayerController controller;
  
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }


}
