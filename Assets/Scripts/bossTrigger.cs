using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossTrigger : MonoBehaviour
{
    public Events events;
    public AudioSource audioData;
    public AudioClip doorClose;
    public AudioClip monsterSound;
    public GameObject lights;
    public Collider2D myCollider;
    public GameObject Sprite;
    public GameObject hallwayLights;
    public GameObject hallwayLights2;
    public MusicSwitcher musicSwitcher;
    public GameObject safeDoor;
    public GameObject light3;
    public GameObject bossHpBar;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {           
            sequence();
            Destroy(myCollider);
        }
    }

    public void sequence()
    {
        safeDoor.SetActive(true);
        hallwayLights.SetActive(false);
        hallwayLights2.SetActive(false);
        light3.SetActive(false);
        Sprite.SetActive(false);
        audioData.PlayOneShot(doorClose);
        Invoke("playSounds", 6);
        Invoke("onLights", 8);
        Invoke("delete", 11);
    }

    public void onLights()
    {
        Sprite.SetActive(true);
        lights.SetActive(true);
        musicSwitcher.SwitchMusic(1);
        bossHpBar.SetActive(true);
    }

    public void playSounds()
    {
        audioData.volume = 1;
        audioData.PlayOneShot(monsterSound);
    
    }

    public void delete()
    {
        Destroy(gameObject);
    }
}
