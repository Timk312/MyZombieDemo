using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthySupply : MonoBehaviour
{
    public CharacterSheet CharacterSheet;
    public AudioSource audioData;
    public AudioClip healthSupplySound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterSheet.health = CharacterSheet.numOfHearts;
            audioData.PlayOneShot(healthSupplySound);
            Destroy(gameObject);
        }
    }
}
