using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public float shootingRadius = 10f;
    public float forgetRadius = 10f;
    public float initHP = 1f;
    public float speed = 1f;
    public float shootingCooldown = 1f;

    public Transform player;
    public BSpawnerController gun;
    public GameObject explosion;


    [HideInInspector] public float distance;
    [HideInInspector]public Animator anim;


    private bool moving2player = false;
    private float HP;
    private float speed_;
    private float timer;

    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        if (HP <= 0)
        {
            anim.SetTrigger("die");
        }

        if (player.position.x < transform.position.x)
        {
            speed_ = -speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (player.position.x > transform.position.x)
        {
            speed_ = speed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (distance <= shootingRadius)
        {
            moving2player = false;
            anim.SetTrigger("attacking");
        }

        if (distance < forgetRadius && distance > shootingRadius)
        {
            moving2player = true;
            anim.SetTrigger("moving");
        }

        if (distance >= forgetRadius)
        {
            moving2player = false;
            anim.SetTrigger("idle");
        }

    }

    private void Move()
    {
        rb2d.velocity = new Vector2(speed_, rb2d.velocity.y);
    }

    private void Shoot()
    {
        gun.Shoot();
    }

    private void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        GameManager.Instance.AddMuerte();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            float dmg = collision.gameObject.GetComponent<PunchController>().damage;

            TakeDamage(dmg);

        }
    }

    private void TakeDamage(float dmg)
    {
        //HP -= dmg;
        //Debug.Log(dmg);
        anim.SetTrigger("die");
    }

}
