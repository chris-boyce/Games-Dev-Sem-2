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
    private float speed;
    private bool rotateObject;
    private int counter;
    private void Start()
    {
        speed = 80f;
        gameObject.tag = "Interactable"; //Tags the tag so the player knows it is interactable and will run this script if interacted with 
        if (gameObject.GetComponent<Rigidbody>() == null) //Setting Up ridgbody to freeze roation / Adds a RB if there isnt one
        {
            m_Rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        else
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }
    }

    public void objectInteract(GameObject player, Camera camera)
    {
        m_Camera = camera;
        m_player = player;
        carry = true;
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

    private void FixedUpdate()
    {
        if (carry)
        {
            HoldCube();
            m_Rigidbody.drag = 12;
            m_Rigidbody.useGravity = false;
        }
        else
        {
            m_Rigidbody.drag = 1;
            transform.position = transform.position;
            m_Rigidbody.useGravity = true;
        }
    }

    void HoldCube()
    {
        Ray ray = m_Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawLine(ray.origin, ray.GetPoint(3f), Color.red, 1);
        Vector3 targetPos = ray.GetPoint(1.75f);

        float targetDistance = Vector3.Distance(transform.position, targetPos);
        if (rotateObject)
        {
            transform.Rotate(0, 90, 0);
            rotateObject = false;
        }
        else if (targetDistance > 0.1f)
        {
            Vector3 direction = targetPos - transform.position;
            m_Rigidbody.AddForce(direction.normalized * speed, ForceMode.Force);
            
        }
        
    }
    public void CubeIsDestroyed()
    {
        carry = false;
    }

    public void objectRotate()
    {
        rotateObject = true;
    }

    private void OnCollisionEnter(Collision collision) //If the object is colliding with anything the player cant drop it
    {
        canDrop = false; 
    }
    private void OnCollisionExit(Collision collision) // When the object has stoppped colliding with something it can be dropped
    {
        canDrop = true;
    }

}
