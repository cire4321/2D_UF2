using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraController : MonoBehaviour
{
    [Range(0f,1f)] public float smoothFactor = 0.06f;
    public float alturaCamera;
    public float limitCameraIzq;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, alturaCamera, transform.position.z), smoothFactor);

        if(transform.position.x <= limitCameraIzq)
        {
            transform.position = new Vector3(limitCameraIzq, alturaCamera, transform.position.z);
        }
    }
}
