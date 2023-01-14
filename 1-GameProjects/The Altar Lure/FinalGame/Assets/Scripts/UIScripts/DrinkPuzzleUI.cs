using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DrinkPuzzleUI : MonoBehaviour
{
    /// <summary>
    /// Getting the scripts from the WineCellar room and the player
    /// </summary>
    public WineCellarRoomUI winecellarroomUI;
    public MainPlayerController player;

    private void Start()
    {
        
    }

    /// <summary>
    /// Checks to see if the player has entered the room of the wine cellar.
    /// If so, the ui will display the ui. Otherwise, they will deactivate
    /// </summary>
    void Update()
    {
        if (player.RoomName == "WineCellarRoom" && player.HasEnterRoom)
        {
            winecellarroomUI.gameObject.SetActive(true);
        }
        else
        {
            winecellarroomUI.gameObject.SetActive(false);
        }
    }

}
