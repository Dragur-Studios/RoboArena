using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{

    [SerializeField] Vector2 sensitivity = Vector2.one;
    [SerializeField] float rotationSpeed = 5.0f;
    [SerializeField] float minLookAngle = -35.0f;
    [SerializeField] float maxLookAngle = 35.0f;

    float yaw, pitch = 0;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InteractionHandler>().isInteracting)
            return;

        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // handle yaw
        yaw += mouseDelta.x * (rotationSpeed * sensitivity.x) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, yaw, 0);

        // handle pitch(dont forget to clamp)
        pitch -= mouseDelta.y * (rotationSpeed * sensitivity.y) * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minLookAngle, maxLookAngle);

        cam.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
