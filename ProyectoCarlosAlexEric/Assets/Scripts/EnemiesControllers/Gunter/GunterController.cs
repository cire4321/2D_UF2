using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunterController : MonoBehaviour
{
    public float initHP;
    public float speed;
    public float perceptionRadius;
    public float attackRadius;

    public Transform player;


    private float HP;
    private bool attackng = false;
    private bool moving = false;

    private Rigidbody2D rb2d;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        HP = initHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckState()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, perceptionRadius);

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
