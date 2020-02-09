using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState
{
    protected FinnController finn;

    public CharacterState(FinnController f)
    {
        finn = f;
    }

    public abstract void Execute();
    public abstract void FixedExecute();
    public abstract void CheckTransitions();

    public virtual void OnInit() { }
    public virtual void OnExit() { }
    public virtual void OnTriggerEnter(Collider2D collision) { }
    public virtual void OnTriggerExit(Collider2D collision) { }
}