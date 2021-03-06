﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.Instance.MyRigidbody.gravityScale = 12.5f;
        FindObjectOfType<AudioManager>().Stop("run");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player.Instance.OnGround)
        {
            animator.SetBool("land", false);
            animator.SetBool("jump",false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //FindObjectOfType<AudioManager>().Play("land");
        Player.Instance.MyRigidbody.gravityScale = 5;

        if (animator.GetFloat("speed") > 0.01)
        {
            FindObjectOfType<AudioManager>().Play("run");
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
