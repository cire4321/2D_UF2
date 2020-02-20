using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnController : MonoBehaviour
{
    public float damage;

    public FinnModel dataModel;
    public Transform punchSpawner;
    public GameObject punch;


    private float hSpeed;

    private GameManager gm;
    private CharacterState currentState;
    private Animator anim;

    void Start()
    {
        dataModel = Instantiate(dataModel);
        hSpeed = dataModel.horizontalSpeed;
        ChangeState(new OnGroundState(this));
        gm = GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        currentState.Execute();

        Debug.Log(gm.playerHealth);

        if(gm.playerHealth <= 0)
        {
            anim.SetBool("die", true);
        }

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

    public void TakeDamage(float damage)
    {
        Debug.Log("Hited");
        anim.SetTrigger("hit");
        gm.playerHealth -= damage;
    }

    public void Attack()
    {
        Instantiate(punch, punchSpawner.position, transform.rotation);
        Debug.Log("Punch");
    }

    public void Stop()
    {
        dataModel.horizontalSpeed = 0f;
    }

    public void Continue()
    {
        dataModel.horizontalSpeed = hSpeed;
    }

}
