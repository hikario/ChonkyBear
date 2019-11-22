using UnityEngine;
using System;
using System.Collections;

public class PlayerAnimatorController : MonoBehaviour
{
    protected Animator animator;    
    void Start()
    {       
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        if (animator)
        {            
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            animator.SetFloat("MovementForward", v );
            animator.SetFloat("MovementStrafe", h );
        }
    }
}

