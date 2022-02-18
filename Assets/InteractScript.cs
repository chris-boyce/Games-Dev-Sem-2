using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private bool carry = false;
    private GameObject m_player;
    private Collider m_Collider;
    private bool canDrop;

    private void Start()
    {
        gameObject.tag = "Interactable";
        m_Collider = GetComponent<Collider>();
   
    }

    public void objectInteract(GameObject player)
    {
        m_player = player;
        carry = true;
        
    }

    public void objectDrop()
    {
        if (canDrop)
        {
            carry = false;
        }
    }
    


    private void Update()
    {
        if(carry)
        {
            Transform cubeTransform = m_player.transform.Find("Player Body");
            transform.position = cubeTransform.position + (cubeTransform.forward * 1.5f);
            
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
    private void OnCollisionEnter(Collision collision)
    {
        canDrop = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        canDrop = true;
    }


}
