using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WineCellarRoomUI : MonoBehaviour
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
    private string CorrectAnswer = "1102";

    /// <summary>
    /// The object that will display if the puzzle has been solved
    /// </summary>
    public GameObject DrinkCollectable;

    /// <summary>
    /// A bool that checks if the answer is correct
    /// </summary>
    public bool AnswerCorrect = false;


    // Start is called before the first frame update
    void Start()
    {
        DrinkCollectable.SetActive(false);

        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Setting the UI from the UIDocument and setting the label with the text of
    /// a statement of the day of the dead
    /// </summary>
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();


        EnterButton = uiDocument.rootVisualElement.Q<Button>(ButtonEnter);
        RiddleInput = uiDocument.rootVisualElement.Q<TextField>(TextFieldInput);

        EnterButton.RegisterCallback<ClickEvent>(EnterButtonAction);

        RiddleInput.label = "The date of the dead.";
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
    /// as the correct answer. If so, the drink becomes active for the 
    /// player to collect. If not, it sets the label value back to a
    /// default value
    /// </summary>
    /// <param name="evt"></param>
    private void EnterButtonAction(ClickEvent evt)
    {
        if (RiddleInput.value == CorrectAnswer)
        {
            DrinkCollectable.SetActive(true);
        }
        else
        {
            RiddleInput.value = "Enter answer";
        }
    }
}
