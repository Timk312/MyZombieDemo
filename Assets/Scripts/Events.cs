using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public static Events Instance;
    public int killCount;
    public int maxZombies;

    private void Awake()
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
        if (killCount == maxZombies)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void IncreaseKillCount()
    {
        killCount++;

    }
}
