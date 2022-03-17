using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitLevel : MonoBehaviour
{
    [SerializeField] string nextLevel;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            
            if (scene.name == "Tutorial")
            {
                SceneManager.LoadScene("MainMenu");
            }

            if (scene.name == "BedroomLevel")
            {
                SceneManager.LoadScene("BathroomLevel");
            }

            if (scene.name == "BathroomLevel")
            {
                SceneManager.LoadScene("BoilerRoomLevel");
            }

            if (scene.name == "BoilerRoomLevel")
            {
                SceneManager.LoadScene("ClosetLevel");
            }

            if (scene.name == "ClosetLevel")
            {
                SceneManager.LoadScene("KitchenLevel");
            }

            if (scene.name == "KitchenLevel")
            {
                SceneManager.LoadScene("LivingroomLevel");
            }

            if (scene.name == "LivingroomLevel")
            {
                SceneManager.LoadScene("LoftLevel");
            }
        }

    }

}
