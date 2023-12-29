/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public float speed;
    private float distance;
    private Transform playerTransform; // Use Transform instead of GameObject

    void Start()
    {
        // Find the player dynamically during runtime
        FindPlayer();
    }

    void Update()
    {
            distance = Vector2.Distance(transform.position, playerTransform.position);
            Vector2 direction = playerTransform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    // Method to find the player dynamically during runtime
    void FindPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
}
*/

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

