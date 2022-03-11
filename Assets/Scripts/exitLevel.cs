using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitLevel : MonoBehaviour
{
    string[] Scenes = { "Collin","BedroomLevel", "ClosetLevel", "KitchenLevel", "LivingroomLevel" };
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene(Scenes[index]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            if (Scenes.Length - 1 >= index)
            {
                SceneManager.LoadScene(Scenes[index]);
            }

            index++;

        }

    }

}
