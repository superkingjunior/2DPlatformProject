using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    private Rigidbody2D myRb2D;
    //public float velocity;
    private SpriteRenderer mySpriteRenderer;
    public Sprite spriteUp;
    public Sprite spriteRight;
    public Sprite spriteRight2;
    public Sprite idle;
    public Sprite hurt;
    public Sprite dead;

    private float hurtTimer=5;

    private float lives = 0;

    //private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Animate());
    }

    // Update is called once per frame
    void Update()
    {
/*
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded==true)
        {
            vel.y = velocity*5;
            mySpriteRenderer.sprite = spriteUp;
            grounded = false;

        }



        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = velocity;
            mySpriteRenderer.flipX = false;
            
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
*/

    }

    private IEnumerator Animate()
    {
        while (true)
        {
            Vector2 vel = myRb2D.velocity;

            if (Mathf.Abs(vel.y) > 0)
            {
                mySpriteRenderer.sprite = spriteUp;
            }
            else if (vel.x > 0)
            {
                mySpriteRenderer.flipX = false;
                if (mySpriteRenderer.sprite == idle || mySpriteRenderer.sprite == spriteRight2)
                {

                    mySpriteRenderer.sprite = spriteRight;
                }
                else
                {
                    mySpriteRenderer.sprite = spriteRight2;
                }
            }
            else if (vel.x < 0)
            {
                mySpriteRenderer.flipX = true;
                if (mySpriteRenderer.sprite == idle || mySpriteRenderer.sprite == spriteRight2)
                {
                    mySpriteRenderer.sprite = spriteRight;
                }
                else
                {
                    mySpriteRenderer.sprite = spriteRight2;
                }
            }
            else if (vel.x == 0)
            {
                mySpriteRenderer.sprite = idle;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }
        */
        if (collision.gameObject.CompareTag("Dog"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                Destroy(collision.gameObject);
            }
            else
            {
                lives--;
                mySpriteRenderer.sprite = hurt;
                if (lives <= 0)
                {
                    mySpriteRenderer.sprite = dead;
                    StopCoroutine(Animate());

                    Destroy(gameObject);
                }
                
            }
        }
    }

}
