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

    private static float percentage = 1f;

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        transform.GetChild(4).GetComponent<Cooldown>().percentage = percentage;
    }

    public static void UpdateLives(int currentLives)
    {
        instance.LivesChange(currentLives);
    }

    public static void UpdatePercentCooldown(float cooldown, float cooldownTime)
    {
        if(cooldown > cooldownTime)
        {
            percentage = 1f;
        }
        else
        {
            percentage = cooldown / cooldownTime;
        }
    }

    private void LivesChange(int lives)
    { 
        if( _livesSprites.Length > lives - 1)
            _livesImg.sprite = _livesSprites[lives - 1];
    }
}
