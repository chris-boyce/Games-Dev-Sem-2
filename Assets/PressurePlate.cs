using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [Header("When Pressureplate is activated or Deactivated")]
    public UnityEvent PressurePlateTriggered;
    public UnityEvent PressurePlateDeactivate;

    private bool PlayerReset;

    private void OnTriggerEnter(Collider other)
    {
        //If Player or Interactable Object has started Collision
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Interactable" || other.gameObject.tag == "Player2" || other.gameObject.tag == "Player") //List Could be Made?
        {
            if (!PlayerReset) //Reset to the plate so doesnt get called more than once at a time
            {
                PlayerReset = true;
                PressurePlateTriggered.Invoke();
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //If Player or Interactable Object has ended
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Interactable" || other.gameObject.tag == "Player2" || other.gameObject.tag == "Player")
        {
            PlayerReset = false;
            PressurePlateDeactivate.Invoke();
        }

    }

}
