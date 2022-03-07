using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MouseControl : MonoBehaviour
{
    public Vector2 MousePos;
    public GameObject _Cursor;
    public GameObject CursorPrefab;
    public GameObject canvas;
    private float MousePosX;
    private float MousePosY;
    private float KeyPress;
    private Controls controls;

    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        Cursor.lockState = CursorLockMode.Locked;
        _Cursor = Instantiate(CursorPrefab);
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        _Cursor.transform.parent = canvas.transform;
        _Cursor.transform.position = new Vector2 (600, 600);
    }

    // Update is called once per framea
    void Update()
    {
        MousePosX = MousePos.x + _Cursor.transform.position.x;
        MousePosY = MousePos.y + _Cursor.transform.position.y;
        _Cursor.transform.position = new Vector2(MousePosX, MousePosY);

        if(KeyPress == 1)
        {
            _Cursor.GetComponent<MouseCollisions>().Clicked = true;
        }
        if(KeyPress == 0)
        {
            _Cursor.GetComponent<MouseCollisions>().Clicked = false;
        }

    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        MousePos = context.ReadValue<Vector2>();
    }

    public void OnMouseClick(InputAction.CallbackContext context)
    {
        KeyPress = context.ReadValue<float>();
    }

}
