using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSpawnerController : MonoBehaviour
{
    [HideInInspector] public float angle;
    [HideInInspector] public bool canShoot = false;

    public const float shootingCooldown = 1f;

    public GameObject bullet;
    public WormController worm;


    private bool attacking = false;
    private float timer;

    
    private Quaternion rotation;


    void Start()
    {
        timer = shootingCooldown;
    }

    void Update()
    {
        CheckState();
        timer -= Time.deltaTime;

        if (!canShoot)
        {
            
            if (timer <= 0)
            {
                canShoot = true;
            }
        }

        FacePlayer();
        if (attacking && canShoot)
        {
            worm.anim.SetTrigger("attacking");
        }


    }

    private void CheckState()
    {
        if (worm.distance <= worm.shootingRadius)
        {
            attacking = true;
        }

        if (worm.distance < worm.forgetRadius && worm.distance > worm.shootingRadius)
        {
            attacking = false;
        }

        if (worm.distance >= worm.forgetRadius)
        {
            attacking = false;
        }


    }

    private void FacePlayer()
    {
        Vector2 direction = worm.player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0);
    }

    public void Shoot()
    {
            Instantiate(bullet, transform.position, rotation);
            canShoot = false;
            timer = shootingCooldown;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, worm.forgetRadius);

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, worm.shootingRadius);
    }

}
