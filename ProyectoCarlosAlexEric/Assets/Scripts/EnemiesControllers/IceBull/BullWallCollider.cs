using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullWallCollider : MonoBehaviour
{
    private bool impact;

    // Start is called before the first frame update
    void Start()
    {
        impact = false;   
    }

    // Update is called once per frame
    void Update()
    {
        Impact();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        impact = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        impact = false;
    }

    public bool Impact()
    {
        return impact;
    }
}
