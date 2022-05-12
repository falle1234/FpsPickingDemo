using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.collider.name == "Target")
        {
            Debug.Log("You've won!");

            collision.collider.GetComponent<ParticleSystem>().Play();
        }
    }
}
