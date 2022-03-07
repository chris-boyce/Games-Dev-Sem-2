using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MouseCollisions : MonoBehaviour
{
    public bool Clicked;
    private bool isOnButton;


    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Button")
        {
            collision.transform.GetComponent<Image>().color = Color.white;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Button")
        {
            collision.transform.GetComponent<Image>().color = Color.grey;
            if(Clicked == true)
            {
                collision.gameObject.GetComponent<ButtonHighlight>().isActivated = true;
            }

        }
    }
}
