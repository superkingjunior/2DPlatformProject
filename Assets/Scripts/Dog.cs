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
    public float timer;
    public float speed;
    private float reset;


    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        reset = timer;
        myRb2D.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(mySpriteRenderer.sprite == spriteRight)
        {
            mySpriteRenderer.sprite = spriteRight2;
        }
        else
        {
            mySpriteRenderer.sprite = spriteRight;
        }

        if (timer <= 0)
        {
            timer = reset;
            
            if (mySpriteRenderer.flipX)
            {
                mySpriteRenderer.flipX = false;
            }
            else
            {
                mySpriteRenderer.flipX = true;
            }

        }

        if (mySpriteRenderer.flipX)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

    }
}

