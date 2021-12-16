using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject player;
    [SerializeField] private float swipeDistance;

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
            animator.SetBool("IsStopped", true);
        }

        if (SwipeManager.running)
        {
            animator.SetBool("IsStopped", false);
            animator.SetBool("IsRunning", true);
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        }

        if (SwipeManager.swipeLeft)
        {
            animator.SetBool("SwipeLeft", true);
            rb.AddForce(Vector3.left * swipeDistance);
            //player.transform.Translate(Vector3.left * Time.deltaTime * swipeDistance, Space.World);
            Debug.Log("Left");
        }

        if (SwipeManager.swipeRight)
        {
            animator.SetBool("SwipeRight", true);
            rb.AddForce(Vector3.right * swipeDistance);
           // player.transform.Translate(Vector3.right * Time.deltaTime * swipeDistance, Space.World);
            Debug.Log("Right");
        }

        if (SwipeManager.swipeUp)
        {
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * swipeDistance);
            Debug.Log("Up");
        }
    }
}



/*    if (Input.touchCount > 0 && !SwipeManager.swipeRight && !SwipeManager.swipeLeft)
    {
        animator.SetBool("IsStopped", false);
        animator.SetBool("IsRunning", true);
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        isStarted = true;
        //Debug.Log("Runnig");
    }

    if (isStarted && Input.touchCount == 0)
    {
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsStopped", true);
        //Debug.Log("Stopped");
    }

*/

