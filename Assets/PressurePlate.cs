using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    private bool Triggered;
    public UnityEvent PressurePlateTriggered;
    private bool PlayerReset;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Interactable")
        {
            if (!PlayerReset)
            {
                PressurePlateTriggered.Invoke();
                PlayerReset = true;
            }


        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Interactable")
        {
            PlayerReset = false;
        }

    }

}
