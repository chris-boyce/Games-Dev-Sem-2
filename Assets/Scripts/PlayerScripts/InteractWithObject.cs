using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWithObject : MonoBehaviour
{
    private float interact;
    private float onRotate;
    public Camera playerCamera;
    public Transform player;
    private GameObject m_Player;
    private GameObject lastObject;
    private bool isItemBeenDropped;
    public int m_playerID;
    private Controls controls;
    private bool itemPickup = false;

    private void Awake() //sets control scheme
    {
        controls = new Controls();
    }

    private void OnEnable() // When the player is enabled
    {
        controls.Enable(); //Control enables
        m_playerID = PlayerCountID.getPlayerID(); 
        m_Player = this.gameObject;
    }
    private void OnDisable()
    {
        controls.Disable();
    }


    //Checking on key and reads the context / information 
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
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Shoots ray in the middle of players screen
        RaycastHit hit;
        if (controls.Gameplay.Interact.triggered && interact == 1) // If the player is clicking interact / Sends onces
        { 
            if(itemPickup) // Itempickup = Has player got item in hand
            {
                isItemBeenDropped = lastObject.transform.GetComponent<InteractScript>().objectDrop(); // Script runs the drop and returns if the item was dropped.
                itemPickup = isItemBeenDropped; //If item is dropped hand is classed as empty if item not dropped the hand is classed as full.
            }
            else if (Physics.Raycast(ray, out hit , 3)) //If hand is empty send raycast out
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.green, 3); // Draw ray 
                if (hit.transform.tag == "Interactable") // If hit object that is Intecactable
                {
                    itemPickup = true; // Item is in hand
                    lastObject = hit.transform.gameObject; // Sets gameobject to lastobject so it can be refrenced later
                    hit.transform.GetComponent<InteractScript>().objectInteract(m_Player, playerCamera); //Get scipt and pass in what player is doing it

                }
                else if (hit.transform.tag == "Readable") // If object is reabable send in what player and the players ID
                {
                    hit.transform.GetComponent<ReadScript>().objectInteract(m_Player , m_playerID);
                }
            }

        }
        if(controls.Gameplay.Rotate.triggered && onRotate == 1 && itemPickup) // if player is pressing rotate button / does it once / and item pickup is true / call object roate in the interact script.
        {
            lastObject.GetComponent<InteractScript>().objectRotate();
        }
                  
    }

}