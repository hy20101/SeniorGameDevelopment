using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public GameObject HelpUI;
    public GameObject AboutUs;

    void Start()
    {
        HelpUI.SetActive(false);
        AboutUs.SetActive(false);
    }

    public void OpenHelp()
    {
        HelpUI.SetActive(true);
    }

    public void CloseHelp()
    {
        HelpUI.SetActive(false);
    }

    public void OpenUS()
    {
        AboutUs.SetActive(true);
    }

    public void CloseUS()
    {
        AboutUs.SetActive(false);
    }
}
