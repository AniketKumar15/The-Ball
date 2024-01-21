using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public Button[] levelButtons;

    public void Awake()
    {
        int unlockLevel = PlayerPrefs.GetInt("UnlockLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for (int i = 0; i < unlockLevel; i++)
        {
            levelButtons[i].interactable = true;
        }
    }
}
