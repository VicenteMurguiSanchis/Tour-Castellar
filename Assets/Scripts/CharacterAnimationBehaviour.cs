using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationBehaviour : MonoBehaviour
{

    [SerializeField] Animator animator;

    public void ActivateIdle()
    {
        animator.SetBool("thank", false);
        animator.SetBool("salute", false);
        animator.SetBool("idle", true);
        animator.SetBool("1", false);
        animator.SetBool("2", false);
        animator.SetBool("3", false);
        animator.SetBool("4", false);
    }

    public void Activate1()
    {
        animator.SetBool("thank", false);
        animator.SetBool("salute", false);
        animator.SetBool("idle", false);
        animator.SetBool("1", true);
        animator.SetBool("2", false);
        animator.SetBool("3", false);
        animator.SetBool("4", false);
    }

    public void Activate2()
    {
        animator.SetBool("thank", false);
        animator.SetBool("salute", false);
        animator.SetBool("idle", false);
        animator.SetBool("1", false);
        animator.SetBool("2", true);
        animator.SetBool("3", false);
        animator.SetBool("4", false);
    }

    public void Activate3()
    {
        animator.SetBool("thank", false);
        animator.SetBool("salute", false);
        animator.SetBool("idle", false);
        animator.SetBool("1", false);
        animator.SetBool("2", false);
        animator.SetBool("3", true);
        animator.SetBool("4", false);
    }

    public void Activate4()
    {
        animator.SetBool("thank", false);
        animator.SetBool("salute", false);
        animator.SetBool("idle", false);
        animator.SetBool("1", false);
        animator.SetBool("2", false);
        animator.SetBool("3", false);
        animator.SetBool("4", true);
    }

    public void ActivateThanks()
    {
        animator.SetBool("thank", true);
        animator.SetBool("salute", false);
        animator.SetBool("idle", false);
        animator.SetBool("1", false);
        animator.SetBool("2", false);
        animator.SetBool("3", false);
        animator.SetBool("4", false);
    }

    public void ActivateSalute()
    {
        animator.SetBool("salute", true);
        animator.SetBool("thank", false);
        animator.SetBool("idle", false);
        animator.SetBool("1", false);
        animator.SetBool("2", false);
        animator.SetBool("3", false);
        animator.SetBool("4", false);
    }
}
