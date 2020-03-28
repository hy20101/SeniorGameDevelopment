using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnterName : MonoBehaviour
{
    private InputField Input;
    private string PlayerName;

    public void Awake()
    {
        Input = GameObject.Find("InputField").GetComponent<InputField>();
        PlayerName = "";
        //Hide();
    }

    public void GetInput(string Tname)
    {
        PlayerName = Tname;
        print("nnnnnnnnnnnnnnnname = " + PlayerName);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
