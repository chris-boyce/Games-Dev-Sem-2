using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EPOOutline;

public class InteractWithObject : MonoBehaviour
{
    [Header("Camera and Body GOs")]
    public Camera playerCamera;
    public Transform player;

    [Header("Players Assigned ID")]
    [SerializeField] private int m_playerID;

    //Components Needed by Player
    private GameObject m_Player;
    public GameObject lastObject;
    private Controls controls;

    //Float to measure KeyPress
    public float interact;
    private float onRotate;

    //Checks on Obj PickedUp
    private bool isItemBeenDropped;
    private bool itemPickup = false;
    public bool ItemCall = false;

    private GameObject OutlineGO;

    private void Awake() //sets control scheme
    {
        controls = new Controls();
    }

    private void OnEnable() // When the player is enabled
    {
        controls.Enable(); //Control enables
        m_playerID = PlayerCountID.getPlayerID(); //Gets and sets player ID so object know what player to attach to.
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

        HighlightUpdate();

        if (controls.Gameplay.Interact.triggered && interact == 1) // If the player is clicking interact / Sends onces
        { 
            if(itemPickup) // Itempickup = Has player got item in hand
            {
                DropItem();
                
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
                else if (hit.transform.tag == "Lever") // If object is Lever it will run flip switch
                {
                    hit.transform.GetComponent<LeverSwitch>().FlipSwitch();
                }
            }

        }
        if(controls.Gameplay.Rotate.triggered && onRotate == 1 && itemPickup) // if player is pressing rotate button / does it once / and item pickup is true / call object roate in the interact script.
        {
            lastObject.GetComponent<InteractScript>().objectRotate();
        }
                  
    }

    private void DropItem()
    {
        isItemBeenDropped = lastObject.transform.GetComponent<InteractScript>().objectDrop(); // Script runs the drop and returns if the item was dropped.
        itemPickup = isItemBeenDropped; //If item is dropped hand is classed as empty if item not dropped the hand is classed as full.
    }
    public void DestroyCube()
    {
        DropItem();
        lastObject = null;
        itemPickup = false;
    }

    public GameObject CheckHand()
    {
        return lastObject;
    }
    void HighlightUpdate()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Shoots ray in the middle of players screen
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3)) 
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.green, 3);
            if (hit.transform.tag == "Interactable")
            {
                hit.transform.GetComponent<Outlinable>().enabled = true;
                OutlineGO = hit.transform.gameObject;
            }
        }
        else
        {
            if(OutlineGO != null)
            {
                OutlineGO.GetComponent<Outlinable>().enabled = false;
            }
            
        }
    }


}
