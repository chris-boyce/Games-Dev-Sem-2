using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWithObject : MonoBehaviour
{
    private float interact;
    private float onRotate;
    public Camera playerCamera;
    private float hit;
    public Transform player;
    private GameObject m_Player;
    private GameObject lastObject;
    public int m_playerID;
    private Controls controls;
    private bool itemPickup = false;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
        m_playerID = PlayerCountID.getPlayerID();
        m_Player = this.gameObject;
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        interact = context.ReadValue<float>();
    }
    public void OnRotateObject(InputAction.CallbackContext context)
    {
        onRotate = context.ReadValue<float>();
    }


    private void Update()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (controls.Gameplay.Interact.triggered && interact == 1)
        { 
            if(itemPickup)
            {
                lastObject.transform.GetComponent<InteractScript>().objectDrop();
                itemPickup = false;
            }
            else if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.green, 2);
                if (hit.transform.tag == "Interactable")
                {
                    itemPickup = !itemPickup;
                    lastObject = hit.transform.gameObject;
                    hit.transform.GetComponent<InteractScript>().objectInteract(m_Player);

                }
                else if (hit.transform.tag == "Readable")
                {
                    hit.transform.GetComponent<ReadScript>().objectInteract(m_Player , m_playerID);
                }
            }

        }
        if(controls.Gameplay.Rotate.triggered && onRotate == 1 && itemPickup)
        {
            lastObject.GetComponent<InteractScript>().objectRotate();
        }
                  
    }

}
