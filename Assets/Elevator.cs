using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private int playerCount;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hello");
            playerCount++;
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCount--;
        }
            
    }
    private void Update()
    {
        Debug.Log(playerCount);
        if(playerCount >= 4)
        {
            rb.AddForce(transform.up * 20);
        }
    }

}
