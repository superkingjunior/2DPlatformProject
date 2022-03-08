using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesImg;

    void Awake()
    {
        instance = this;
    }

    public static void updateLives(int currentLives)
    {
        
        instance.livesChange(currentLives);
    }

    private void livesChange(int lives)
    {
        _livesImg.sprite = _livesSprites[lives];
    }
}
