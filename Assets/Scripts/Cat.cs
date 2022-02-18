using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    private Rigidbody2D myRb2D;
    public float velocity;
    private SpriteRenderer mySpriteRenderer;
    public Sprite[] walkingRFrames;
    public Sprite[] walkingLFrames;
    public Sprite[] jumpFrames;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
