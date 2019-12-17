using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
class QuadrupedMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5;
    public float rotateSpeed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1);

        var direction = transform.forward;
        direction.y = 0; // just in case
        direction = Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotateSpeed, 0) * direction;
        var newRotation = Quaternion.Euler(direction);
        rb.MoveRotation(newRotation);

        rb.velocity = transform.TransformDirection(input) * speed;
    }
}