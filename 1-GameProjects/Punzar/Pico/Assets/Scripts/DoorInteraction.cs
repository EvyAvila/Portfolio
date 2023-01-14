using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public MainPlayerInteractions keysCollected;
    public MainPlayer player;

    public Text DoorStatusText;

    // Start is called before the first frame update
    void Start()
    {
        DoorStatusText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainPlayer" && this.keysCollected.KeysAmount < this.keysCollected.TotalAmountOfKeys.Length)
        {
            DoorStatusText.text = $"The Door is closed. You don't have enough keys to unlock";
        }
        else if (collision.gameObject.tag == "MainPlayer" && this.keysCollected.KeysAmount == this.keysCollected.TotalAmountOfKeys.Length)
        {
            player.playerState = PlayerState.Win;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DoorStatusText.text = "";
    }
}
