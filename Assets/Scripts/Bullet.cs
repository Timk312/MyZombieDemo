/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "enemy")
        {
            Events.Instance.IncreaseKillCount();
            zombieSheet.Instance.dead = true;
           // Destroy(collision.gameObject);
        }
      
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("enemy"))
        {
            // Check if the collided object has a zombieSheet component
            zombieSheet zombie = collision.gameObject.GetComponent<zombieSheet>();
            if (zombie != null)
            {
                // Notify the specific zombie instance that it should die
                zombie.Die();
            }

            // Optionally, you can still increase the kill count using your Events system
           // Events.Instance.IncreaseKillCount();
            //Debug.Log("Killcount ++");
        }
    }
}
