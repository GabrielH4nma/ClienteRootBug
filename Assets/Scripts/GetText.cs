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
    public GameObject textDisplayP;
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
        textDisplayP.GetComponent<TextMeshProUGUI>().text = Thename;
        textDisplay.GetComponent<TextMeshProUGUI>().text = "Welcome " + Thename + " to the top G game\nYour IP is: " + TheIP;
    }
}
