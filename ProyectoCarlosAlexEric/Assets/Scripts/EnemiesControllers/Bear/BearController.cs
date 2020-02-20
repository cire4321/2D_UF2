using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    public float health;
    public float damage;

    private GameObject player;
    private Animator anim;

    private Vector3 scala;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        scala = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-scala.x, scala.y, scala.z);
        }
        else
        {
            transform.localScale = new Vector3(scala.x, scala.y, scala.z);
        }

        Debug.Log(health);
        if (health <= 0)
        {
            anim.SetTrigger("die");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Attack")
        {
            TakeDamage();
        }

        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("roar");
            MakeDamage();
        }
    }

    private void TakeDamage()
    {
        health -= player.GetComponent<FinnController>().damage;
        anim.SetTrigger("hit");
        if(health <= 0)
        {
            anim.SetTrigger("die");
        }
    }

    public void MakeDamage()
    {
        player.GetComponent<FinnController>().TakeDamage(damage);
    }

    private void Die()
    {
        foreach (var comp in gameObject.GetComponents<Component>())
        {
            if (!(comp is Transform) && !(comp is Animation) && !(comp is Animator) && !(comp is SpriteRenderer))
            {
                Destroy(comp);
            }
        }
    }
}
