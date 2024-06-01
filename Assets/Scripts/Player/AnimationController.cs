using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;
    Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool pressForward = Input.GetKey("w");
        bool pressLeftward = Input.GetKey("a");
        bool pressBackward = Input.GetKey("s");
        bool pressRightward = Input.GetKey("d");
        bool pressFire = Input.GetMouseButton(0);

        if (!isRunning && (pressForward || pressRightward || pressBackward || pressLeftward))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && !(pressForward || pressRightward || pressBackward || pressLeftward))
        {
            animator.SetBool(isRunningHash, false);
        }

        if (pressFire)
        {
            animator.SetBool("isShooting", true);
            animator.SetBool("isRunning", false);
            rb.maxLinearVelocity = 2f;
        }

        if (!pressFire)
        {
            animator.SetBool("isShooting", false);
            rb.maxLinearVelocity = 10000f;
        }

    }
}
