using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public int killCount;
    public int maxZombies;

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
}
