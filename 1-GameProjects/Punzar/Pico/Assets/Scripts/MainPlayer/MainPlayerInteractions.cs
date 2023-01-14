using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerInteractions : MonoBehaviour
{

    public GameObject[] TotalAmountOfKeys;
    public int KeysAmount;
    public Text KeyAmountText;

    // Start is called before the first frame update
    void Start()
    {
        KeysAmount = 0;
        DisplayKeyMethod();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayKeyMethod();
    }

    private void DisplayKeyMethod()
    {
        KeyAmountText.text = $"Keys: {KeysAmount} / {TotalAmountOfKeys.Length}";
    }


}
