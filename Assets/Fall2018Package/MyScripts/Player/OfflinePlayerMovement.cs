using UnityEngine;
using System;
using System.Collections;

public class OfflinePlayerMovement : MonoBehaviour
{
    public Animator animator;
    private bool m_IsGrounded;
    public Rigidbody rb;
    public bool m_Stay;

    public float m_velocity = 10.0f;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        if (animator)
        {
            //fall down if not on ground
            //animator.applyRootMotion = m_IsGrounded;
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
           
            animator.SetFloat("MovementForward", v);
            animator.SetFloat("MovementStrafe", h);
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, m_velocity);
        //m_IsGrounded = false;
        if (animator.GetFloat("Collider") < 0.5f || m_Stay == true)
        {
            m_IsGrounded = true;
        }
        if (animator.GetFloat("Collider") > 0.5f && m_Stay == false)
        {
            m_IsGrounded = false;
        }

        if (m_IsGrounded == false)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5, Space.World);
            //animator.SetBool("IsFalling", true);
        }

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, m_velocity);
        //m_IsGrounded = false;
        m_Stay = false;
    }
    void OnCollisionStay() //Liang, switch this to a raycast down to check for ground, I think that will give us more room for error. Right now when going up ramps it tries to transition
    {
        m_Stay = true;
        //m_IsGrounded = true;
    }
}