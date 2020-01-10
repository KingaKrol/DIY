using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/PlayAudio")]
public class PlayAudio : StateData
{
    public AudioClip audioClip;
    public bool running;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        AudioSource audioSource = animator.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.enabled = true;
        audioSource.Play();
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        AudioSource audioSource = animator.GetComponent<AudioSource>();
        if (running)
        {
            audioSource.Stop();
        }
                 
        
    }
}

