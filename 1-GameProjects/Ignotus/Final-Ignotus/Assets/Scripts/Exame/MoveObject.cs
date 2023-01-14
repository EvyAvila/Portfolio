using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MoveObject : MonoBehaviour
{
    private float angle = 5;

    public Text score;
    private int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //score.text = currentScore;
        //score.text = "currentScore";
        //score.text = currentScore;
        score.text += $"{currentScore}";
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.left, angle * Time.deltaTime);
        var keyboard = Keyboard.current;

        if(keyboard.aKey.isPressed)
        {
            currentScore++;
            score.text = $"{currentScore}";
        }

        
    }
}
