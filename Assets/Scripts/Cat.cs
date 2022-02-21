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

    public float lives = 9;

    private bool hit = false;

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


    }

    private IEnumerator Animate()
    {
        while (true)
        {
            Vector2 vel = myRb2D.velocity;

            if ((Mathf.Abs(vel.y) > 0) && (!hit))
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

    private IEnumerator AnimateDeath()
    {
        mySpriteRenderer.sprite = dead;
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator AnimateFall()
    {
        mySpriteRenderer.sprite = hurt;
        new WaitForSeconds(1.5f);
        hit = false;
        yield return new WaitForSeconds(1.0f);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Dog"))
        {
            hit = true;
            if (Input.GetKey(KeyCode.E))
            {
                
                Destroy(collision.gameObject);
            }
            else
            {
                lives--;

                
                 StopCoroutine(Animate());
                 StartCoroutine(AnimateFall());

                if (lives <= 0)
                {
                    StopCoroutine(AnimateFall());
                    StartCoroutine(AnimateDeath());
                    Destroy(gameObject);
                }
                StartCoroutine(Animate());
                    
             }
                
         }
        
     }
}

