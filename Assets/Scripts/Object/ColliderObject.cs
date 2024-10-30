using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollidable
{
    public void OnPlayerCollision(); //�ݶ��̴��� �������� �߻�
}

public class ColliderObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollidable collidable = other.gameObject.GetComponent<ICollidable>();
        if (collidable != null)
        {
            collidable.OnPlayerCollision();
        }
    }
}
