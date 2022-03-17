using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private Rigidbody2D myRb2D;
    public Vector2 velocity;
    private SpriteRenderer mySpriteRenderer;
    public Sprite spriteRight;
    public Sprite spriteRight2;
    public Sprite hurt;
    public Sprite dead;
    public double timer;
    public float speed;
    private double reset;
    public float lives = 5;

    public bool hit = false;



    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        reset = timer;
        myRb2D.velocity = velocity;
        StartCoroutine(Animate());
    }


    private void Update()
    {
        timer -= Time.deltaTime;
        if (!hit)
        {
            if (mySpriteRenderer.flipX)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            if (timer <= 0)
            {
                timer = reset;

                mySpriteRenderer.flipX = !mySpriteRenderer.flipX;

            }
        }
        else
        {

        }
        
    }


    public IEnumerator Animate()
    {
        while (!hit)
        {
            if (mySpriteRenderer.sprite == spriteRight)
            {
                mySpriteRenderer.sprite = spriteRight2;
            }
            else if(mySpriteRenderer == spriteRight2)
            {
                mySpriteRenderer.sprite = spriteRight;
            }
            else
            {
                mySpriteRenderer.sprite = spriteRight;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator AnimateFall()
    {
        hit = true;
        mySpriteRenderer.sprite = hurt;
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
        StartCoroutine(Animate());
    }

    public void SetColor(Color color)
    {
        mySpriteRenderer.color = color;
    }

    public IEnumerator AnimateDeath()
    {
        hit = true;
        mySpriteRenderer.sprite = dead;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        //StopAllCoroutines();
    }



}

