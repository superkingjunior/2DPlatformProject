using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool isFrozen;

    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravScale;
    [SerializeField] float mass;
    [SerializeField] float launchSpeed;

    private Rigidbody2D rb2d;
    private CapsuleCollider2D capCollide;

    private bool grounded;
    private bool climbing;
    private bool launching;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        capCollide = GetComponent<CapsuleCollider2D>();

        rb2d.mass = mass;
        rb2d.gravityScale = gravScale;
        grounded = false;
        climbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen)
        {
            return;
        }
        Vector2 vel = rb2d.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;

        if (climbing)
        {
            float vertical = Input.GetAxis("Vertical") * speed;
            if(vertical > vel.y)
            {
                vel.y = vertical;
            }
        }

        UpdateGrounding();

        if (launching)
        {
            vel.y = launchSpeed;
            Debug.Log("LAUNCH!");
            launching = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (grounded || climbing))
        {
            vel.y += jumpSpeed / (climbing ? 2.5f : 1);
            //vel.y += jumpSpeed;
        }

        rb2d.velocity = vel;
        
    }

    private void UpdateGrounding()
    {
        Vector3 origin = capCollide.transform.position;
        origin.y -= capCollide.size.y/2;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector3.down, 0.1f);
        Debug.DrawRay(origin, Vector3.down * 0.1f, Color.red);
        grounded = hit.collider != null;
        if (grounded && hit.collider.gameObject.CompareTag("Launcher"))
        {
            launching = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            climbing = true;
            rb2d.gravityScale = gravScale/5;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            climbing = false;
            rb2d.gravityScale = gravScale;
        }
    }
}
