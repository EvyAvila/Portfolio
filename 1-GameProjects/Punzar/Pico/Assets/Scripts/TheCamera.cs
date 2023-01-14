using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheCamera : MonoBehaviour
{
    public Transform player;
    public Vector2 Direction;

    public MainPlayer mainPlayer;
    public MainPlayerController controller;
    public GameObject Player;

    private Camera OrthographicCamera;

    public Text Winner;

    public Transform WinningScreen;

    // Start is called before the first frame update
    void Start()
    {
        OrthographicCamera = GetComponent<Camera>();
        Winner.text = "";
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + Direction.x, player.position.y + Direction.y, -2);
        CheckWin();
    }

    private void CheckWin()
    {
        if(mainPlayer.playerState == PlayerState.Win)
        {
            Winner.text = "Congrats! Press r to replay";

            CompareHealthResult();

            Player.SetActive(false);
            transform.position = new Vector3(WinningScreen.position.x, WinningScreen.position.y, -10);
            OrthographicCamera.orthographicSize = 30;
            RestartEntireGame();
        }
        else if(mainPlayer.playerState == PlayerState.Die)
        {
            Player.SetActive(false);
            RestartEntireGame();
        }
    }

    private void RestartEntireGame()
    {
        RestartGame.CanRestart = true;
        this.controller.ResetGame();
    }

    private void CompareHealthResult()
    {
        if (mainPlayer.HealthAmount == mainPlayer.HealthTotalAmount)
        {
            Winner.text += "\nWow, you are invincible!";
        }
        else if (mainPlayer.HealthAmount < mainPlayer.HealthTotalAmount)
        {
            Winner.text += "\nYou took some damage. Think you can do better?";
        }
    }
}
