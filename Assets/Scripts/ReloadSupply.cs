using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSupply : MonoBehaviour
{
    public CharacterSheet CharacterSheet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterSheet.ammo = CharacterSheet.numOfAmmo;
            Destroy(gameObject);
        }
    }
    

}
