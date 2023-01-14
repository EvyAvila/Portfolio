using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    /// <summary>
    /// A containment for the observers
    /// </summary>
    private readonly ArrayList _observers = new ArrayList();

    /// <summary>
    /// Adding the observers into the arraylist containment
    /// </summary>
    /// <param name="observer"></param>
    protected void Attach(Observer observer)
    {
        _observers.Add(observer);
    }

    /// <summary>
    /// Removing the observers from the arraylist containment
    /// </summary>
    /// <param name="observer"></param>
    protected void Detach(Observer observer)
    {
        _observers.Remove(observer);
    }

    /// <summary>
    /// Used for the subject to notify all the observers
    /// </summary>
    protected void NotifyObserver()
    {
        foreach (Observer observer in _observers)
        {
            observer.Notify(this);
        }
    }

    protected void NotifyObserver(Vector3 tVec)
    {
        foreach (Observer observer in _observers)
        {
            observer.Notify(tVec);
        }

    }
}
