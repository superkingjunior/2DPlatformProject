using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("BedroomLevel");
    }

    public void Tutorial()
    {
        mainMenu.SetActive(false);
        SceneManager.LoadScene("Tutorial");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}