using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusController : MonoBehaviour
{
    public float hideArea = 6f;
    public GameObject healthArea;
    public Transform hASpawnPoint;

    private Transform finn;
    private Animator anim;
    private float distance;
    private float timer = 1f;
    private float _timer;
    private GameObject cloneSpawn;

    // Start is called before the first frame update
    void Start()
    {
        finn = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        _timer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(finn.position, transform.position);

        if (distance < hideArea)
        {
            _timer -= Time.deltaTime;

            anim.SetBool("Hide", true);
            anim.SetBool("Unhide", false);
            if(_timer <= 0)
            {
                GameManager.Instance.currentHealth += 0.2f;
                _timer = timer;

                if(GameManager.Instance.currentHealth >= 5)
                {
                    GameManager.Instance.currentHealth = 5;
                }
            }
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

    public void Spawn()
    {
        cloneSpawn = Instantiate(healthArea, hASpawnPoint);
    }

    public void Destroy()
    {
        Destroy(cloneSpawn);
    }

}
