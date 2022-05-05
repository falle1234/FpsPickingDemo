using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    Transform holdParent;

    GameObject heldObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 5f, layerMask))
                {
                    PickupObject(hitInfo.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if(heldObject != null)
        {
            MoveObject();
        }
    }

    private void DropObject()
    {
        var rigidBody = heldObject.GetComponent<Rigidbody>();
        rigidBody.useGravity = true;
        rigidBody.drag = 1f;
        heldObject.transform.parent = null;
        heldObject = null;
    }

    private void MoveObject()
    {
        if (Vector3.Distance(holdParent.transform.position, heldObject.transform.position) > 0.1f)
        {
            var moveDirection = holdParent.transform.position - heldObject.transform.position;
            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * Time.deltaTime * 100);
        }
    }

    private void PickupObject(GameObject gameObject)
    {
        gameObject.transform.parent = holdParent;
        var rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        rigidBody.drag = 10f;

        heldObject = gameObject;
    }
}
