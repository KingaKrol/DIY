﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/Idle")]
public class Idle : StateData
{

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        // disable?
        //animator.SetBool(TransitionParameter.Jump.ToString(), false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.Jump)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), true);
        }

        if (control.MoveRight && control.MoveLeft)
        {

        }

        else if (control.MoveRight)
        {
            animator.SetBool(TransitionParameter.Move.ToString(), true);
        }

        else if (control.MoveLeft)
        {
            animator.SetBool(TransitionParameter.Move.ToString(), true);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }
}

