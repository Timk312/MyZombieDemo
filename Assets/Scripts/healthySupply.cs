using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthySupply : MonoBehaviour
{
    public CharacterSheet CharacterSheet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterSheet.health = CharacterSheet.numOfHearts;
            Destroy(gameObject);
        }
    }
}
