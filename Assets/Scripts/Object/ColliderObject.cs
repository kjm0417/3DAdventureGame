using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollidable
{
    public void OnPlayerCollision(); //�ݶ��̴��� �������� �߻�
}

public class ColliderObject : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        ICollidable collidable = collision.gameObject.GetComponent<ICollidable>();
        if (collidable != null)
        {
            collidable.OnPlayerCollision();
        }
    }
}
