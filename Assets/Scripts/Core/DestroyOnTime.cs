using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float delay = 3f;

    private void Start()
    {
        Destroy(this.gameObject, delay);
    }

}
