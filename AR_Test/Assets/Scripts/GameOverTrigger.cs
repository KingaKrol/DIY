using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTrigger : MonoBehaviour
{
    public Image Lose;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Princess")
        {
            Lose.gameObject.SetActive(true);
            audioSource.Play();
            Time.timeScale = 0;
        }

        if (other.tag == "Player")
        {
            Lose.gameObject.SetActive(true);
            audioSource.Play();
            Time.timeScale = 0;
        }

    }
}
