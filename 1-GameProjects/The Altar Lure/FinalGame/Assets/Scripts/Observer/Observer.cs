using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    /// <summary>
    /// An abstract class and method to notify the objects from the subject
    /// </summary>
    /// <param name="subject"></param>
    public abstract void Notify(Subject subject);
    public abstract void Notify(Vector3 vec);
}
