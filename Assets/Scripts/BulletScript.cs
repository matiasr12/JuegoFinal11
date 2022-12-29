using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    public AudioClip Sound;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        marcomov marco = collision.collider.GetComponent<marcomov>();
        enemiMov Enemigo = collision.collider.GetComponent<enemiMov>();
        
        if(marco !=null)
        {
            marco.Hit();
        }

        if (Enemigo != null)
        {
            Enemigo.Hit();
        }

      
        DestroyBullet();
    }
}
