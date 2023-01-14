using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    /// <summary>
    /// Getting the scripts from the bathroom and the player
    /// </summary>
    public BathRoomUI bathroomUI;
    public MainPlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MainPlayerController>();
    }

    /// <summary>
    /// Checks to see if the player has entered the room of the bathroom.
    /// If so, the ui will display the ui. Otherwise, they will deactivate
    /// </summary>
    void Update()
    {
        if (player.RoomName == "BathRoom" && player.HasEnterRoom)
        {
            bathroomUI.gameObject.SetActive(true);
        }
        else
        {
            bathroomUI.gameObject.SetActive(false);
        }
    }
}
