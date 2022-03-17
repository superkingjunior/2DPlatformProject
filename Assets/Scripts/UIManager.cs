using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        transform.GetChild(3).GetComponent<Cooldown>().percentage = percentage;
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
            percentage = EaseInOutQuart(cooldown / cooldownTime);
        }
    }

    private static float EaseInOutQuart(float x) {
        return (x < 0.5) ? (8 * x* x* x* x) : (1 - Mathf.Pow(-2 * x + 2, 4) / 2);
    }

    private void LivesChange(int lives)
    { 
        if( _livesSprites.Length > lives - 1)
            _livesImg.sprite = _livesSprites[lives - 1];
        if(lives<= 0)
        {
            Debug.Log("LOSE");
            Lose();
        }
    }

    private void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }
}
