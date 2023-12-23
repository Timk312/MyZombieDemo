using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public CharacterSheet characterSheet;
    public AudioSource audioData2;
    public AudioClip zombieSound;

    private void Start()
    {
        audioData2.PlayOneShot(zombieSound);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            characterSheet.loseHealth(1);
            Destroy(gameObject);
        }

    }
}
