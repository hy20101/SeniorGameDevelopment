using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject projectile;
    public GameObject bullet;

    private Rigidbody rb;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject fireball = Instantiate(projectile, transform) as GameObject;
            bullet = Instantiate(projectile, transform) as GameObject;
            //rb = fireball.GetComponent<Rigidbody>();
            rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 20;
        }
    }
}
