using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enimyMove1 : MonoBehaviour
{
    public Transform t;
    public Rigidbody2D rb;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir =  GameObject.FindGameObjectWithTag("P").transform.position - transform.position;
        if (dir != Vector2.zero)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle);
            rb.velocity = (transform.right * speed);
        }
    }
}
