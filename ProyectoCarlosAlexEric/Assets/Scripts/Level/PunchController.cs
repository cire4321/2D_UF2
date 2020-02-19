using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour
{
    public float damage = 20f;//Se instancia el daño del player
    public float lifeSpan = 0.5f;//El prefab tiene un tiempo de vida de 0.5s

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);//Se destruye el gameObject una vez transcurrido el tiempo de vida
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);//En caso de colision con otro collider antes de que se agote el tiempo de vida, se activa el trigger del colider de este gameObject y se destruye
        }
    }
}
