using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float dash = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public bool can = true;
    public bool can1 = true;
    public AudioSource AUDIO;
    public AudioClip shootClip;
    public AudioClip relodClip;
    public Transform gunTip;
    public GameObject smoke;
    public bool dubl = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Input.mousePosition - cam.WorldToScreenPoint(gameObject.transform.position);
        if (dir != Vector2.zero)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle);
        }
        if (Input.GetKeyDown(KeyCode.A)&&can){
            shoot();
            can = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && can1&&dubl)
        {
            shoot();
            can1 = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!can||!can1)
        {
            can = true;
            can1 = true;
            AUDIO.PlayOneShot(relodClip);
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!can||!can1)
        {
            can = true;
            can1 = true;
            AUDIO.PlayOneShot(relodClip);
        }
    }
    private void shoot()
    {
        rb.velocity = (transform.right * dash);
        rb2.velocity = (transform.right * dash);
        
        AUDIO.PlayOneShot(shootClip);
        Instantiate(smoke, gunTip.position, gunTip.rotation);
    }
}
