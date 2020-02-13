using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceKingController : MonoBehaviour
{
    public float speed = 3f;
    public Transform finn;
    public Transform camera;

    private Rigidbody2D rb2d;
    private Animator anim;
    private float posCamX;
    private float posCamY;
    private Vector2 target1;
    private Vector2 target2;
    private Vector2 position;
    private float timer = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        position = gameObject.transform.position;
        target1 = new Vector2(0f, 0f);
        target2 = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        posCamX = camera.position.x;
        posCamY = camera.position.y;
        target1 = new Vector2(posCamX + 3.5f, 2f);
        target2 = new Vector2(posCamX - 3.5f ,2f);
        timer -= Time.deltaTime;

        anim.SetFloat("Speed", speed);

        if (speed > 0)
        {
            //transform.position = Vector2.MoveTowards(position, target1, speed * Time.deltaTime);

            rb2d.transform.rotation = Quaternion.AngleAxis(0, new Vector2(0, 1));

            //if(target1 == transform.position)
        }

        if (speed < 0)
        {
            //transform.position = Vector2.MoveTowards(position, target2, speed * Time.deltaTime);

            rb2d.transform.rotation = Quaternion.AngleAxis(180, new Vector2(0, 1));
        }

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
