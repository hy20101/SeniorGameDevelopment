using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveClass : MonoBehaviour
{
    Transform childWarrior;
    Transform childArcher;
    Transform childWizard;
    ClassHelper classHelp;

    void Start()
    {
        childWarrior = transform.Find("Player_Warrior");
        childArcher = transform.Find("Player_Archer");
        childWizard = transform.Find("Player_Wizard");
        classHelp = GameObject.Find("ClassHelper").GetComponent<ClassHelper>();
    }

    void Update()
    {
        if (classHelp.warriorConfirm == true)
        {
            childWarrior.gameObject.SetActive(true);
            childArcher.gameObject.SetActive(false);
            childWizard.gameObject.SetActive(false);
        }
        else if (classHelp.archerConfirm == true)
        {
            childWarrior.gameObject.SetActive(false);
            childArcher.gameObject.SetActive(true);
            childWizard.gameObject.SetActive(false);
        }
        else if (classHelp.wizardConfirm == true)
        {
            childWarrior.gameObject.SetActive(false);
            childArcher.gameObject.SetActive(false);
            childWizard.gameObject.SetActive(true);
        }
    }
}
