using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHand : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void LoopAnimation()
    {
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0f);
    }
}