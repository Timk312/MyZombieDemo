using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidBall : MonoBehaviour
{
    public GameObject acid;
    public Transform spawnPoint;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveZAxisTo(1f);
        Invoke("turnOn", .5f);
        Invoke("Explode", 3f);
    }

    void turnOn()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
    void MoveZAxisTo(float targetZ)
    {
        Vector3 newPosition = transform.position;
        newPosition.z = targetZ;
        transform.position = newPosition;
    }
    void Explode()
    {
        Destroy(rb);
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.z = 1.1f;
        GameObject bullet = Instantiate(acid, spawnPoint.position, spawnPoint.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterSheet.Instance.loseHpNoMelee(1);
        }
    }
}
