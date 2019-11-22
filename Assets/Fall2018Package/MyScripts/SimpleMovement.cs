using System;
using UnityEngine;
using UnityEngine.Events;


public class SimpleMovement : MonoBehaviour
{
    [Multiline]
    public string userDescription = "";


    public KeyCode yPositive = KeyCode.D;
    public KeyCode activate = KeyCode.Space;    

    public UnityEvent DamageEvent;

    private void Update()
    {
        //Vector3 moveNormal = new Vector3(Horizontal, Vertical, 0.0f).normalized;

        //transform.position += moveNormal * Time.deltaTime * MoveRate;
    }



}
