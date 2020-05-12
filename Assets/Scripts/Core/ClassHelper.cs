using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassHelper : MonoBehaviour
{
    public bool warriorConfirm;
    public bool archerConfirm;
    public bool wizardConfirm;

    void Update()
    {
        if (CharacterSelectionControl.warriorChoose == true)
        {
            Debug.Log("Warrior");
            warriorConfirm = CharacterSelectionControl.warriorChoose;
        }
        else if (CharacterSelectionControl.archerChoose == true)
        {
            Debug.Log("Archer");
            archerConfirm = CharacterSelectionControl.archerChoose;
        }
        else if (CharacterSelectionControl.wizardChoose == true)
        {
            Debug.Log("Wizard");
            wizardConfirm = CharacterSelectionControl.wizardChoose;
        }
    }
}
