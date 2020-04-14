using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNPC : MonoBehaviour
{
    public GameObject uiCanvas;
    private bool uiActive = false;

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            uiActive = !uiActive;
            uiCanvas.SetActive(uiActive);
        }
    }
}
