using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSheet : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int ammo;
    public int numOfAmmo;

    public Image[] bullets;
    public Sprite fullAmmo;
    public Sprite emptyAmmo;

    public Animator animator;
    public PlayerController playerControl;
    public static CharacterSheet Instance;

    public void Awake()
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

    void Update()
    {

        //death
        if (health == 0)
        {
            SceneManager.LoadScene(1);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        for (int i = 0; i < bullets.Length; i++)
        {
            if (i < ammo)
            {
                bullets[i].sprite = fullAmmo;
            }
            else
            {
                bullets[i].sprite = emptyAmmo;
            }
            if (i < numOfAmmo)
            {
                bullets[i].enabled = true;
            }
            else
            {
                bullets[i].enabled = false;
            }
        }
    }

    public void loseAmmo(int x)
    {
        if(ammo>0)
        ammo -= x;
    }

    public void loseHealth(int x)
    {
        if (health > 0)
        {
            health -= x;
            animator.SetBool("getHit", true);
            Invoke("getingHit", .50f);
        }
    }

    public void loseHpNoMelee(int x)
    {
        if (health > 0)
        {
            health -= x;
        }
    }

    private void getingHit()
    {
        animator.SetBool("getHit", false);
    }
    public void pushBack(Vector2 pushDirection, float pushForce)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            playerControl.enabled = false;
            // Apply force to push the object back
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            Invoke("resumeControl", .5f);
        }
        
    }
    public void resumeControl()
    {
        playerControl.enabled = true;
    }
}
