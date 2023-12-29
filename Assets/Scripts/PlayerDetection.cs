using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public CharacterSheet characterSheet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log("Zombie detected!");

            // Optionally, you can apply damage to the player or perform other actions
            characterSheet.loseHealth(1);

            // Get the zombieSheet component from the detected zombie
            zombieSheet zombie = other.GetComponent<zombieSheet>();
            if (zombie != null)
            {
                Debug.Log("Zombie found!");
                // Notify the specific zombie instance that it should die
                zombie.Die();
            }
        }
        if (other.CompareTag("boss"))
        {
            BossHp.Instance.TakeDamage(5);
        }
    }
}