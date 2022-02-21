using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    private Rigidbody2D rb2d;
    private CapsuleCollider2D collider;

    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2d.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;

        UpdateGrounding();

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            vel.y = jumpForce;
        }

        rb2d.velocity = vel;
    }

    private void UpdateGrounding()
    {
        Vector3 origin = collider.transform.position;
        origin.y -= collider.size.y/2;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector3.down, 0.1f, 1 << LayerMask.NameToLayer("Platform"));
        Debug.DrawRay(origin, Vector3.down * 0.1f, Color.red);
        grounded = hit.collider != null;
    }
}
