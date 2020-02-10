using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OnLadderState;

public class OnGroundState : CharacterState
{
    private float h;
    protected Rigidbody2D rb2D;
    protected Animator ator;
    protected float ladderStep;
    protected LadderPos ladderPos;


    public OnGroundState(FinnController f) : base(f)
    {
        rb2D = finn.GetComponent<Rigidbody2D>();
        ator = finn.GetComponent<Animator>();
    }

    public override void OnInit()
    {
        ator.SetBool("Grounded", true);
        ladderPos = LadderPos.NONE;

        base.OnInit();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void Execute()
    {
        h = Input.GetAxis("Horizontal");
        ator.SetFloat("speedFactor", Mathf.Abs(h));

        if (Input.GetButtonDown("Jump"))
        {
            rb2D.AddForce(new Vector2(0, 1) * finn.dataModel.verticalImpulse, ForceMode2D.Impulse);
            ator.SetTrigger("Jump");
        }

        if (Input.GetButtonDown("Fire3"))
        {
            ator.SetTrigger("Roll");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ator.SetTrigger("Smash");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ator.SetTrigger("Hit");
        }
    }

    public override void FixedExecute()
    {
        rb2D.velocity = new Vector2(h * finn.dataModel.horizontalSpeed, rb2D.velocity.y);

        if (h > 0)
            rb2D.transform.rotation = Quaternion.AngleAxis(0, new Vector2(0, 1));
        if (h < 0)
            rb2D.transform.rotation = Quaternion.AngleAxis(180, new Vector2(0, 1));
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        base.OnTriggerEnter(collision);

        if (collision.gameObject.tag == "BottomLadder")
        {
            ladderStep = (collision as CircleCollider2D).radius * 2 * 1.05f;
            ladderPos = LadderPos.BOTTOM;
        }

        if (collision.gameObject.tag == "TopLadder")
        {
            ladderStep = (collision as CircleCollider2D).radius * 2 * 1.05f;
            ladderPos = LadderPos.TOP;
        }
    }

    public override void OnTriggerExit(Collider2D collision)
    {
        base.OnTriggerExit(collision);
    }

    

    public override void CheckTransitions()
    {
        if (ladderPos != LadderPos.NONE)
            finn.ChangeState(new OnLadderState(finn, ladderPos, ladderStep));

        RaycastHit2D[] hitResults = new RaycastHit2D[2];

        if (rb2D.Cast(new Vector2(0, -1), hitResults, 0.1f) == 0)
            finn.ChangeState(new JumpingState(finn));
    }


}