using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public CharacterSheet characterSheet;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            characterSheet.loseHealth(1);
            Destroy(gameObject);
        }

    }
}
