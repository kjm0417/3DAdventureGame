using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingObj : MonoBehaviour, ICollidable
{
    public float jumpUp;

    public void OnPlayerCollision()
    {
        CharacterManager.Instance.Player.controller.rb.AddForce(Vector2.up * jumpUp, ForceMode.Impulse);
    }
}
