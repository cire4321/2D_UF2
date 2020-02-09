using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float timer;

    public WormController worm;

    private Rigidbody2D rb2d;     

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer > 0)
        {
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);

            pos += transform.rotation * velocity;

            transform.position = pos;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
