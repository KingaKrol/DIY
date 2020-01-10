using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessTimer : MonoBehaviour
{
    public float speed;
    public float delay;
    public float timer;
    public Transform target;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.PlayDelayed(119f);
    }

    void Update()
    { 
        timer += Time.deltaTime;
        
        if (timer > delay)
        {           
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        
    }
}
