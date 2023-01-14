using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUI : MonoBehaviour
{
    /// <summary>
    /// Setting the main components used for the UI with
    /// the two labels
    /// </summary>
    public static Label RoomLabel;
    private static readonly string LabelRoom = "Location";

    private Label ItemListLabel;
    private static readonly string LabelItemList = "ItemsList";

    /// <summary>
    /// Used to find the main player
    /// </summary>
    private GameObject mainPlayer;


    private void Start()
    {
        if(mainPlayer == null)
        {
            mainPlayer = GameObject.Find("Player");
        }
        DisplayList();
        RoomLabel.text = "Hallway";
    }

    /// <summary>
    /// Setting the UI from the UIDocument
    /// </summary>
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();

        RoomLabel = uiDocument.rootVisualElement.Q<Label>(LabelRoom);

        ItemListLabel = uiDocument.rootVisualElement.Q<Label>(LabelItemList);
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// A method that displays the required collections for the user the find
    /// </summary>
    private void DisplayList()
    {
        foreach(var c in mainPlayer.GetComponent<PlayerInventory>().RequiredCollectable)
        {
            ItemListLabel.text += "\n" + c.name;

        }
    }
}
