using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public static Events Instance;
    public GameObject lightsTurnOn;
    public GameObject lightsTurnOn2;
    public GameObject door;
    public int killCount;
    public int maxZombies;
    public MusicSwitcher musicSwitcher;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        killCount = 0;
    }
    public void Update()
    {
        if (killCount == 56)
        {
            lightsTurnOn.SetActive(true);
        }
        if (killCount == 60)
        {
            lightsTurnOn2.SetActive(true);
            Destroy(door);
        }
        if (killCount == maxZombies)
        {
            //SceneManager.LoadScene(0);
           // musicSwitcher.SwitchMusic(1);
            //killCount = 0;
        }
        
    }

    public void IncreaseKillCount()
    {
        killCount++;

    }

    public void startNewWave()
    {
        killCount = 51;
    }
}
