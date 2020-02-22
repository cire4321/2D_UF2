using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinnController : MonoBehaviour
{
    public float damage;

    public FinnModel dataModel;
    public Transform punchSpawner;
    public GameObject punch;

    public Text muerteTxt, carameloTxt , escarchaTxt;


    private float hSpeed;

    private CharacterState currentState;
    private Animator anim;

    void Start()
    {
        dataModel = Instantiate(dataModel);
        hSpeed = dataModel.horizontalSpeed;
        ChangeState(new OnGroundState(this));
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        SetCounter();

        currentState.Execute();
        //print(currentState);
    }

    private void FixedUpdate()
    {
        currentState.FixedExecute();
    }

    private void LateUpdate()
    {
        currentState.CheckTransitions();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState.OnTriggerExit(collision);
    }

    public void ChangeState(CharacterState newState)
    {
        if (newState != null)
        {
            if (currentState != null)
                currentState.OnExit();
            currentState = newState;
            currentState.OnInit();
        }
    }

    public void TakeDamage(float dmg)
    {

        GameManager.Instance.currentHealth -= dmg;

        if (GameManager.Instance.currentHealth <= 0)
        {
            GameManager.Instance.currentHealth = 0;
            anim.SetBool("die", true);
        }

        anim.SetTrigger("hit");

    }

    public void Attack()
    {
        Instantiate(punch, punchSpawner.position, transform.rotation);
    }

    public void Stop()
    {
        dataModel.horizontalSpeed = 0f;
    }

    public void Continue()
    {
        dataModel.horizontalSpeed = hSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            float dmg = collision.gameObject.GetComponent<BulletController>().damage;
            TakeDamage(dmg);
        }
    }

    public void Die()
    {
        Debug.Log("die finn");

        GameManager.Instance.currentHealth = GameManager.Instance.maxHealth;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "Candyland")
        {
            GameManager.instance.caramelo = 0;
            SceneManager.LoadScene("Candyland");

        }
        else if (sceneName == "IceKingdom")
        {
            GameManager.instance.escarcha = 0;
            SceneManager.LoadScene("IceKingdom");
        }
    }
    
    private void SetCounter()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        muerteTxt.text = GameManager.Instance.muerte.ToString();

        if (sceneName == "Candyland")
        {
            carameloTxt.text = GameManager.Instance.caramelo.ToString();
        }
        else if (sceneName == "IceKingdom")
        {
            escarchaTxt.text = GameManager.Instance.escarcha.ToString();
        }
    }

}
