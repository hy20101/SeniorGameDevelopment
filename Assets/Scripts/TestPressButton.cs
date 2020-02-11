using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPressButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            print("press i");
        }
    }
}
