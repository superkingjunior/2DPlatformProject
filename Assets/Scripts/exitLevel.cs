using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] string nextLevel;

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
            SceneManager.LoadScene(nextLevel);

            index++;

        }

    }

}
