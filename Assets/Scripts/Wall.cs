using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
   // void Start()
   // {
    //    Debug.Log(health);
    //    {

     //   }
   // }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
