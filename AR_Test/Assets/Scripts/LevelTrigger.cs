using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTrigger : MonoBehaviour
{
    public Image Win;
    public Image Lose;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Next"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("01_Level_01");
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.O)|| Input.GetButtonDown("Back"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("00_Tutorial");
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
