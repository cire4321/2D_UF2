using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public float currentHealth;
    public float maxHealth = 100f;

    public int caramelo, muerte, escarcha;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("MainMenu");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        muerte = 0;
        escarcha = 0;
        caramelo = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddEscarcha()
    {
        escarcha++;
    }


    public void AddMuerte()
    {
        muerte++;
    }


    public void AddCaramelo()
    {
        caramelo++;
    }
}
