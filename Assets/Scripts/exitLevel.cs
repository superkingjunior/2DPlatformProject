using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitLevel : MonoBehaviour
{
    //[SerializeField] string nextLevel;


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

            if (scene.name == "BathroomLevel")
            {
                SceneManager.LoadScene("ClosetLevel");
            }

            if (scene.name == "ClosetLevel")
            {
                SceneManager.LoadScene("BedroomLevel");
            }

            if (scene.name == "BedroomLevel")
            {
                SceneManager.LoadScene("BoilerRoomLevel");
            }

            if (scene.name == "BoilerRoomLevel")
            {
                SceneManager.LoadScene("PlayroomLevel");
            }

            if (scene.name == "PlayroomLevel")
            {
                SceneManager.LoadScene("LivingroomLevel");
            }


            if (scene.name == "LivingroomLevel")
            {
                SceneManager.LoadScene("DiningroomLevel");
            }

            if (scene.name == "DiningroomLevel")
            {
                SceneManager.LoadScene("KitchenLevel");
            }

            if (scene.name == "KitchenLevel")
            {
                SceneManager.LoadScene("LoftLevel");
            }

            if (scene.name == "LoftLevel")
            {
                SceneManager.LoadScene("OutsideLevel");
            }

            if (scene.name == "OutsideLevel")
            {
                SceneManager.LoadScene("Rooftop2Level");
            }

            if (scene.name == "Rooftop2Level")
            {
                SceneManager.LoadScene("YouWin");
            }
        }


    }

}
