using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : CharacterState
{
    private float h;
    private Rigidbody2D rb2D;
    private Animator ator;

    public JumpingState(FinnController f) : base(f)
    {
        rb2D = finn.GetComponent<Rigidbody2D>();
        ator = finn.GetComponent<Animator>();
    }

    public override void OnInit()
    {
        ator.SetBool("Grounded", false);
        base.OnInit();
    }
    public override void Execute()
    {
        h = Input.GetAxis("Horizontal");
    }

    public override void FixedExecute()
    {
        rb2D.velocity = new Vector2(h * finn.dataModel.horizontalSpeed * finn.dataModel.horizontalSpeedAirFactor, rb2D.velocity.y);

        if (h > 0)
            rb2D.transform.rotation = Quaternion.AngleAxis(0, new Vector2(0, 1));
        if (h < 0)
            rb2D.transform.rotation = Quaternion.AngleAxis(180, new Vector2(0, 1));
    }

    public override void CheckTransitions()
    {
        RaycastHit2D[] hitResults = new RaycastHit2D[2];

        if (rb2D.Cast(new Vector2(0, -1), hitResults, 0.1f) > 0)
            finn.ChangeState(new OnGroundState(finn));
    }
}