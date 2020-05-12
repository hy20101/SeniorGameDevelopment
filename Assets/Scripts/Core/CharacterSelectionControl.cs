using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionControl : MonoBehaviour
{
    public static bool warriorChoose = false;
    public static bool archerChoose = false;
    public static bool wizardChoose = false;

    public void warriorSelected()
    {
        //warriorChoose = true;
        warriorConfirm();
    }

    public void archerSelected()
    {
        //archerChoose = true;
        archerConfirm();
    }

    public void wizardSelected()
    {
        //wizardChoose = true;
        wizardConfirm();
    }

    public bool warriorConfirm()
    {
        return warriorChoose = true;
    }
    public bool archerConfirm()
    {
        return archerChoose = true;
    }
    public bool wizardConfirm()
    {
        return wizardChoose = true;
    }
}
