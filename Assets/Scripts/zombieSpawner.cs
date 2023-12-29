using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    void Start()
    {
        // Start spawning zombies every 10 seconds, repeating indefinitely
        InvokeRepeating("SpawnZombies1", 10f, 10f);
        InvokeRepeating("SpawnZombies2", 5f, 10f);
    }

    // Coroutine for spawning zombies
    void SpawnZombies1()
    {
        Instantiate(zombie, spawnPoint.position, spawnPoint.rotation);
        Instantiate(zombie, spawnPoint2.position, spawnPoint2.rotation);
    }

    void SpawnZombies2()
    {
        Instantiate(zombie, spawnPoint4.position, spawnPoint4.rotation);
        Instantiate(zombie, spawnPoint5.position, spawnPoint5.rotation);
    }

}
