/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;

    // Add a reference to the zombieSheet script
    private zombieSheet zombieSheet;

    void Start()
    {
        // Assuming zombieSheet script is on the same GameObject
        zombieSheet = GetComponent<zombieSheet>();
    }

    void Update()
    {
        // Check if the zombie is alive before moving towards the player
        if (player != null && !zombieSheet.dead)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiScript : MonoBehaviour
{
    public float speed;
    private float distance;
    private Transform playerTransform; // Use Transform instead of GameObject

    // Add a reference to the zombieSheet script
    private zombieSheet zombieSheet;

    void Start()
    {
        // Assuming zombieSheet script is on the same GameObject
        zombieSheet = GetComponent<zombieSheet>();

        // Find the player dynamically during runtime
        FindPlayer();
    }

    void Update()
    {
        // Check if the zombie is alive before moving towards the player
        if (playerTransform != null && !zombieSheet.dead)
        {
            distance = Vector2.Distance(transform.position, playerTransform.position);
            Vector2 direction = playerTransform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            // If the player is not found, try to find it again
            FindPlayer();
        }
    }

    // Method to find the player dynamically during runtime
    void FindPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
}

