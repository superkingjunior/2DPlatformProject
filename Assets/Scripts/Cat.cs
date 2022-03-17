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

    //public int lives = 9;

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
        Vector2 direction = (mySpriteRenderer.flipX) ? Vector2.left : Vector2.right;
        RaycastHit2D attack = Physics2D.Raycast(transform.position, direction, 3f, 1 << LayerMask.NameToLayer("Dog"));
        //Debug.DrawRay(transform.position, Vector2.right * 3f, Color.red);
        //Debug.DrawRay(transform.position, Vector2.right * -3f, Color.red);
        if (Input.GetKeyDown(KeyCode.E) && cooldown > cooldownTime && !hit)
        {
            cooldown = 0f;
            attacking = true;
            if(attack.collider != null)
            {
                Dog dog = attack.collider.gameObject.GetComponent<Dog>();
                if (!dog.hit)
                {
                    dog.lives--;
                    dog.SetColor(Color.white);
                    if (dog.lives > 0 && dog != null)
                    {
                        StartCoroutine(dog.AnimateFall());
                    }
                    else if (dog != null)
                    {
                        StartCoroutine(dog.AnimateDeath());
                    }
                }
            }
        }
        cooldown += Time.deltaTime;
        UIManager.UpdatePercentCooldown(cooldown, cooldownTime);

    }

    private IEnumerator Animate()
    {
        mySpriteRenderer.sprite = idle;
        run = true;
        while (!hit || run)
        {
            if(attacking)
            {
                
                if (mySpriteRenderer.flipX)
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                foreach (Sprite attackFrame in attack){
                    mySpriteRenderer.sprite = attackFrame;
                    yield return new WaitForSeconds(0.05f);
                }
                attacking = false;
                if (mySpriteRenderer.flipX)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            Vector2 vel = myRb2D.velocity;

            if ((Mathf.Abs(vel.y) > 0))
            {
                mySpriteRenderer.sprite = spriteUp;
            }
            else if (vel.x > 0)
            {
                mySpriteRenderer.flipX = false;
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
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
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.CompareTag("Dog")|| collision.gameObject.CompareTag("FallingObject") || collision.gameObject.CompareTag("Water")) && (!hit))
        {
            UIManager.livesUI--;

            hit = true;
            run = false;
            controller.isFrozen = true;
                
            if (UIManager.livesUI > 0)
            {
                UIManager.UpdateLives(UIManager.livesUI);
                StartCoroutine(AnimateFall());
            }
            if (UIManager.livesUI <= 0)
            {
                UIManager.UpdateLives(UIManager.livesUI);
                StartCoroutine(AnimateDeath());
            }
                
                
         }
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart") && UIManager.livesUI < 9)
        {
            UIManager.livesUI++;
            UIManager.UpdateLives(UIManager.livesUI);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Water") && UIManager.livesUI < 9)
        {
            UIManager.livesUI--;
            UIManager.UpdateLives(UIManager.livesUI);
        }
    }

}

