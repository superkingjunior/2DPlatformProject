using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravScale;
    [SerializeField] float mass;

    private Rigidbody2D rb2d;
    private CapsuleCollider2D capCollide;

    private bool grounded;

    private bool climbing;

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
        Vector2 vel = rb2d.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;

        if (climbing)
        {
            vel.y = Input.GetAxis("Vertical") * speed;
        }

        UpdateGrounding();

        if (Input.GetKeyDown(KeyCode.Space) && (grounded || climbing))
        {
            vel.y = jumpForce;
        }

        rb2d.velocity = vel;
    }

    private void UpdateGrounding()
    {
        Vector3 origin = capCollide.transform.position;
        origin.y -= capCollide.size.y/2;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector3.down, 0.1f, 1 << LayerMask.NameToLayer("Platform"));
        Debug.DrawRay(origin, Vector3.down * 0.1f, Color.red);
        grounded = hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            climbing = true;
            rb2d.gravityScale = 0;
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
