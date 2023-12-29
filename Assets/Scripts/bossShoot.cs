using System.Collections;
using UnityEngine;

public class bossShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to your bullet prefab
    public Transform firePoint;
    public float fireForce = 20f;
    public float fireCooldown = 4f; // Time between fires
    private float timer = 0f;
    public bool isTimerRunning = false;

    // Add this reference to get the player's position
    public GameObject player;

    private void Start()
    {
        Invoke("Fire", 7.4f);
    }

    void Update()
    {
        // Check if the timer is running
        if (isTimerRunning)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if it's time to fire
            if (timer >= fireCooldown)
            {
                // Trigger the fire method
                Fire();

                // Reset the timer
                timer = 0f;

                // Stop the timer until StartTimer is called again
                isTimerRunning = false;
            }
        }
    }

    void Fire()
    {
        if (bulletPrefab != null && firePoint != null && player != null)
        {
            // Spawn the bullet at the firePoint position and rotation
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Calculate the direction from the bullet to the player
            Vector3 playerPosition = player.transform.position;
            Vector3 direction = (playerPosition - bullet.transform.position).normalized;

            // Apply force to the bullet in the calculated direction
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.AddForce(direction * fireForce, ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogError("Bullet does not have a Rigidbody2D component!");
            }

            Debug.Log("Firing!");
        }
        else
        {
            Debug.LogError("Bullet prefab, fire point, or player reference is null!");
        }
    }
}
