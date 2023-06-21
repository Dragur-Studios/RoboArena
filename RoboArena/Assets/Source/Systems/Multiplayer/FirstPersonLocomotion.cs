using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonLocomotion : MonoBehaviour
{
    public float MoveSpeed = 3.75f;

    Rigidbody rigi;

    private void Start()
    {
        rigi = GetComponent<Rigidbody>();
        rigi.freezeRotation = true;
    }

    Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 direction = Vector3.zero;
        direction += Camera.main.transform.forward * movementInput.y;
        direction += Camera.main.transform.right * movementInput.x;
        direction.y = 0;
        direction.Normalize();

        Vector3 movement = direction * MoveSpeed * Time.fixedDeltaTime;

        if (movementInput.magnitude > 0)
        {
            targetPosition = rigi.position + movement;
            rigi.MovePosition(targetPosition);
        }
        
    }
}
