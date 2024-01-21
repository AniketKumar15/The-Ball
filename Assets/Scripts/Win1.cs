using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Win1 : MonoBehaviour
{
    public GameManager gameManager;
    public Text winText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameManager.keyCount == gameManager.needOtOpen)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

}
