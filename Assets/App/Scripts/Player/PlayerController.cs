using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float swipeDistance;
    [SerializeField] private float doubleJumpMultiplier;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;

    private bool canDoubleJump = false;
    private bool canJump = false;

    private void Awake()
    {

    }
    void Start()
    {

    }

    void Update()
    {

        if (!SwipeManager.tap)
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("SwipeLeft", false);
            animator.SetBool("SwipeRight", false);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJumping", false);
            animator.SetBool("IsStopped", true);
        }

        if (SwipeManager.swipeUp)
        {
            animator.SetBool("IsStopped", false);
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * swipeDistance);
            Debug.Log("Up");
            canDoubleJump = true;
        }
        if (SwipeManager.swipeUp && canDoubleJump)
        {
            animator.SetBool("IsStopped", false);
            animator.SetBool("IsDoubleJumping", true);
            rb.AddForce(Vector3.up * doubleJumpMultiplier);
            canDoubleJump = false;
        }

        if (SwipeManager.running)
        {
            animator.SetBool("IsStopped", false);
            animator.SetBool("IsRunning", true);
            transform.Translate(Vector3.forward * Time.deltaTime * runSpeed, Space.World);
        }

        if (SwipeManager.swipeLeft)
        {
            animator.SetBool("SwipeLeft", true);
            rb.AddForce(Vector3.left * swipeDistance);
            Debug.Log("Left");
        }

        if (SwipeManager.swipeRight)
        {
            animator.SetBool("SwipeRight", true);
            rb.AddForce(Vector3.right * swipeDistance);
            Debug.Log("Right");
        }

    }
}