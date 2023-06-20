using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkActorLocomotionHandler : MonoBehaviour
{
    public float MoveSpeed = 3.75f;
    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 direction = Vector3.zero;
        direction += Camera.main.transform.forward * movementInput.y; 
        direction += Camera.main.transform.right * movementInput.x;
        direction.y = 0;
        direction.Normalize();

        Vector3 targetPosition = transform.position;
        targetPosition += direction * MoveSpeed * Time.deltaTime;


        transform.position = targetPosition;

    }
}
