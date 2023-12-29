
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float pauseTime = 2f; // Time to pause in seconds
    public float bossPauseDuration = 3f; // Time to stay still before moving again
    public Animator animator;

    private bool isMovingRight = true;
    private float moveTimer = 0f; // Timer for moving
    private float pauseTimer = 0f; // Timer for pausing

    public bossShoot shoot;
    public CharacterSheet player;
    public float pushForce = 100f;
    public GameObject playerObject;
    public bossAI aiscript;

    public void Start()
    {
        aiscript = GetComponent<bossAI>();
    }

    public void Update()
    {
        
            if (pauseTimer > 0f)
            {
                animator.SetBool("bossAttack", true);
                // Boss is currently paused
                pauseTimer -= Time.deltaTime;
                if (pauseTimer <= 0f)
                {
                shoot.isTimerRunning = true;
                // Resume movement after pause
                isMovingRight = !isMovingRight;
                }
            }
            else
            {
                // Boss is moving
                MoveBoss();

                // Update the timer
                moveTimer += Time.deltaTime;

                // Check if it's time to change direction
                if (moveTimer >= pauseTime)
                {
                    // Start the pause
                    pauseTimer = bossPauseDuration;

                    // Reset the move timer
                    moveTimer = 0f;
                }
            }
    }

    void MoveBoss()
    {
        animator.SetBool("bossAttack", false);
        // Calculate the movement direction
        float direction = isMovingRight ? 1f : -1f;

        // Move the boss along the X-axis
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            player.loseHealth(1);

            // Calculate the direction from the collided object to the current object
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

            // Call pushBack on the player with the desired force
            player.pushBack(pushDirection, pushForce); // Adjust the force as needed
        }
    }

   public void halfHealth()
    {
        Debug.Log("half hp");
        aiscript.enabled = true;
    }

}
