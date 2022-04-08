using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;


    private void Start()
    {
        GameObject objs = GameObject.FindGameObjectWithTag("UI");
        if (objs != null)
        {
            Destroy(objs);
        }

        UIManager.livesUI = 9;
    }


    //Starts the first level
    public void StartGame()
    {
        SceneManager.LoadScene("ClosetLevel");
    }
    //Starts the tutorial
    public void Tutorial()
    {
        mainMenu.SetActive(false);
        SceneManager.LoadScene("Tutorial");
    }

    //Quits
    public void ExitGame()
    {
        Application.Quit();
    }
}