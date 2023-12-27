using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public CharacterSheet CharacterSheet;
    public AudioSource audioData;
    public AudioClip clip;
    public AudioClip outOfAmmoSound;
    [SerializeField] GameObject shotLight;
    public Animator animator;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
   

    Vector2 moveDirection;
    Vector2 mousePosition;

   void Start()
    {
      
    }
    void Update()
    {
     
      
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if (Input.GetMouseButtonDown(0) && CharacterSheet.ammo > 0 && Time.time >= nextFireTime)
            {
                weapon.Fire();
                animator.SetBool("Shoot", true);
                shotLight.SetActive(true);
                audioData.PlayOneShot(clip);
                CharacterSheet.loseAmmo(1);
                nextFireTime = Time.time + 1f / fireRate;
                Invoke("shoot", .25f);
                Invoke("delay", .075f);

            }
            if (Input.GetMouseButtonDown(0) && CharacterSheet.ammo == 0)
            {
                audioData.PlayOneShot(outOfAmmoSound);
            }
            moveDirection = new Vector2(moveX, moveY).normalized;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    private void FixedUpdate()
    {
        

            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        
    }

    private void delay()
    {
        shotLight.SetActive(false);
    }
    private void shoot()
    {
        animator.SetBool("Shoot", false);
    }
}
