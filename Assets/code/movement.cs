using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float dash = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    public bool can = true;
    public AudioSource AUDIO;
    public AudioClip shootClip;
    public AudioClip relodClip;
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
        if (Input.GetKeyDown(KeyCode.Mouse0)&&can){
            rb.velocity = (transform.right * dash);
            can = false;
            AUDIO.PlayOneShot(shootClip);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!can)
        {
            can = true;
            AUDIO.PlayOneShot(relodClip);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!can)
        {
            can = true;
            AUDIO.PlayOneShot(relodClip);
        }
    }
}
