using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCoverCode : MonoBehaviour
{
    public bool coverSliding = false;
    public bool coverTouchingGround = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lowFriction")
        {
            coverSliding = true;
        }
        else
        {
            coverSliding = false;
        }

        if (other.gameObject.tag != "lowFriction")
        {
            coverTouchingGround = true;
        }
        else
        {
            coverTouchingGround = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "lowFriction")
        {
            coverSliding = true;
        }
        else
        {
            coverSliding = false;
        }

        if (other.gameObject.tag != "lowFriction")
        {
            coverTouchingGround = true;
        }
        else
        {
            coverTouchingGround = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        coverSliding = false;
        coverTouchingGround = false;
    }
}
