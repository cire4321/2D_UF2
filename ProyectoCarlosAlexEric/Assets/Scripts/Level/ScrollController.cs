using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public float speed;

    private MeshRenderer rnd;
    private Material mat;
    private Vector2 offset;
    
    void Start()
    {
        rnd = GetComponent<MeshRenderer>();
        mat = rnd.material;
        offset = mat.mainTextureOffset;
    }

    void Update()
    {
        offset.x += speed * Time.deltaTime;

        mat.mainTextureOffset = offset;
    }
}
