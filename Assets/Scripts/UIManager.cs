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

    public static int livesUI = 9;

    

    void Awake()
    {

        if ((instance != null) && (instance != this))
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            if (livesUI > 0)
            {
                _livesImg.sprite = _livesSprites[livesUI - 1];
            }
            
        }
        

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

    //Easing function for the cooldown bar
    private static float EaseInOutQuart(float x) {
        return (x < 0.5) ? (8 * x* x* x* x) : (1 - Mathf.Pow(-2 * x + 2, 4) / 2);
    }

    //Changes the lives
    private void LivesChange(int lives)
    {
        if (lives <= 0)
        {
            Lose();
        }
        else if ( _livesSprites.Length > lives - 1)
            _livesImg.sprite = _livesSprites[lives - 1];
        
    }

    private void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }
}
