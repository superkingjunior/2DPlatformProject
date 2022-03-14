using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlatform : MonoBehaviour
{

    private PlatformEffector2D Edge;
    private float waitTime = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        Edge = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {

            StartCoroutine(JumpDown());
        }
    }

    IEnumerator JumpDown()
    {
        Edge.rotationalOffset = 0;
        yield return new WaitForSeconds(waitTime);
        Edge.rotationalOffset = 180;
    }
}
