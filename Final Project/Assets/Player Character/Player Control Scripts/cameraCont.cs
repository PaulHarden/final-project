using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCont : MonoBehaviour
{
    float yaw;
    float pitch;
    public float mouseSense = 10f;
    public Transform target;
    public float camDistance = 3f;
    public bool lockCursor;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSense;
        pitch -= Input.GetAxis("Mouse Y") * mouseSense;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y); //Keeps cam from going over and all around. Can't look all the way up/down. 

        Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetRotation;

        transform.position = target.position - transform.forward * camDistance; // Makes camera rotate around the target object specifically. 
    }
}
