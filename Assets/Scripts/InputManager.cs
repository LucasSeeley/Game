using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.onFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        // every time jump is performed we use a callback contaxt to call the jump method
        // other options: started, canceled, performed
        onFoot.Jump.performed += ctx => motor.Jump();

        
    }

    void FixedUpdate()
    {
        // tell the playermotor to move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        
    }

    void LateUpdate(){
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        onFoot.Enable();

    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
