using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 10f;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private Vector2 lookInput;
    public Rigidbody playerRB;
    private float topSpeed = 10f;
    [SerializeField] private float sens = 10;
    private float camRotation;
    private float lookAngleRange = 60;
    public Transform playerHead;
    
    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Update()
    {
        if (movementInput != Vector2.zero) //Applys Realtive force
        {
            playerRB.AddRelativeForce(new Vector3(movementInput.x * speed * Time.deltaTime, 0, movementInput.y * speed * Time.deltaTime), ForceMode.Impulse);
        }

        if (playerRB.velocity.magnitude > topSpeed) // Caps Top Speed
        {
            playerRB.velocity = playerRB.velocity.normalized * topSpeed;
        }

        if (lookInput != Vector2.zero) 
        {
            playerRB.transform.Rotate(new Vector3(0, lookInput.x * sens * Time.deltaTime), Space.Self);
            camRotation += lookInput.y / 1.5f;
            camRotation = Mathf.Clamp(camRotation, -lookAngleRange, lookAngleRange);
            playerHead.localRotation = Quaternion.Euler(-camRotation, 0, 0);
        }
        
    }

}
