using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Image firstHeart;
    public GameObject heartsPanel;
    public Image[] hearts;
    private int heartsVisible;
    private static Lives instance;

    SpriteRenderer sr;
    public Sprite[] lifeCount;


    void Awake()
    {

        instance = this;
    }

    public static void SetLives(int lives)
    {

        instance.LivesChange(lives);
    }

    public static void RemoveHeart()
    {
        instance.LoseHeart();
    }

    private void LivesChange(int lives)
    {
        RectTransform panelRT = heartsPanel.GetComponent<RectTransform>();
        panelRT.sizeDelta = new Vector2(14 + lives * 18, panelRT.sizeDelta.y);
        hearts = new Image[lives];
        hearts[0] = firstHeart;
        for (int i = 1; i < lives; i++)
        {
            GameObject newHeartObj = Instantiate(firstHeart.gameObject, panelRT) as GameObject;
            hearts[i] = newHeartObj.GetComponent<Image>();
            RectTransform heartRT = newHeartObj.GetComponent<RectTransform>();
            RectTransform firstHeartRT = firstHeart.GetComponent<RectTransform>();
            heartRT.anchorMax = firstHeartRT.anchorMax;
            heartRT.anchorMin = firstHeartRT.anchorMin;
            heartRT.anchoredPosition = firstHeartRT.anchoredPosition;
            heartRT.sizeDelta = firstHeartRT.sizeDelta;
            heartRT.localPosition = new Vector3(firstHeartRT.localPosition.x + 18 * i, firstHeartRT.localPosition.y, firstHeartRT.localPosition.z);
        }
        heartsVisible = lives;
    }

    private void LoseHeart()
    {
        heartsVisible--;
        if (heartsVisible >= 0)
        {
            hearts[heartsVisible].enabled = false;
        }
    }
}
        

    


