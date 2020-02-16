using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusController : MonoBehaviour
{
    public float hideArea = 6f;

    private Transform finn;
    private Animator anim;
    private float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        finn = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(finn.transform.position, transform.position);

        if (distance < hideArea)
        {
            anim.SetBool("Hide", true);
            anim.SetBool("Unhide", false);
        }
            

        if (distance > hideArea)
        {
            anim.SetBool("Unhide", true);
            anim.SetBool("Hide", false);
        }
            

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, hideArea);
    }

}
