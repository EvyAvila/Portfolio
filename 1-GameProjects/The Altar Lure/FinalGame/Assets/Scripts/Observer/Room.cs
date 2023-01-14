using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Observer
{
    /// <summary>
    /// The player is the subject
    /// </summary>
    private MainPlayerController player;

    /// <summary>
    /// Checks if the player is null, it sets the subject to get
    /// the component. If it's not null, it'll display the name
    /// </summary>
    /// <param name="subject"></param>
    public override void Notify(Subject subject)
    {
        if(player == null)
        {
            player = subject.GetComponent<MainPlayerController>();
        }
        if(player != null)
        {
            DisplayName();
        }
    }

    /// <summary>
    /// Checks if the player has entered a room, it'll set the UI label 
    /// to the name of the room
    /// </summary>
    private void DisplayName()
    {
        if(player.HasEnterRoom) 
        {
            PlayerUI.RoomLabel.text = player.RoomName;
        }
        
    }

    public override void Notify(Vector3 vec)
    {
        this.transform.position = vec;  
    }
}
