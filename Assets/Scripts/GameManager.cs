using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int keyCount = 0, needOtOpen = 2, tempKey;
    public float startTime, currentTime;

    public GameObject winner, lost;
    public Text timerText, coinText;
    private void Start()
    {
        tempKey = needOtOpen;
        Time.timeScale = 1;
        currentTime = startTime;
    }

    private void Update()
    {
        if(temKey >= 0)
        {
            coinText.text = "Coin Needed : " + tempKey.ToString();
        }
        
        timer();

        if (currentTime <= 0)
        {
            Time.timeScale = 0;
            losser();
        }
    }

    public void Winner()
    {
        winner.gameObject.SetActive(true);
    }
    public void losser()
    {
        lost.gameObject.SetActive(true);
    }

    public void timer()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = "Timer : " + currentTime.ToString("0");
    }
}
