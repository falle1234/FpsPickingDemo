using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 300;
    [SerializeField]
    Transform playerBody;


    float rotateX = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        rotateX -= mouseY * sensitivity * Time.deltaTime;
        rotateX = Mathf.Clamp(rotateX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotateX, 0, 0);

        playerBody.Rotate(Vector3.up* mouseX * sensitivity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward*5, Color.green);
    }
}
