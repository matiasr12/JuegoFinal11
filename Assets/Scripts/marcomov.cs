using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class marcomov : MonoBehaviour
{
    [FormerlySerializedAs("Speed")] public float speed;
    [FormerlySerializedAs("JumpForce")] public float jumpForce;

    public GameObject BulletPrefab;
    private Rigidbody2D _rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    private int Health = 5;
    public AudioClip sound;

    


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
       Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
        
      
    }

    private void Update()
    {
        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-3.0f, 4.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(3.0f, 4.0f, 1.0f);
        Animator.SetBool("Correr",Horizontal!=0.0f);
        Animator.SetBool("Salto",Horizontal!=0.0f);
        
        
        
        
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           Shoot(); 
        }
        

       
    }

 

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 3.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.6f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

    }

    private void FixedUpdate()
    
    {
        _rigidbody2D.velocity = new Vector2(Horizontal * speed, _rigidbody2D.velocity.y);
    }

    public void Hit()
    {
      
        Health = Health - 1;
        if(Health == 0) Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Ayuda");
        }
    }
}

