using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollidable
{
    public void OnPlayerCollision(); //콜라이더가 겹쳤으면 발생
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
