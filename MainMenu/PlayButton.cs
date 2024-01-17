using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public void ButtonPressed()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void IntroPressed()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
