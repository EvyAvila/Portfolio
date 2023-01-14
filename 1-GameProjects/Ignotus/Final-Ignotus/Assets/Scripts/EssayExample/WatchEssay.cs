using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WatchEssay : MonoBehaviour
{
    //A float to set the speed of the rotation that can be altered for all
    //times it is called
    public float RotateSpeed;

    //Get the script of camera for the condition of the boolean
    public CameraScriptEssay cameraCondition;

    // Start is called before the first frame update
    // Mainly setting the RotateSpeed of a low number
    void Start()
    {
        RotateSpeed = 2;
        
    }

    // Update is called once per frame
    // It check whether the condition from the camera script called ChangeDirection is
    // true or false. The reason for this is to allow the object to rotate when needed
    void Update()
    {

        if (cameraCondition.ChangeDirection)
        {
            transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
        }
        
        if(!cameraCondition.ChangeDirection)
        {
            transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
        }
    }

}
