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
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("01_Level");
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.O)|| Input.GetKeyDown(KeyCode.Joystick1Button6))
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
