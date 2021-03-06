﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/Jump")]
public class Jump : StateData
{
    public float jumpForce;
    public float StartJumpTime;
    public float EndJumpTime;
    public AnimationCurve Gravity;
    public AnimationCurve Pull;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * jumpForce);
        animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        animator.SetBool(TransitionParameter.Jump.ToString(), true);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        control.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
        control.PullMultiplier = Pull.Evaluate(stateInfo.normalizedTime);
        animator.SetBool(TransitionParameter.Jump.ToString(), true);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);
        animator.SetBool(TransitionParameter.Jump.ToString(), false);
    }
}

