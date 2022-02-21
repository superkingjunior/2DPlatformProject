using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBook : MonoBehaviour
{

    public float speed = 1;

    public float lifeTime = 4;
  
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        } else
        {
            Debug.Log("hit player minus a life");
        }


    }
}
