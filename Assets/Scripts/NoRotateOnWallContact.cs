using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotateOnWallContact : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
