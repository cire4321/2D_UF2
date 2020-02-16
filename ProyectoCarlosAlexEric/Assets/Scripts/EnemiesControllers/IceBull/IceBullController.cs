using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullController : MonoBehaviour
{
    public float runSpeed;
    public float walkSpeed;
    public float initHP;
    public float perceptionRadius;
    public float attackRadius;

    public Collider2D wallTrigger;
    public GameObject player;
    public BullWallCollider wallCollider;

    private float HP;
    private float speed;
<<<<<<< HEAD
    private float actualSpeed;
    private float breakTimer;
=======
>>>>>>> 1ab08c5f6def9563fda40831213bf074edbe5041
    private float distance;
    private float lastSpeed;
    private bool moving;
    private bool running;
<<<<<<< HEAD
    private bool carrerilla;
=======
>>>>>>> 1ab08c5f6def9563fda40831213bf074edbe5041
    private bool vulnerable; //al estar vulnerable, si le atacas ejecutara la animacion de recibir daño

    private Rigidbody2D rb2d;
    private Animator anim;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
<<<<<<< HEAD
        SetIdleVulnerable();
=======
        HP = initHP;
>>>>>>> 1ab08c5f6def9563fda40831213bf074edbe5041
    }

    private void Update()
    {
<<<<<<< HEAD
        SetSpeed();
        CheckDistance();
        Move();
=======
        CheckState();
        
        if(moving)
        {
            Walk();
        }

        if(running)
        {
            Run();
            if(wallCollider.GetComponent<BullWallCollider>().Impact())
            {
                Impact();
                if(vulnerable && HP > 0)
                {
                    
                }
            }
            else
            {
                vulnerable = false;
            }
        }

        if(!moving && !running)
        {
        }
        
>>>>>>> 1ab08c5f6def9563fda40831213bf074edbe5041
    }

    private void CheckState()
    {

<<<<<<< HEAD
        if (distance <= attackRadius)
        {
            anim.SetTrigger("run");
        }

        if (distance < perceptionRadius && distance > attackRadius)
        {
            anim.SetTrigger("walk");
=======
        if (distance <= perceptionRadius && distance >= attackRadius)
        {
            speed = walkSpeed;
            moving = true;
            running = false;
>>>>>>> 1ab08c5f6def9563fda40831213bf074edbe5041
        }

        if (distance >= perceptionRadius)
        {
<<<<<<< HEAD
            anim.SetTrigger("idle");
        }

        anim.SetFloat("hp", HP);
        anim.SetBool("vulnerable", vulnerable);

    }

    private void SetSpeed()
    {

            if (moving)
            {
                actualSpeed = walkSpeed;
            }
=======
            speed = runSpeed;
            moving = false;
            running = true;
        }

        if (distance > perceptionRadius)
        {
            speed = 0;
            moving = false;
            running = false;
            anim.SetTrigger("idle");
        }
        else
        {

                if (player.transform.position.x < transform.position.x)
                {
                    if (moving)
                    {
                        speed = -walkSpeed;
                    }
                    if (running)
                    {
                        speed = -runSpeed;
                    }
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if (player.transform.position.x > transform.position.x)
                {
                    if (moving)
                    {
                        speed = walkSpeed;
                    }
                    if (running)
                    {
                        speed = runSpeed;
                    }
                    transform.localScale = new Vector3(1, 1, 1);
                }
                lastSpeed = speed;

        }
>>>>>>> 1ab08c5f6def9563fda40831213bf074edbe5041

            if (carrerilla)
            {
                actualSpeed = 0f;
            }

            if (running)
            {
                actualSpeed = runSpeed;
            }

            if (vulnerable)
            {
                actualSpeed = 0f;
            }


        actualSpeed *= CheckDistance();

        speed = actualSpeed;
    }

<<<<<<< HEAD
    private void Move()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
=======
    private void Idle()
    {
        anim.SetTrigger("idle");
    }

    private void Walk()
    {
        anim.SetTrigger("walk");
>>>>>>> 1ab08c5f6def9563fda40831213bf074edbe5041
    }

    private float CheckDistance()
    {
<<<<<<< HEAD
        distance = Vector3.Distance(player.transform.position, transform.position);


        if (player.transform.position.x < transform.position.x && distance < perceptionRadius)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            return -1f;
        }

        if (player.transform.position.x > transform.position.x && distance < perceptionRadius)
        {
            transform.localScale = new Vector3(1, 1, 1);
            return 1f;
        }

        return 0f;
    }

    private void SetWalk()
    {
        moving = true;
        running = false;
        carrerilla = false;
        vulnerable = false;
    }

    private void SetRun()
    {
        moving = false;
        running = true;
        carrerilla = false;
        vulnerable = false;
    }

    private void SetCarrerilla()
    {
        moving = false;
        running = false;
        carrerilla = true;
        vulnerable = false;
    }

    private void SetIdleVulnerable()
    {
        moving = false;
        running = false;
        carrerilla = false;
=======
        anim.SetTrigger("run");
    }

    private void Impact()
    {
        anim.SetTrigger("impact");
>>>>>>> 1ab08c5f6def9563fda40831213bf074edbe5041
        vulnerable = true;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, perceptionRadius);
    }
}