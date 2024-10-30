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
        // Rigidbody ������Ʈ�� ������
        rb = AttackWall.GetComponent<Rigidbody>();

        // Rigidbody�� ������ �߰���
        if (rb == null)
        {
            rb = AttackWall.AddComponent<Rigidbody>();
        }
    }

    public void OnPlayerCollision()
    {
        // Rigidbody�� AddForce�� ����� ���������� �̵�
        rb.AddForce(Vector3.left * speed, ForceMode.Impulse);

    }

}
