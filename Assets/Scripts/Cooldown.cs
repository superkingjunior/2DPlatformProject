using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{

    public float percentage = 0;

    private Image image;
    private RectTransform transformImage;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.childCount);
        image = transform.GetChild(0).GetComponent<Image>();
        transformImage = transform.GetChild(0).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (percentage < 1)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
        transformImage.localScale = new Vector3(percentage, 1, 1);
    }
}
