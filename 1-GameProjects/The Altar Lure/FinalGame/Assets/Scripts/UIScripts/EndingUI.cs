using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndingUI : MonoBehaviour
{
    /// <summary>
    /// Setting the main components used for the UI  with
    /// the button and textfield.
    /// </summary>
    private Button PlayButton;
    private static readonly string ButtonPlay = "PlayButton";

    private Label TitleLabel;
    private static readonly string LableTitle = "Title";

    /// <summary>
    /// Setting the UI from the UIDocument and setting the labels with different text
    /// </summary>
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();

        PlayButton = uiDocument.rootVisualElement.Q<Button>(ButtonPlay);
        TitleLabel = uiDocument.rootVisualElement.Q<Label>(LableTitle);

        PlayButton.RegisterCallback<ClickEvent>(NextScene);

        PlayButton.text = "Return to Main Menu";
        TitleLabel.text = "Game over";
    }

    /// <summary>
    /// Deactivating the button
    /// </summary>
    private void OnDisable()
    {
        PlayButton.UnregisterCallback<ClickEvent>(NextScene);
    }

    /// <summary>
    /// If the button is pressed, it loads the scene to the main menu scene
    /// </summary>
    /// <param name="evt"></param>
    private void NextScene(ClickEvent evt)
    {
        SceneManager.LoadScene(0);
    }

    
}
