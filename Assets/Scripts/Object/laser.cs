using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class laser : MonoBehaviour, ICollidable
{
    public GameObject AttackWall;
    private float speed = 30f;
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody 컴포넌트를 가져옴
        rb = AttackWall.GetComponent<Rigidbody>();

        // Rigidbody가 없으면 추가함
        if (rb == null)
        {
            rb = AttackWall.AddComponent<Rigidbody>();
        }
    }

    public void OnPlayerCollision()
    {
        // Rigidbody의 AddForce를 사용해 물리적으로 이동
        rb.AddForce(Vector3.left * speed, ForceMode.Impulse);

    }

}
