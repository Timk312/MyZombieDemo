using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossTrigger : MonoBehaviour
{
    public Events events;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }
}
