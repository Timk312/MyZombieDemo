using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    public static BossHp Instance;
    public Image healthBar;
    public float healthAmount = 100;
    public float maxhp;
    public GameObject bossWave;
    public string enemyTag = "enemy";
    public bossScript boss;
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

    public void Start()
    {
        maxhp = healthAmount;
    }
    public void Update()
    {
        if (healthAmount<=0)
        {
            Destroy(bossWave);
            KillAllEnemies();
            SceneManager.LoadScene(3);
        }

        if(healthAmount<= maxhp / 2)
        {
            boss.halfHealth();
        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void KillAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
