using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunterController : MonoBehaviour
{
    public float initHP;
    public float speed;
    public float perceptionRadius;
    public float attackZoneRadius;
    public float attackTimer;
    public float damage;


    public GameObject explosion;


    private float HP;
    private float distance;
    private float speed_;
    private float timer;
    private bool moving, attacking;

    private Rigidbody2D rb2d;
    private GameObject player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed_ = speed;
        timer = attackTimer;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();

        if (timer >= 0)
        {
            timer -= Time.deltaTime;

        }

        if (moving)
        {
            anim.SetTrigger("walk");
            Move();
        }

        if(attacking && timer <= 0)
        {
            anim.SetTrigger("attack");
            Attack();
        }

        if(!moving && !attacking)
        {
            anim.SetTrigger("idle");
        }
        
    }

    private void CheckState()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);


        if(distance <= perceptionRadius && distance >= attackZoneRadius)
        {
            moving = true;
            attacking = false;
        }

        if (distance < attackZoneRadius)
        {
            moving = false;
            attacking = true;
        }

        if (distance > perceptionRadius)
        {
            moving = false;
            attacking = false;
        }
        else
        {
            if (player.transform.position.x < transform.position.x)
            {
                speed_ = -speed;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (player.transform.position.x > transform.position.x)
            {
                speed_ = speed;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

    }

    private void Move()
    {
        rb2d.velocity = new Vector2(speed_, rb2d.velocity.y);
    }

    private void Attack()
    {
        Debug.Log("attacking");
        player.GetComponent<FinnController>().TakeDamage(damage);
        timer = attackTimer;
    }

    private void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        GameManager.Instance.AddMuerte();
        Destroy(gameObject);
    }

    private void TakeDamage(float dmg)
    {
        Debug.Log("takedamage");
        HP -= dmg;

        if (HP <= 0)
        {
            anim.SetTrigger("die");
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackZoneRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, perceptionRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Attack"))
        {
            TakeDamage(collision.gameObject.GetComponent<PunchController>().damage);
        }
    }
}
