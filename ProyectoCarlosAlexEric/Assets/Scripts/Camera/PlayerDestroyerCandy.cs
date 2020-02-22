using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroyerCandy : MonoBehaviour
{
    private GameObject finn;

    // Start is called before the first frame update
    void Start()
    {
        finn = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.caramelo = 0;
            GameManager.Instance.muerte = 0;

            //Destroy(finn);
            GameManager.Instance.currentHealth = GameManager.Instance.maxHealth;
            SceneManager.LoadScene("Candyland");

            

        }
    }
}
