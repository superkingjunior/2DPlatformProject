using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    private Rigidbody2D rb2d;

    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2d.velocity;
        vel.x = Input.GetAxis("horizontal") * speed;

        UpdateGrounding();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vel.y = jumpForce;
        }

        rb2d.velocity = vel;
    }

    private void UpdateGrounding()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
        grounded = hit.collider != null;
    }
}
