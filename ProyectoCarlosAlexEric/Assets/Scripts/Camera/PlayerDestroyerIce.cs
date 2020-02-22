using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroyerIce : MonoBehaviour
{
    private GameObject finn;

    private int muertesCandy;
    private float vidaCandy;

    // Start is called before the first frame update
    void Start()
    {
        finn = GameObject.FindGameObjectWithTag("Player");
        muertesCandy = GameManager.instance.muerte;
        vidaCandy = GameManager.instance.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.muerte = muertesCandy;
            GameManager.Instance.escarcha = 0;
            GameManager.Instance.currentHealth = vidaCandy;


            //Destroy(finn);
            SceneManager.LoadScene("IceKingdom");
        }
    }
}