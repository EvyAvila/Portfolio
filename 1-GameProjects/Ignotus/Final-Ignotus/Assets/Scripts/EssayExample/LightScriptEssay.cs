using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScriptEssay : MonoBehaviour
{
    //a transform that tracks the position of the watch object
    public Transform WatchObject;

    //a vector to set the direction of the light
    public Vector3 Direction;

    //an int value that sets how high or low the light will be
    private int LightHeight;

    // Start is called before the first frame update
    // Mainly gets the Direction basded on the watch position,
    // set the LightHeight to a speicifc number that can be altered, 
    // and setting the transform position as it only needs to occur once
    void Start()
    {
        Direction = WatchObject.position;
        LightHeight = 5;
        transform.position = new Vector3(Direction.x, LightHeight, Direction.z - 1);
    }

    // Update is called once per frame
    void Update()    {      }
}
