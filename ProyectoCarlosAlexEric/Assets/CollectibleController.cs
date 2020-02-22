﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (gameObject.CompareTag("Candy"))
            {
                GameManager.Instance.AddCaramelo();
            }

            if (gameObject.CompareTag("Escarcha"))
            {
                GameManager.Instance.AddEscarcha();

            }

            Destroy(gameObject);
        }
    }
}
