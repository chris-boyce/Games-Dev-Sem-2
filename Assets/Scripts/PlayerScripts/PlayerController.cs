using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input Values")]
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private Vector2 lookInput;
    [SerializeField] private float JumpValue;

    [Header("Players components")]
    public Rigidbody playerRB;
    public Transform playerHead;
    private Controls controls;

    [Header("Players components")]
    [SerializeField] private float topSpeed = 10f;
    [SerializeField] private float sensX = 10;
    [SerializeField] private float sensY = 10;
    [SerializeField] private float speed = 100f;
    
    private float camRotation;
    private float lookAngleRange = 60;
    private bool canJump;

    private void Awake() //sets control scheme
    {
        controls = new Controls();
    }
    private void OnEnable() // When the player is enabled
    {
        controls.Enable(); //Control enables
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    //Gives Values From the input system to check 
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        JumpValue = context.ReadValue<float>();
    }

    //Locks Mouse
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update()
    {
        //Player Movement controlled by New Input System
        // Checks the Vector of the stick or keyboard press and translates that into direction. Then adds force realitive to the direction the player is facing
        if (movementInput != Vector2.zero) 
        {
            playerRB.AddRelativeForce(new Vector3(movementInput.x * speed * Time.deltaTime, 0, movementInput.y * speed * Time.deltaTime), ForceMode.VelocityChange);
        }
        //Caps the players top speed so the player is more controlable
        if (playerRB.velocity.magnitude > topSpeed) 
        {
            playerRB.velocity = playerRB.velocity.normalized * topSpeed;
        }
        //Player Looking System (Uses the processors to change Sens Between different controllers)
        if (lookInput != Vector2.zero) 
        {
            playerRB.transform.Rotate(new Vector3(0, lookInput.x * sensX * Time.deltaTime), Space.Self);
            
            camRotation += lookInput.y / sensY;
            camRotation = Mathf.Clamp(camRotation, -lookAngleRange, lookAngleRange);
            playerHead.localRotation = Quaternion.Euler(-camRotation, 0, 0);
        }
        //If the player has press the jump key //Checks it is just pressed once
        if (controls.Gameplay.JumpButton.triggered && JumpValue == 1 && canJump)
        {
            playerRB.AddForce(new Vector3(0, 400f, 0));
            canJump = false;
            playerRB.drag = 2f; //Adds Grace Period for player when in air
        }
 
    }
    private void OnTriggerEnter(Collider other) //Check if player is touching the ground
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Interactable")) //Objects that can be Jumped on
        {
            canJump = true;
            playerRB.drag = 0.1f;
        }

    }

}
