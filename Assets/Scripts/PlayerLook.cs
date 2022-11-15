using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera camera;
    private float xRotation = 45f;

    public float xSensitivity = 100f;
    public float ySensitivity = 30f;
    
    public void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ProcessLook(Vector2 input){
        float mouseX = input.x;
        float mouseY = input.y;
        
        // calculate camera rotation for y axis
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        // restrict up and down looking
        xRotation = Mathf.Clamp(xRotation, 10f, 50f);
        // apply to camera transform
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // rotate left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
