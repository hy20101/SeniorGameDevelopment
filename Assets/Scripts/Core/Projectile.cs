using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject bulletSpawner;
    public GameObject bullet;
    public float speed = 5;
    public float delay = 3;

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fire bullet");
            GameObject tempBulletHandler;
            tempBulletHandler = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;

            tempBulletHandler.transform.Rotate(Vector3.left * 90);

            Rigidbody tempRigid;
            tempRigid = tempBulletHandler.GetComponent<Rigidbody>();

            tempRigid.AddForce(transform.forward * speed);

            Destroy(tempBulletHandler, delay);
        }
    }
}
