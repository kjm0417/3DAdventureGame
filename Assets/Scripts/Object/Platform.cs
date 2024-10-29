using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 startPos;

    private bool isRight;

    public float maxMovingDistance;
    public float movingSpeed;

    private void Start()
    {
        startPos = transform.position;
        isRight = true;
    }

    private void Update()
    {
        Moving();
    }

    void Moving()
    {
        // 오른쪽으로 움직여야 하면 x 값을 줄여야 함
        if (isRight)
        {
            transform.position = new Vector3(transform.position.x - movingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            if (startPos.x - transform.position.x >= maxMovingDistance)
            {
                isRight = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x + movingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x >= startPos.x)
            {
                isRight = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

}
