using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool pressForward = Input.GetKey("w");
        bool pressLeftward = Input.GetKey("a");
        bool pressBackward = Input.GetKey("s");
        bool pressRightward = Input.GetKey("d");

        if (!isRunning && (pressForward || pressRightward || pressBackward || pressLeftward))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && !(pressForward || pressRightward || pressBackward || pressLeftward))
        {
            animator.SetBool(isRunningHash, false);
        }

    }
}
