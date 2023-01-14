using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraScriptEssay : MonoBehaviour
{
    //a transform that tracks the position of the watch object
    public Transform WatchObject;
    
    //a vector to change or receive position if needed
    public Vector3 WatchDirection;

    //a bool to have the watch rotate in a specific direction
    public bool ChangeDirection;

    // Start is called before the first frame update
    // The values are set for the Direction and boolean
    void Start()
    {
        WatchDirection = new Vector3(WatchObject.position.x, WatchObject.position.y, WatchObject.position.z -1f);
        transform.position = WatchDirection;
        ChangeDirection = false;
    }

    // Update is called once per frame
    // It contains a method to prevent too many actions taking place inside update.
    void Update()
    {
        ChangeCameraPosition();
    }

    //Uses input to change the position and/or rotation of the camera. 
    //It might also change which direction the watch object will be moving
    private void ChangeCameraPosition()
    {
        var keyboard = Keyboard.current;

        if (keyboard.digit1Key.isPressed)
        {
            ChangeDirection = true;
            ChangeWatchPosition(0.5f, 0.4f, -1.25f);
            transform.position = WatchDirection;
        }
        else if (keyboard.digit2Key.isPressed)
        {
            ChangeWatchPosition(0.2f, 0.4f, -1.15f);
            transform.position = WatchDirection;
            ChangeCameraRotation(0, -20, 0);

        }
        else if (keyboard.digit3Key.isPressed)
        {
            ChangeWatchPosition(-0.2f, 0.4f, -1.15f);
            transform.position = WatchDirection;
            ChangeCameraRotation(0, 20, 0);

        }
        //More key inputs would be added for different positions and rotations. 
        //It's currently displaying the first 5 seconds of the watch video
    }

    //Method was extracted to prevent typing long code many times. 
    //In this case, the rotation of the camera which will only happen once
    private void ChangeCameraRotation(float xV, float yV, float zV)
    {
        transform.rotation = Quaternion.Euler(xV, yV, zV);
    }

    //Method was extracted to prevent typing long code many time.
    //In this case, changing the WatchDirection to a new value if needed.
    private void ChangeWatchPosition(float xValue, float yValue, float zValue)
    {
        WatchDirection = new Vector3(WatchObject.position.x + xValue, WatchObject.position.y + yValue, WatchObject.position.z + zValue);
    }
}
