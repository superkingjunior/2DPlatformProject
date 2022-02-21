using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBook : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 1;

    public float lifeTime = 4;
  
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 1;
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

    public void OnHit()
    {
        // the Instatiate function creates a new GameObject copy (clone) from a Prefab at a specific location and orientation.
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //add once we do different health problems
        Destroy(gameObject);
    }
}
