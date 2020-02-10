using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnController : MonoBehaviour
{
    //-----PUBLIC-----
    [Range(0f, 5f)] public float speed = 1f;
    public GameObject punch;
    public Transform punchSpawnPoint;

    public float jumpPower = 3f;

    //-----PRIVATE-----
    private float h;
    private Rigidbody2D rb2D;
    private Animator ator;
    private SpriteRenderer finnRdr;
    private bool isPunching = false;
    private bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ator = GetComponent<Animator>();

        finnRdr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");

        float temp_speed = Mathf.Max(Mathf.Abs(h), 0);
        ator.SetFloat("Speed", temp_speed);


        if (Input.GetButtonDown("Fire1") && !isPunching)//Ataque 1-->Clic izq del ratón
        {
            isPunching = true;
            ator.SetTrigger("Punch");

            GameObject goPunch = Instantiate(punch, punchSpawnPoint.position, punchSpawnPoint.rotation);
            float disablePunchTime = goPunch.GetComponent<PunchController>().lifeSpan;
            Invoke("EnablePunch", disablePunchTime);

        }

        if (Input.GetButtonDown("Jump") && !isJumping)//Salto-->Space Bar
        {
            rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
            isJumping = true;
            ator.SetTrigger("Jump");
            
            Invoke("EnableJump", 0.5f);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            ator.SetTrigger("Roll");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ator.SetTrigger("Smash");
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(speed * h, 0);

    }

    private void EnablePunch()
    {
        isPunching = false;
    }

    private void EnableJump()
    {
        isJumping = false;
    }

}
