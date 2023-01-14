using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSheetMovement : MonoBehaviour
{
    /// <summary>
    /// The int is the speed in which the 
    /// music sheet or game object will move
    /// </summary>
    public int RotateSpeed = 100;

    /// <summary>
    /// Using Transform to rotate the music sheet in place constantly
    /// </summary>
    Transform ItemTransform;

    // Start is called before the first frame update
    /// <summary>
    /// For the start, the transform gets the component Transform since
    /// I won't be using this.transform.Rotate();
    /// </summary>
    void Start()
    {
        ItemTransform = this.GetComponent<Transform>();
    }

    /// <summary>
    /// The update sets the rotation in the y axis with the 
    /// Rotation speed
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        ItemTransform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
    }
}
