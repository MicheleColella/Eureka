using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    public Animator _animator;
    public PlayerTouchMovement PlayerMovement;

    public void PlayIdle()
    {
        //_animator.Play("Idle");
        //Debug.Log("Idle");
        _animator.SetBool("Running", false);
        //_animator.SetTrigger("Idle");
    }

    public void PlayRun()
    {
        // _animator.Play("Run");
        //Debug.Log("Run");

        _animator.SetFloat("RunSpeed", (1.3f * (PlayerMovement._movespeed/5)));
        _animator.SetBool("Running", true);
        //_animator.SetTrigger("Run");
    }

    public void PlayDeath()
    {
        // _animator.Play("Run");
        //Debug.Log("Run");
        _animator.SetBool("Death", true);
        //_animator.SetTrigger("Run");
    }

    public void RePlayIdle()
    {
        // _animator.Play("Run");
        //Debug.Log("Run");
        _animator.SetBool("Death", false);
        _animator.SetBool("Running", false);
        //_animator.SetTrigger("Run");
    }
}
