using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLadderState : OnGroundState
{
    public enum LadderPos
    {
        TOP, BOTTOM, MIDDLE, NONE
    }

    private float f;

    public OnLadderState(FinnController finn, LadderPos ladderPos, float ladderStep) : base(finn)
    {
        this.ladderPos = ladderPos;
        this.ladderStep = ladderStep;
    }

    public override void OnInit()
    {

    }

    public override void OnExit()
    {
        ator.SetBool("ladder", false);
    }

    public override void Execute()
    {
        f = Input.GetAxis("Vertical");

        switch (ladderPos)
        {
            case LadderPos.TOP:
                if (f < 0)
                    rb2D.gravityScale = 0;
                else
                    f = 0;
                break;
            case LadderPos.BOTTOM:
                if (f > 0)
                    rb2D.gravityScale = 0;
                else
                    f = 0;
                break;
            case LadderPos.MIDDLE:
                ator.SetFloat("speedFactor", f);
                break;
        }

        if (rb2D.gravityScale != 0)
            base.Execute();
    }

    public override void FixedExecute()
    {
        if (rb2D.gravityScale != 0)
            base.FixedExecute();
        else
        {
            if (ladderPos == LadderPos.BOTTOM || ladderPos == LadderPos.TOP)
            {
                rb2D.position += new Vector2(0, Mathf.Sign(f) * ladderStep);
                ladderPos = LadderPos.MIDDLE;
                ator.SetBool("ladder", true);
            }
            if (ladderPos == LadderPos.MIDDLE)
                rb2D.velocity = new Vector2(0, finn.dataModel.ladderSpeed * f);
        }
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        if (collision.tag == "BottomLadder")
        {
            rb2D.gravityScale = 1;
            ator.SetBool("ladder", false);
            ladderPos = LadderPos.BOTTOM;
        }

        if (collision.tag == "TopLadder")
        {
            rb2D.position += new Vector2(0, ladderStep);
            rb2D.gravityScale = 1;
            ladderPos = LadderPos.TOP;
            ator.SetBool("ladder", false);
        }
    }

    public override void OnTriggerExit(Collider2D collision)
    {
        if (collision.tag == "BottomLadder" && ladderPos == LadderPos.BOTTOM)
        {
            ladderPos = LadderPos.NONE;
        }
        if (collision.tag == "TopLadder" && ladderPos == LadderPos.TOP)
        {
            ladderPos = LadderPos.NONE;
        }
    }

    public override void CheckTransitions()
    {
        if (ladderPos == LadderPos.NONE)
            finn.ChangeState(new OnGroundState(finn));
    }


}