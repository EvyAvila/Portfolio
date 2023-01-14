using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    //Keeping this script

    public static bool CanRestart;

    public MainPlayer player;

    static void SetUp()
    {
        CanRestart = false;
    }

    private void Awake()
    {
        SetUp();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
