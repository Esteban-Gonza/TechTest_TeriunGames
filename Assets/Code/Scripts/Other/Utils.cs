using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static IEnumerator PlayAnimAndSetState(GameObject parent, Animator animator, string clipName, bool activeState = true)
    {
        animator.Play(clipName);
        var animationLneght = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLneght);
        parent.SetActive(activeState);
    }
}