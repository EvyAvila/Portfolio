using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for the keys that are floating to have some
/// movement instead of standing still
/// </summary>
public class KeyMovement : MonoBehaviour
{
    /// <summary>
    /// An int value that sets the speed in which
    /// the key rotataes
    /// </summary>
    public int RotateSpeed = 100;

    /// <summary>
    /// Using Transform to rotate the key in place constantly
    /// </summary>
    Transform ItemTransform;

    /// <summary>
    /// For the start, the transform gets the component Transform since
    /// I won't be using this.transform.Rotate();
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        ItemTransform = this.GetComponent<Transform>();
    }

    /// <summary>
    /// The update sets the rotation in the x axis with the 
    /// Rotation speed
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        ItemTransform.Rotate(RotateSpeed * Time.deltaTime, 0, 0);
    }
}
