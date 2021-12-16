using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickEnterButton()
    {
        canvas.SetActive(false);
        animator.SetBool("IsRunning", true);
    }
}
