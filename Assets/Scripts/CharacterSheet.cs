using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
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

   void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
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
        }
    }
}