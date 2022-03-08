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

    public int lives = 9;

    private bool hit = false;

    private bool run = false;

    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        StartCoroutine(Animate());
    }

    // Update is called once per frame
    void Update()
    {


    }

    private IEnumerator Animate()
    {
        mySpriteRenderer.sprite = idle;
        run = true;
        while (!hit || run)
        {
            Vector2 vel = myRb2D.velocity;

            if ((Mathf.Abs(vel.y) > 0))
            {
                mySpriteRenderer.sprite = spriteUp;
            }
            else if (vel.x > 0)
            {
                mySpriteRenderer.flipX = false;
                if (mySpriteRenderer.sprite == idle || mySpriteRenderer.sprite == spriteRight2)
                {
                    //Debug.Log("Moving Right");
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
        Destroy(gameObject);
    }

    private IEnumerator AnimateFall()
    {
        mySpriteRenderer.sprite = hurt;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Animate());
        controller.isFrozen = false;
        for (int i = 0; i < 15; i++)
        {
            if (i % 2 == 0)
            {
                mySpriteRenderer.color = Color.red;
            }
            else
            {
                mySpriteRenderer.color = Color.white;
            }
            yield return new WaitForSeconds(0.1f);
        }
        mySpriteRenderer.color = Color.white;
        hit = false;
        run = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Dog") && (!hit))
        {
            if (Input.GetKey(KeyCode.E))
            {
                
                Destroy(collision.gameObject);
            }
            else
            {
                lives--;

                hit = true;
                StopAllCoroutines();
                controller.isFrozen = true;
                
                if (lives > 0)
                {
                    //Lives.UpdateLives(lives);
                    StartCoroutine(AnimateFall());
                }
                if (lives <= 0)
                {
                    StartCoroutine(AnimateDeath());
                }
                    
             }
                
         }
        
     }
}

