using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    //The float is the speed of the rotation for the star
    //instead of staying still
    public float RotateSpeed;

    // Start is called before the first frame update
    // It sets the RotateSpeed to a specifc value
    void Start()
    {
        RotateSpeed = 100;
    }

    // Update is called once per frame
    // Instead of creating a method by itself, the 
    // transform.Rotate() is set inside the update 
    // since the star will always be rotating until it destroys
    void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
    }
}
