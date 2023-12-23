using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSupply : MonoBehaviour
{
    public CharacterSheet CharacterSheet;
    public AudioSource audioData1;
    public AudioClip resupplySound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterSheet.ammo = CharacterSheet.numOfAmmo;
            audioData1.PlayOneShot(resupplySound);
            Destroy(gameObject);
        }
    }
    

}
