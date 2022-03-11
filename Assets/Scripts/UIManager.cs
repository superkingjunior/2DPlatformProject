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

    public static void UpdateLives(int currentLives)
    {
        instance.LivesChange(currentLives);
    }

    private void LivesChange(int lives)
    { 
        if( _livesSprites.Length > lives)
            _livesImg.sprite = _livesSprites[lives];
    }
}
