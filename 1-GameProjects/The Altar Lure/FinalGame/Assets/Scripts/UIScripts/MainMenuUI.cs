using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    /// <summary>
    /// Setting the button used for the UI
    /// </summary>
    private Button PlayButton;
    private static readonly string ButtonPlay = "PlayButton";

    /// <summary>
    /// Setting the UI from the UIDocument
    /// </summary>
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();

        PlayButton = uiDocument.rootVisualElement.Q<Button>(ButtonPlay);

        PlayButton.RegisterCallback<ClickEvent>(NextScene);
    }


    /// <summary>
    /// Deactivating the button
    /// </summary>
    private void OnDisable()
    {
        PlayButton.UnregisterCallback<ClickEvent>(NextScene);
    }

    /// <summary>
    /// Change the scene to the next scene up, or in this case the main
    /// gameplay
    /// </summary>
    /// <param name="evt"></param>
    private void NextScene(ClickEvent evt)
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }

    

  
}
