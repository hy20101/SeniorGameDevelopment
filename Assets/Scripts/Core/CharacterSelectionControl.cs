using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionControl : MonoBehaviour
{
    public static bool warriorChoose;
    public static bool archerChoose;
    public static bool wizardChoose;

    public bool warriorSelected()
    {
        warriorChoose = true;
        return warriorChoose;
    }

    public bool archerSelected()
    {
        archerChoose = true;
        return archerChoose;
    }

    public bool wizardSelected()
    {
        wizardChoose = true;
        return wizardChoose;
    }
}
