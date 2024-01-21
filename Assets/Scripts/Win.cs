using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameManager gameManager;
    public Text winText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameManager.keyCount == gameManager.needOtOpen)
            {
                Time.timeScale = 0;
                gameManager.Winner();
                unlockNextLevel();
                //SceneManager.LoadScene(0);
            }
            else
            {
                winText.text = "Hii! You Have Not Enough Coin, Get at lest " + gameManager.needOtOpen.ToString() + " coin";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        winText.text = " ";
    }

    void unlockNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedLevel"))
        {
            PlayerPrefs.SetInt("ReachedLevel", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockLevel", PlayerPrefs.GetInt("UnlockLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

}
