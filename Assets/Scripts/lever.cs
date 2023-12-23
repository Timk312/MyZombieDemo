using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public GameObject door;
    public GameObject zombie;
    public AudioSource audioData;
    public AudioClip doorOpen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioData.PlayOneShot(doorOpen);
            Destroy(door);
            zombie.SetActive(true);
        }
    }
}
