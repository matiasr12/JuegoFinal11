using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class enemiMov : MonoBehaviour
{
    public GameObject marco;
    private float LastShoot;
    private int Health = 3;
    public AudioClip Sound;
    public Rigidbody2D rb2d;
    public GameObject BulletPrefab;

    public float velocity = 10.0f;
    // Start is called before the first frame update
   

    // Update is called once per frame
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.left * velocity;  
    }

    private void Shoot()
    {
        

    }
    void Update()
    {
    }
    public void Hit()
    {
        Health = Health - 1;
        if(Health == 0) Destroy(gameObject);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
