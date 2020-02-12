using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceKingController : MonoBehaviour
{
    public float speed = 3f;
    public Transform finn;
    public Transform camara;

    private Rigidbody2D rb2d;
    private Animator anim;
    private Vector3 posCam;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        posCam = camara.position;

        anim.SetFloat("Speed", speed);

        if (speed > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, posCam, speed);
            rb2d.transform.rotation = Quaternion.AngleAxis(0, new Vector2(0, 1));
        }

        if (speed < 0)
        {
            rb2d.transform.rotation = Quaternion.AngleAxis(180, new Vector2(0, 1));
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speed, 0f);
    }
}
