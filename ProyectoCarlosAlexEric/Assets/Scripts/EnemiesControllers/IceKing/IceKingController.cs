using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceKingController : MonoBehaviour
{
    public float speed = 1f;

    public GameObject bullet;
    public Transform gun;

    private Rigidbody2D rb2d;
    private Animator anim;
    private GameObject player;

    private float timer = 5f;
    private float angle;
    Quaternion rotation;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
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

    private void FacePlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0);
    }

    public void InstantiateBullet()
    {
        Instantiate(bullet, gun.position, rotation);

    }
}
