using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supplyStation : MonoBehaviour
{
    public CharacterSheet CharacterSheet;
    public AudioSource audioData1;
    public AudioClip resupplySound;
    public bool available = true;
    private float timer = 25f;
    public GameObject countdownBox;
    public CountdownScript countdownscript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && available)
        {
            CharacterSheet.ammo = CharacterSheet.numOfAmmo;
            audioData1.PlayOneShot(resupplySound);
            available = false;
            countdownBox.SetActive(true);
            countdownscript.startCountdown();
            StartCoroutine(EnableAfterDelay());
        }
    }
    private IEnumerator EnableAfterDelay()
    {
        yield return new WaitForSeconds(timer);

        // Set the station as available again
        available = true;
    }
}

