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
        if (collision.gameObject.CompareTag("Player"))
        {
            characterSheet.loseHealth(1);
            Debug.Log("Collision detected!");

            // Check if the collided object has a zombieSheet component
            zombieSheet zombie = collision.gameObject.GetComponent<zombieSheet>();
            if (zombie != null)
            {
                Debug.Log("Zombie found!");
                // Notify the specific zombie instance that it should die
                zombie.Die();
            }

            // Optionally, you can still increase the kill count using your Events system
            Events.Instance.IncreaseKillCount();
            Debug.Log("Killcount ++");
        }
    }
}