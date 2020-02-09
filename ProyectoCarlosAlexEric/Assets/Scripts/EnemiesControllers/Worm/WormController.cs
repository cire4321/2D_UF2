using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public float shootingRadius = 10f;
    public float forgetRadius = 10f;
    public float initHP = 100f;
    public float speed = 1f;
    public float shootingCooldown = 1f;

    public Transform player;


    [HideInInspector] public float distance;


    private bool moving2player = false;
    private float HP;
    private float speed_;
    private float timer;

    private Rigidbody2D rb2d;




    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        HP = initHP;
        timer = shootingCooldown;
    }
 
    void Update()
    {
        CheckState();

        if(moving2player)
        {
            Move();
        }
    }

    private void CheckState()
    {
        distance = Vector3.Distance(player.position, transform.position);


        if (player.position.x < transform.position.x)
        {
            speed_ = -speed;
        }
        if (player.position.x > transform.position.x)
        {
            speed_ = speed;
        }

        if (distance <= shootingRadius)
        {
            moving2player = false;
        }

        if (distance < forgetRadius && distance > shootingRadius)
        {
            moving2player = true;

        }

        if (distance >= forgetRadius)
        {
            moving2player = false;
        }

    }

    private void Move()
    {
        rb2d.velocity = new Vector2(speed_, rb2d.velocity.y);
    }

}
