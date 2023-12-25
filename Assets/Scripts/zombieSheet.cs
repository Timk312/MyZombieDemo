/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSheet : MonoBehaviour
{
    public Animator animator;
    public bool dead = false;
    public static zombieSheet Instance;
    public Sprite deadZombie;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private static List<zombieSheet> allZombies = new List<zombieSheet>();
    private void Awake()
    {
        allZombies.Add(this);
    }
    private void OnDestroy()
    {
        allZombies.Remove(this);
    }

    public void Update()
    {
        if (dead == true)
        {
            Die();
        }
    }
    public void Die()
    {
        dead = true;
        Vector3 currentPosition = transform.position;
        currentPosition.z = 1;
        transform.position = currentPosition;
        animator.SetBool("dead", true);
        if (rb != null)
        {

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Destroy(rb);
        }
        Invoke("replace", 1);
    }

    public static void NotifyAllZombies()
    {
       foreach (var zombie in allZombies)
        {
            zombie.Die();
        }
    }

    private void replace()
    {
        DisableAllComponents();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = deadZombie;

    }

    private void DisableAllComponents()
    {
        Component[] allComponents = GetComponents<Component>();
        foreach (var component in allComponents)
        {
            if (component is Transform) continue;
            if (component is Behaviour behaviour) behaviour.enabled = false;
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSheet : MonoBehaviour
{
    public Animator animator;
    public bool dead = false;
    public Sprite deadZombie;

    private Collider2D zombieCollider; // Reference to the Collider component
    private bool hasPlayedDeadAnimation = false;

    private void Start()
    {
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