using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetText : MonoBehaviour
{
    public GameObject inputField;
    public GameObject inputFieldIP;
    public GameObject textDisplay;
    private string Thename;
    private string TheIP;

    public void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void PlayerName()
    {
        TheIP = inputFieldIP.GetComponent<TextMeshProUGUI>().text;
        Thename = inputField.GetComponent<TextMeshProUGUI>().text;
        textDisplay.GetComponent<TextMeshProUGUI>().text = "Welcome " + Thename + " to the top G game\nYour IP is: " + TheIP;
    }
}
