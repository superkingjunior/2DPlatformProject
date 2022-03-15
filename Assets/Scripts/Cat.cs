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
    public float cooldownTime;

    public Sprite[] attack;
    private bool attacking = false;

    public int lives = 9;

    private bool hit = false;

    private float cooldown = 2f;

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
        RaycastHit2D attack = Physics2D.Raycast(transform.position, Vector2.right, 2f, 1 << LayerMask.NameToLayer("Dog"));
        //Debug.DrawRay(transform.position, Vector2.right * 1f, Color.red);
        if (Input.GetKeyDown(KeyCode.E) && cooldown > cooldownTime)
        {
            cooldown = 0f;
            attacking = true;
            if(attack.collider != null)
            {
                Dog dog = attack.collider.gameObject.GetComponent<Dog>();
                if (!dog.hit)
                {
                    dog.lives--;
                    dog.hit = true;
                    dog.StopAllCoroutines();
                    if (dog.lives > 0 && dog != null)
                    {
                        StartCoroutine(dog.AnimateFall());
                        dog.hit = false;
                    }
                    else if (dog != null)
                    {
                        //dog.StopAllCoroutines();
                        StartCoroutine(dog.AnimateDeath());
                    }
                }
            }
        }
        cooldown += Time.deltaTime;

    }

    private IEnumerator Animate()
    {
        mySpriteRenderer.sprite = idle;
        run = true;
        while (!hit || run)
        {
            if(attacking)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                foreach (Sprite attackFrame in attack){
                    mySpriteRenderer.sprite = attackFrame;
                    yield return new WaitForSeconds(0.05f);
                }
                attacking = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
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

        if ((collision.gameObject.CompareTag("Dog")|| collision.gameObject.CompareTag("FallingObject")) && (!hit))
        {
            lives--;

            hit = true;
            StopAllCoroutines();
            controller.isFrozen = true;
                
            if (lives > 0)
            {
                UIManager.UpdateLives(lives);
                StartCoroutine(AnimateFall());
            }
            if (lives <= 0)
            {
                StartCoroutine(AnimateDeath());
            }
                
                
         }
        if(collision.gameObject.CompareTag("Heart") && lives<= 8)
        {
            lives++;
            UIManager.UpdateLives(lives);
            Destroy(collision.gameObject);
        }

        
        
     }

}

