using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public float speed;
    private Transform playerTransform;

    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector2 direction = playerTransform.position - transform.position;
            direction.Normalize();

            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    void FindPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
}

