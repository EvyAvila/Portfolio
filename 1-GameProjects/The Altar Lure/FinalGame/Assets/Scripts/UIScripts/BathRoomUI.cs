using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BathRoomUI : MonoBehaviour
{
    /// <summary>
    /// Setting the main components used for the UI  with
    /// the button and textfield.
    /// </summary>
    private Button EnterButton;
    private static readonly string ButtonEnter = "EnterButton";

    private TextField RiddleInput;
    private static readonly string TextFieldInput = "RiddleInput";

    /// <summary>
    /// setting the correct answer to compare with the player's answer
    /// </summary>
    private string CorrectAnswer = "flower";

    /// <summary>
    /// The object that will display if the puzzle has been solved
    /// </summary>
    public GameObject FlowerCollectable;

    /// <summary>
    /// A bool that checks if the answer is correct
    /// </summary>
    public bool AnswerCorrect = false;

    

    private void Start()
    {
        FlowerCollectable.SetActive(false);
        
        this.gameObject.SetActive(false);
    }


    /// <summary>
    /// Setting the UI from the UIDocument and setting the label with the text of a riddle
    /// Found: https://www.riddles.nu/topics/life
    /// </summary>
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();


        EnterButton = uiDocument.rootVisualElement.Q<Button>(ButtonEnter);
        RiddleInput = uiDocument.rootVisualElement.Q<TextField>(TextFieldInput);

        EnterButton.RegisterCallback<ClickEvent>(EnterButtonAction);

        RiddleInput.label = "Close to the words of life stay I,\r\nBut I wither, wane, and grow dry.";
    }


    /// <summary>
    /// Deactivating the button
    /// </summary>
    private void OnDisable()
    {
        EnterButton.UnregisterCallback<ClickEvent>(EnterButtonAction);
    }

    /// <summary>
    /// When the button is pressed, it checks if the input value is the same 
    /// as the correct answer. If so, the flower becomes active for the 
    /// player to collect. If not, it sets the label value back to a
    /// default value
    /// </summary>
    /// <param name="evt"></param>
    private void EnterButtonAction(ClickEvent evt)
    {
        if(RiddleInput.value.ToLower().Trim() == CorrectAnswer)
        {
            FlowerCollectable.SetActive(true);
        }
        else
        {
            RiddleInput.value = "Enter answer";
        }
    }

}
