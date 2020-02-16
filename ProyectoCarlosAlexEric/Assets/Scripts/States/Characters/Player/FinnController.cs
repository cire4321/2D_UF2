using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnController : MonoBehaviour
{
    public FinnModel dataModel;

    private CharacterState currentState;
    
    void Start()
    {
        dataModel = Instantiate(dataModel);

        ChangeState(new OnGroundState(this));
    }

    void Update()
    {
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

    public void TakeDamage(float damage)
    {

    }
}

