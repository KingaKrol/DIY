using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Image Win;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Princess")
        {
            Win.gameObject.SetActive(true);
            audioSource.Play();
            Time.timeScale = 0;
        }
    }
}
