using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] AnimationCurve juice;

    private float timer = 0f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float scale = juice.Evaluate(timer);
        rb2d.velocity = new Vector2(0, (scale < 0) ? scale : scale * speed);
    }
}
