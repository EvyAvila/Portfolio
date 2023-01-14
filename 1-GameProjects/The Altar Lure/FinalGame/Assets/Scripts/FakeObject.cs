using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeObject : MonoBehaviour
{
    /// <summary>
    /// Used to trick the player that they have picked up the main object, but in
    /// reality it's a fake object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
