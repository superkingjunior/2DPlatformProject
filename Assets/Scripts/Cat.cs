using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    private Rigidbody2D myRb2D;
    public float velocity;
    private SpriteRenderer mySpriteRenderer;
    public Sprite spriteUp;
    public Sprite spriteRight;
    public Sprite spriteRight2;
    public Sprite idle;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = myRb2D.velocity;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = velocity;
            mySpriteRenderer.sprite = spriteUp;

        }



        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = velocity;
            mySpriteRenderer.flipX = false;
            if (mySpriteRenderer.sprite == idle)
            {

                mySpriteRenderer.sprite = spriteRight;
            }
            else
            {
                mySpriteRenderer.sprite = spriteRight2;
            }
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -velocity;
            mySpriteRenderer.flipX = true;
            if (mySpriteRenderer.sprite == idle)
            {
                mySpriteRenderer.sprite = spriteRight;
            }
            else
            {
                mySpriteRenderer.sprite = spriteRight2;
            }
        }

        else
        {
            vel.x = 0;
            vel.y = 0;
            mySpriteRenderer.sprite = idle;
        }

        myRb2D.velocity = vel;

    }
}
