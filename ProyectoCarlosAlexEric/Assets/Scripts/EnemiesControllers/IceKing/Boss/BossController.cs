using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float maxHP = 100f;
    public float speed = 1f;
    public float timeAttack = 7f;
    public float timeLoop = 5f;
    public float timeMov = 5f;

    private Animator anim;
    private Rigidbody2D rb2d;
    private float HP;
    private float timerAttack;
    private float timerLoop;
    private float timerMov;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        HP = maxHP;
        timerAttack = timeAttack;
        timerLoop = timeLoop;
    }

    // Update is called once per frame
    void Update()
    {
        timerAttack -= Time.deltaTime;
        timerMov -= Time.deltaTime;

        if (timerAttack <= 0)
        {
            timerLoop -= Time.deltaTime;

            anim.SetTrigger("Init");
            

            if (timerLoop <= 0)
            {
                anim.SetTrigger("End");

                timerLoop = timeLoop;
                timerAttack = timeAttack;
            }
                    
        }

        if(HP <= 0)
            anim.SetTrigger("Dead");

        Debug.Log("Attack: " + timerAttack);
        Debug.Log("Loop: " + timerLoop);
    }
    private void FixedUpdate()
    {
        //timerMov -= Time.deltaTime;

        if (timerMov < 0)
        {
            rb2d.velocity = new Vector2(speed, 0);

            if(timerMov < -timeMov)
                timerMov = timeMov;
        }    
        else
            rb2d.velocity = new Vector2(speed * -1, 0);
    }
}
