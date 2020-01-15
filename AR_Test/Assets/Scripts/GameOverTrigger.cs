using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTrigger : MonoBehaviour
{
    public Image losePrincess;
    public Image loseKnight;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Princess")
        {
            losePrincess.gameObject.SetActive(true);
            audioSource.Play();
            Time.timeScale = 0;
        }

        if (other.tag == "Player")
        {
            loseKnight.gameObject.SetActive(true);
            audioSource.Play();
            Time.timeScale = 0;
        }

    }
}
