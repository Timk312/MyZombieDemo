using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSheet : MonoBehaviour
{
    public Animator animator;
    public bool dead = false;
    public Sprite deadZombie;
    private AudioSource audioSource;

    private Collider2D zombieCollider; // Reference to the Collider component
    private bool hasPlayedDeadAnimation = false;

    void Start()
    {
      
        audioSource = GetComponent<AudioSource>();
        // Assuming you have the animator component attached to the same GameObject
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Get the Collider component
        zombieCollider = GetComponent<Collider2D>();
    }

    public void Die()
    {
        Events.Instance.IncreaseKillCount();
        Debug.Log("Killcount ++");
        if (dead || hasPlayedDeadAnimation)
        {
            Debug.Log("Already dead or animation played");
            return;
        }

        // Disable the collider
        if (zombieCollider != null)
        {
            zombieCollider.enabled = false;
        }

        // Set the zombie's position explicitly to ensure z is 1
        Vector3 newPosition = transform.position;
        newPosition.z = 1f;
        transform.position = newPosition;
        DisableAudioSourceComponent();
        dead = true;

        // Set the dead animation trigger
        animator.SetTrigger("dead");
        hasPlayedDeadAnimation = true;


    }

    // Called by an animation event at the end of the "dead" animation
    public void OnDeadAnimationEnd()
    {
        Debug.Log("OnDeadAnimationEnd called");

        // Remove the Rigidbody component if it exists
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Destroy(rb);
        }

        // Set the sprite to the deadZombie sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = deadZombie;
        }


        // Disable the Animator to keep the deadZombie sprite in place
        if (animator != null)
        {
            animator.enabled = false;
        }

        // Disable unnecessary components (colliders, scripts, etc.)
        DisableAllComponents();
    }

    void DisableAudioSourceComponent()
    {
        // Check if the AudioSource component exists
        if (audioSource != null)
        {
            // Disable the AudioSource component
            audioSource.enabled = false;

            // Alternatively, you can stop the audio playback
            // audioSource.Stop();
        }
    }
    private void DisableAllComponents()
    {
        // Disable all components except Transform
        Component[] allComponents = GetComponents<Component>();
        foreach (var component in allComponents)
        {
            if (component is Transform || component is SpriteRenderer) continue;
            if (component is Behaviour behaviour) behaviour.enabled = false;
        }
    }
}