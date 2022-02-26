using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private bool carry = false;
    private GameObject m_player;
    private Rigidbody m_Rigidbody;
    private RaycastHit m_Hit;
    private bool canDrop;
    private Vector3 stopPos;
    private Camera m_Camera;
    private bool HitWall;
    private void Start()
    {
        gameObject.tag = "Interactable"; //Tags the tag so the player knows it is interactable and will run this script if interacted with 
        if (gameObject.GetComponent<Rigidbody>() == null) //Setting Up ridgbody to freeze roation / Adds a RB if there isnt one
        {
            m_Rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        else
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

    }

    public void objectInteract(GameObject player , Camera camera)
    {
        m_Camera = camera;
        m_player = player;
        carry = true;
        
    }

    public bool objectDrop() // Function is called from player if the player cant drop the item then carry stays true
    {
        if (canDrop) // Item is dropped
        {
            carry = false;
            return false;
        }
        else // Item is not dropped
        {
            carry = true;
            return true;
        }
    }
    
    private void Update()
    {
        
        
            if (carry) // Carry is true it finds the players body and goes to the postision in front of it //Updated Added Raycast and now can move on all axis
            {
                //Transform cubeTransform = m_player.transform.Find("Player Body");
                //transform.position = cubeTransform.position + (cubeTransform.forward * 1.5f);

                Ray ray = m_Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out m_Hit, 3))
            {
                Debug.DrawLine(ray.origin, ray.GetPoint(3f), Color.blue, 1);
                if (HitWall)
                {
                    transform.position = ray.GetPoint(1f);
                }
                else
                {
                    transform.position = ray.GetPoint(1.75f);
                }
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.GetPoint(3f), Color.red, 1);
                if (HitWall)
                {
                    transform.position = ray.GetPoint(1f);
                }
                else
                {
                    transform.position = ray.GetPoint(1.75f);
                }
            
            }


            }
            else
            {
                transform.position = transform.position;
            }
 
        
    }


    public void objectRotate()
    {
        transform.Rotate(0, 90, 0);
    }

    private void OnCollisionEnter(Collision collision) //If the object is colliding with anything the player cant drop it
    {
        stopPos = transform.position;
        Debug.Log(stopPos);
        HitWall = true;
        canDrop = false; 
    }
    private void OnCollisionExit(Collision collision) // When the object has stoppped colliding with something it can be dropped
    {
        HitWall = false;
        canDrop = true;
    }


}
