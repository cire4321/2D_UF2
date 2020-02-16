using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceKingController : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rb2d;
    private Animator anim;

    private float timer = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        anim.SetFloat("Speed", speed);

        if (timer < 0)
        {
            Invoke("Shoot", 0.2f);
            timer = 5f;
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speed, 0f);
    }

    private void Shoot()
    {
        anim.SetTrigger("Fire");
    }
}
